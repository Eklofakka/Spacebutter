using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCamera : MonoBehaviour
{
    [SerializeField] private CameraHandler.Cameras Camera;

    private Transform CameraObject;

    private float DragSpeed = 5f;
    private bool Dragging = false;
    private Vector3 DragOrigin;
    private Vector3 CameraOrigin;

    private void Start()
    {
        CameraObject = CameraHandler.Instance.GetCamera( Camera ).transform;
    }

    private void Update()
    {
        if ( Input.GetMouseButtonDown(0) )
        {
            DragOrigin = Input.mousePosition;
            Dragging = true;
        }

        if ( Input.GetMouseButtonUp(0) )
        {
            Dragging = false;
        }

        if ( Dragging )
        {
            Vector3 newPos = CameraObject.position + ((DragOrigin - Input.mousePosition) / 64f);
            
            newPos.x = Mathf.RoundToInt(newPos.x / 0.03125f) * 0.03125f;
            newPos.y = Mathf.RoundToInt(newPos.y / 0.03125f) * 0.03125f;
            newPos.z = CameraObject.position.z;

            CameraObject.position = newPos;

            DragOrigin = Input.mousePosition;
        }
    }
}
