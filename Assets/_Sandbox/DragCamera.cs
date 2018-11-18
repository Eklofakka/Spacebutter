using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragCamera : MonoBehaviour, IDragHandler
{
    private Transform CameraObject;
    
    private Vector3 newPos;
    Vector3 delta;

    private void Start()
    {
        CameraObject = Camera.main.transform;
    }

    public void OnDrag(PointerEventData eventData)
    {
        delta = eventData.delta;

        newPos = CameraObject.position - delta / 64f;
        newPos = newPos.RoundToScale(32f);
        newPos.x = Mathf.Clamp(newPos.x, -25, 25);
        newPos.y = Mathf.Clamp(newPos.y, -25, 25);

        CameraObject.position = newPos;
    }
}
