using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragableItem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private bool isDragging = false;
    [SerializeField] private Color originalColor;
    [SerializeField] private Color selectedColor;
    [SerializeField] private string holderTag;
    private GameObject[] holderArray;
    void Start()
    {
        holderArray = GameObject.FindGameObjectsWithTag(holderTag);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDragging)
        {
            posWithMouse(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == holderTag)
        {
            SpriteRenderer objRenderer = obj.gameObject.GetComponent<SpriteRenderer>();
            objRenderer.color = selectedColor;
        }
    }
    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.tag == holderTag)
        {
            SpriteRenderer objRenderer = obj.gameObject.GetComponent<SpriteRenderer>();
            objRenderer.color = originalColor;
        }
    }
    private void OnMouseDown()
    {
        isDragging = true;
    }
    private void OnMouseUp()
    {
        isDragging = false;
        //check distance with all time holder
        foreach (GameObject obj in holderArray)
        {
            if (Vector2.Distance(transform.position, obj.transform.position) <= 0.5)
            {
                transform.position = obj.transform.position;
            }
        }
    }
    public void posWithMouse(GameObject obj)
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        obj.transform.position = mousePos;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
