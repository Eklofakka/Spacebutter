using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class M : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    public Transform p;

    public void OnDrag(PointerEventData eventData)
    {
        p.transform.localPosition += new Vector3( eventData.delta.x/2, eventData.delta.y/2, 0 );

        p.transform.localPosition = p.transform.localPosition.ToNearestWhole();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //transform.position = Input.mousePosition;
    }
}
