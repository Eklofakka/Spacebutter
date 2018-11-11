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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StopAllCoroutines();
            StartCoroutine( PanToShip() );
        }
    }

    private IEnumerator PanToShip()
    {
        Vector3 newPos = ShipHandler.Instance.ActiveShip.Position.Solar * -1;

        bool hasReachedTarget = transform.localPosition == newPos;
        
        while (hasReachedTarget == false)
        {
            newPos = Vector3.MoveTowards(transform.localPosition, ShipHandler.Instance.ActiveShip.Position.Solar * -1, 2f);
            transform.localPosition = newPos;
            hasReachedTarget = transform.localPosition.EqualToV2(ShipHandler.Instance.ActiveShip.Position.Solar * -1);
            yield return null;
        }
    }
}
