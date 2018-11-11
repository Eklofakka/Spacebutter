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
        MoveDelta = new Vector3(eventData.delta.x, eventData.delta.y, 0f) / 2f;

        //transform.localPosition = (transform.localPosition + MoveDelta).RoundToInt();
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

        if (Input.GetKeyDown(KeyCode.X))
        {
            StopAllCoroutines();
            StartCoroutine(PanToGalaxy());
        }
    }

    private IEnumerator PanToShip()
    {
        //Vector3 newPos = ShipHandler.Instance.ActiveShip.Position.Solar * -1;

        //bool hasReachedTarget = transform.localPosition == newPos;

        //while (hasReachedTarget == false)
        //{
        //    newPos = Vector3.MoveTowards(transform.localPosition, ShipHandler.Instance.ActiveShip.Position.Solar * -1, 2f);
        //    transform.localPosition = newPos;
        //    hasReachedTarget = transform.localPosition.EqualToV2(ShipHandler.Instance.ActiveShip.Position.Solar * -1);
        //    yield return null;
        //}

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

    private IEnumerator PanToGalaxy()
    {
        Vector3 newPos = ConstellationHandler.Constellation.SolarSystems[ShipHandler.Instance.ActiveShip.Position.SolarID].Position.ToV3() * TerminalGalaxy.SCALE;
        print(ConstellationHandler.Constellation.SolarSystems[ShipHandler.Instance.ActiveShip.Position.SolarID].Name);

        bool hasReachedTarget = Content.localPosition == newPos;

        while (hasReachedTarget == false)
        {
            newPos = Vector3.MoveTowards(Content.localPosition, newPos * -1, 2f);
            Content.localPosition = newPos;
            //hasReachedTarget = Content.localPosition.EqualToV2(newPos * -1);
            hasReachedTarget = Vector2.Distance(Content.localPosition, newPos * -1) < 2;
            yield return null;
        }
    }
}
