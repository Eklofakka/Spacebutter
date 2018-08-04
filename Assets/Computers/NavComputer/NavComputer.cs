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
            public static NavComputer Inst;

            private Transform MainShipIcon;

            [SerializeField] private GameObject SpacePlane;

            [Header("Prefabs")]
            [SerializeField] private GameObject MainShipIconPrefab;
            [SerializeField] private GameObject StarSystemPrefab;

            [Header("Interface")]
            [SerializeField] private TextMeshProUGUI MainPosition;

            [Header("Selected SolarSystem")]
            private SolarSystem _SelectedSolarSystem;
            public SolarSystem SelectedSolarSystem
            {
                get
                {
                    return _SelectedSolarSystem;
                }
                set
                {
                    _SelectedSolarSystem = value;
                    OnSelectedSolarSystemChanged();
                }
            }

            [SerializeField] private TextMeshProUGUI SelectedSolarSystemPosition;

            private void Awake()
            {
                Inst = this;
            }

            private void Start()
            {
                SpawnMap();
            }

            private void Update()
            {
                MainPosition.text = "X: " + Ship.MainShip.Position.x.ToString() + "\n" +
                                    "Y: " + Ship.MainShip.Position.y.ToString();
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
                obj.GetComponent<NavComputerStarIcon>().SolarSystem = solarSystem;
            }

            private void OnSelectedSolarSystemChanged()
            {
                SelectedSolarSystemPosition.text = "X: " + SelectedSolarSystem.Position.x.ToString() + "\n" +
                                                   "Y: " + SelectedSolarSystem.Position.y.ToString();
            }
        }
    }
}
