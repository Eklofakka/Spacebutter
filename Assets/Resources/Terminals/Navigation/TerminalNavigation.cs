using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminalNavigation : MonoBehaviour
{
    [SerializeField] private GameObject Sun;
    [SerializeField] private Icon_Stargate Stargate;
    [SerializeField] private GameObject Ship;

    private GameObject f;

    [SerializeField] private Transform Content;


    public void Start()
    {
        CreateSun();
        CreatePlanet();
        CreateShip();
    }

    private void CreateSun()
    {
        var sun = Instantiate( Sun );
        sun.transform.SetParent( Content.transform, false );
        sun.transform.localPosition = new Vector3(0, 0, 0);
    }

    private void CreatePlanet()
    {
        var stargate = Instantiate(Stargate);
        stargate.transform.SetParent( Content.transform, false );
        stargate.transform.localPosition = new Vector3( 100, 100, 0 );
        stargate.OnClick += OnIconClicked;
    }

    private void CreateShip()
    {
        var ship = Instantiate(Ship);
        ship.transform.SetParent(Content.transform, false);
        ship.transform.localPosition = new Vector3(0, 0, 0);
        f = ship;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            Destroy(gameObject);
        Vector3 ff = ShipHandler.Instance.ActiveShip.Position.Galaxy;
        f.transform.localPosition = ff.RoundToInt();
    }

    #region Button Events
    public void OnIconClicked( Icon_Stargate icon )
    {
        var menu = Instantiate( Resources.Load<MenuStargate>("Terminals/Navigation/Prefabs/Menu_Stargate") );
        menu.transform.SetParent( MainCanvas.Instance.transform, false );

        menu.OnClose += (x) => print("woop");
    }
    #endregion
}
