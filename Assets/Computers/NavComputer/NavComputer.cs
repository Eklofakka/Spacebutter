using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Computers
{
    namespace NavComputer
    {
        public class NavComputer : MonoBehaviour
        {
            private Transform MainShipIcon;

            [SerializeField] private GameObject SpacePlane;

            [Header("Prefabs")]
            [SerializeField] private GameObject MainShipIconPrefab;
            [SerializeField] private GameObject StarSystemPrefab;

            [Header("Interface")]
            [SerializeField] private TextMeshProUGUI MainPosition;

            private void Start()
            {
                SpawnMap();
            }

            private void Update()
            {
                MainPosition.text = "X: " + Ship.MainShip.Position.x.ToString() + "\nY: " + Ship.MainShip.Position.x.ToString();
            }

            private void SpawnMap()
            {
                SpawnMainShip();

                SpawnStars();
            }

            private void SpawnMainShip()
            {
                GameObject mainShip = Instantiate( MainShipIconPrefab );
                mainShip.transform.SetParent( SpacePlane.transform, false );
                mainShip.transform.localPosition = Ship.MainShip.Position.ToV3();

                MainShipIcon = mainShip.transform;
            }

            private void SpawnStars()
            {
                for (int i = 0; i < 10; i++)
                {
                    SpawnStar( new SolarSystem() );
                }
            }

            private void SpawnStar( SolarSystem solarSystem )
            {
                GameObject obj = Instantiate( StarSystemPrefab );
                obj.transform.SetParent( SpacePlane.transform, false );
                obj.transform.localPosition = solarSystem.Position.ToV3();
            }
        }
    }
}
