using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCamera : MonoBehaviour
{
    [SerializeField] private CameraHandler.Cameras Camera;

    private Transform CameraObject;

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
            var eventSys = GameObject.Find("EventSystem").GetComponent<EventSystem>();

            if (eventSys.IsPointerOverGameObject())
            {
                return; // exit out of OnMouseDown() because its over the uGUI
            }

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

            newPos = newPos.RoundToScale(32f);

            CameraObject.position = newPos;

            DragOrigin = Input.mousePosition;
        }
    }
}
