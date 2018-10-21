using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DraggableContent : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    private Vector3 MoveDelta;

    private GameObject Selector;

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

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.dragging != false) return;

        if (Selector == null)
        {
            Selector = Instantiate(Resources.Load<GameObject>("Terminals/Navigation/Prefabs/Selector"));
            Selector.transform.SetParent( transform, false );
        }

        Vector3 pos = eventData.position / 2f;
        pos.x -= 480;
        pos.y -= 270;
        pos = pos.RoundToInt();
        pos = pos - transform.localPosition;

        Selector.transform.localPosition = pos;

        ShipHandler.Instance.ActiveShip.Position.SetSolarDestination( pos );
    }
}
