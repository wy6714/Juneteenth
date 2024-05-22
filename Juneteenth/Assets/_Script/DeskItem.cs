using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskItem : MonoBehaviour
{
    [SerializeField] private Transform cameraPos;
    [SerializeField] private GameObject TargetUIObj;
    // Start is called before the first frame update
    void Start()
    {
        TargetUIObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected virtual void OnMouseUp()
    {
        //open target UI canvas
        if (TargetUIObj != null)
        {
            TargetUIObj.SetActive(true);
        }

        //go the open item place;
        if (cameraPos != null)
        {
            Camera mainCamera = Camera.main;
            mainCamera.transform.position = cameraPos.position;
        }


    }
}
