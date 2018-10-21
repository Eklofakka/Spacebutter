using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DraggableContent : MonoBehaviour, IDragHandler
{
    private Vector3 MoveDelta;



    private Vector3 Center;

    public void OnDrag(PointerEventData eventData)
    {
        MoveDelta = new Vector3(eventData.delta.x, eventData.delta.y, 0f) / 2f;

        transform.localPosition = (transform.localPosition + MoveDelta).RoundToInt();
    }

    private void Start()
    {
        Center = GetComponent<RectTransform>().rect.center;
    }
}
