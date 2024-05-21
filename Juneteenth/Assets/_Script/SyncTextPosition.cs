using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SyncTextPosition : MonoBehaviour
{
    public Transform objectToFollow; // The object in the scene to follow
    public RectTransform uiTextTransform; // The RectTransform of the UI Text (TextMeshPro)
    private Camera mainCamera; // Reference to the main camera

    void Start()
    {
        // Find and assign the main camera at runtime
        mainCamera = Camera.main;
    }
    void Update()
    {
        // Check if mainCamera is assigned
        if (mainCamera == null)
        {
            Debug.LogWarning("Main Camera not found");
            return;
        }

        // Convert the world position of the circle to screen position
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(objectToFollow.position);

        // Convert the screen position to UI position
        RectTransformUtility.ScreenPointToLocalPointInRectangle(uiTextTransform.parent as RectTransform, screenPosition, mainCamera, out Vector2 localPoint);

        // Update the UI Text's position
        uiTextTransform.localPosition = localPoint;
    }
}
