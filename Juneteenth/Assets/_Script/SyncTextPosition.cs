using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SyncTextPosition : MonoBehaviour
{
    public Transform objectToFollow;
    public RectTransform uiTextTransform;
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        if (mainCamera == null)
        {
            Debug.LogWarning("Main Camera not found");
            return;
        }

        // circle world position -> screen position
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(objectToFollow.position);

        //  screen position -> UI position
        RectTransformUtility.ScreenPointToLocalPointInRectangle(uiTextTransform.parent as RectTransform, screenPosition, mainCamera, out Vector2 localPoint);

        // Update the UI Text's position
        uiTextTransform.localPosition = localPoint;
    }
}
