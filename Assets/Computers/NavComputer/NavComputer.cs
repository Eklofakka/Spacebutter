using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

            private void Start()
            {
                SpawnMap();
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
