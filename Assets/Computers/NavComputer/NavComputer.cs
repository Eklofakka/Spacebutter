using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Computers
{
    namespace NavComputer
    {
        public class NavComputer : MonoBehaviour
        {
            public Transform MainShipIcon;

            private void Start()
            {
                MainShipIcon.localPosition = Ship.MainShip.Position.ToV3();
            }
        }
    }
}
