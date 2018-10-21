using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TerminalNavigation : MonoBehaviour
{
    [SerializeField] private GameObject Sun;
    [SerializeField] private Icon_Stargate Stargate;
    [SerializeField] private GameObject Ship;
    [SerializeField] private GameObject Planet;
    [SerializeField] private TextMeshProUGUI SolarsystemNameDisplay;

    private GameObject f;

    [SerializeField] private Transform Content;


    public void Start()
    {
        GenerateSolarSystem();
    }

    private void ClearSolarSystem()
    {
        foreach (Transform content in Content)
        {
            Destroy( content.gameObject );
        }
    }

    private void GenerateSolarSystem()
    {
        ClearSolarSystem();

        GalaxyHandler.GenerateGalaxy();

        SolarSystem curSolarSystem = GalaxyHandler.SolarSystems[ShipHandler.Instance.ActiveShip.Position.SolarID];

        SolarsystemNameDisplay.text = curSolarSystem.Name;

        CreateShip();

        CreateSun();

        foreach (var planet in curSolarSystem.Planets)
        {
            CreatePlanet(planet);
        }

        CreateStargate( curSolarSystem.Stargates[0] );
    }

    private void CreateSun()
    {
        var sun = Instantiate( Sun );
        sun.transform.SetParent( Content.transform, false );
        sun.transform.localPosition = new Vector3(0, 0, 0);
    }

    private void CreatePlanet( Planet planet )
    {
        var planetObj = Instantiate(Planet);
        planetObj.transform.SetParent( Content.transform, false );
        planetObj.transform.localPosition = planet.Position;
        
    }

    private void CreateShip()
    {
        var ship = Instantiate(Ship);
        ship.transform.SetParent(Content.transform, false);
        ship.transform.localPosition = new Vector3(0, 0, 0);
        f = ship;
    }

    private void CreateStargate( Stargate stargate )
    {
        var stargateObj = Instantiate( Stargate );
        stargateObj.transform.SetParent( Content.transform, false );
        stargateObj.Stargate = stargate;
        stargateObj.transform.localPosition = stargate.Position;
        
        stargateObj.OnClick += OnIconClicked;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            Destroy(gameObject);
        Vector3 ff = ShipHandler.Instance.ActiveShip.Position.Solar;
        f.transform.localPosition = ff.RoundToInt();
    }

    #region Button Events
    public void OnIconClicked( Icon_Stargate icon )
    {
        if (Vector2.Distance(ShipHandler.Instance.ActiveShip.Position.Solar, icon.Stargate.Position) > 15) return;

        var menu = Instantiate( Resources.Load<MenuStargate>("Terminals/Navigation/Prefabs/Menu_Stargate") );
        menu.transform.SetParent( MainCanvas.Instance.transform, false );
        
        menu.OnClose += (x) => { ShipHandler.Instance.ActiveShip.Position.JumpToGalaxy( icon.Stargate.Target ); GenerateSolarSystem(); };
    }
    #endregion
}