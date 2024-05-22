using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractiveItem : MonoBehaviour
{
    private Vector3 originalScale;
    public float scaleMultiplier = 2.0f;
   

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        
    }
    

    void OnMouseEnter()
    {
        transform.localScale = originalScale * scaleMultiplier; 
    }
    void OnMouseExit()
    {
        transform.localScale = originalScale;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}
