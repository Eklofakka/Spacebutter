using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DraggableContent : MonoBehaviour, IDragHandler
{
    private Vector3 MoveDelta;

    private Vector3 Center;

    [SerializeField] private Transform Content;

    public void OnDrag(PointerEventData eventData)
    {
        StopAllCoroutines();

        MoveDelta = new Vector3(eventData.delta.x, eventData.delta.y, 0f) / 2f;
        
        Content.transform.localPosition = (Content.localPosition + MoveDelta).RoundToInt();
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

        bool hasReachedTarget = Content.localPosition == newPos;

        while (hasReachedTarget == false)
        {
            newPos = Vector3.MoveTowards(Content.localPosition, ShipHandler.Instance.ActiveShip.Position.Solar * -1, 2f);
            Content.localPosition = newPos;
            hasReachedTarget = Content.localPosition.EqualToV2(ShipHandler.Instance.ActiveShip.Position.Solar * -1);
            yield return null;
        }
    }
}
