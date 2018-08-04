using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Computers
{
    namespace NavComputer
    {
        public class NavComputerDragger : MonoBehaviour,  IDragHandler
        {
            public Transform p;

            public void OnDrag(PointerEventData eventData)
            {
                p.transform.localPosition += new Vector3(eventData.delta.x / 2, eventData.delta.y / 2, 0);

                p.transform.localPosition = p.transform.localPosition.RoundToInt();
            }
        }
    }
}