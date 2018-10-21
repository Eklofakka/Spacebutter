using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class TerminalNavigation : MonoBehaviour, IPointerClickHandler
{
    public static bool Open { get; private set; } = false;

    [Header("Body Prefabs")]
    [SerializeField] private GameObject Sun;
    [SerializeField] private TerminalNavigationSolarIcon IconPrefab;
    [SerializeField] private GameObject Ship;
    [SerializeField] private GameObject Planet;
    [SerializeField] private Transform Content;
    [SerializeField] private TextMeshProUGUI SolarsystemNameDisplay;

    [Header("Target Info")]
    [SerializeField] private TextMeshProUGUI TargetPositionDisplay;
    [SerializeField] private TextMeshProUGUI TargetDistanceDisplay;
    [SerializeField] private TextMeshProUGUI ETADisplay;

    [Header("Planet Info")]
    [SerializeField] private GameObject PlanetInfoPrefab;

    private GameObject PlayerShipMarker;

    private static Vector2 SelectorPosition = Vector2.zero;
    private static GameObject _Selector = null;
    private GameObject Selector
    {
        get
        {
            if ( _Selector == null )
            {
                _Selector = Instantiate(Resources.Load<GameObject>("Terminals/Navigation/Prefabs/Selector"));
                _Selector.transform.SetParent(Content.parent.transform, false);
            }

            return _Selector;
        }
    }

    private static GameObject _Marker = null;
    private GameObject Marker
    {
        get
        {
            if (_Marker == null)
            {
                _Marker = Instantiate(Resources.Load<GameObject>("Terminals/Navigation/Prefabs/Selector"));
                _Marker.transform.SetParent(Content.parent.transform, false);
            }

            return _Marker;
        }
    }

    [Header("Marker Info")]
    [SerializeField] private TextMeshPro MarketPositionDisplay;
    [SerializeField] private TextMeshPro MarketDistanceDisplay;

    public void Start()
    {
        Open = true;

        GenerateSolarSystem();
    }

    private void ClearSolarSystem()
    {
        foreach (Transform content in Content)
        {
            Destroy( content.gameObject );
        }

        Destroy( Selector );
        Destroy( Marker );
    }

    private void GenerateSolarSystem()
    {
        ClearSolarSystem();

        GalaxyHandler.GenerateGalaxy();

        SolarSystem curSolarSystem = GalaxyHandler.SolarSystems[ShipHandler.Instance.ActiveShip.Position.SolarID];

        SolarsystemNameDisplay.text = curSolarSystem.Name;

        CreateSun();

        foreach (var planet in curSolarSystem.Planets)
        {
            CreatePlanet(planet);
        }

        CreateStargate( curSolarSystem.Stargates[0] );

        CreateShip();
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
        PlayerShipMarker = ship;
    }

    private void CreateStargate( Stargate stargate )
    {
        var stargateObj = Instantiate( IconPrefab );
        stargateObj.transform.SetParent( Content.transform, false );
        stargateObj.Body = stargate;
        stargateObj.transform.localPosition = stargate.Position;
        
        stargateObj.OnClick += OnIconClicked;
    }

    private void UpdateTargetInfo()
    {
        if ( SelectorPosition != null )
            TargetPositionDisplay.text = "Position: " + SelectorPosition;

        float dist = Vector2.Distance(SelectorPosition, ShipHandler.Instance.ActiveShip.Position.Solar);
        TargetDistanceDisplay.text = "Distance: " + string.Format( "{0:0.00}", dist / 350f ) + " AU";

        ETADisplay.text = "ETA: " + string.Format("{0:0.00}", dist / 4f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Open = false;
            Destroy(gameObject);
        }

        Vector3 ff = ShipHandler.Instance.ActiveShip.Position.Solar;
        PlayerShipMarker.transform.localPosition = ff.RoundToInt();

        UpdateTargetInfo();
    }

    #region Button Events
    public void OnIconClicked( TerminalNavigationSolarIcon icon, PointerEventData eventData )
    {
        switch( icon.BodyType )
        {
            case TerminalNavigationSolarIcon.BodyTypes.STARGATE:
                OnStargateClicked( icon, eventData);
                break;
            case TerminalNavigationSolarIcon.BodyTypes.PLANET:
                OnPlanetClicked(icon);
                break;
            case TerminalNavigationSolarIcon.BodyTypes.SUN:
                OnSunClicked(icon);
                break;
        }
    }

    private void OnStargateClicked(TerminalNavigationSolarIcon icon, PointerEventData eventData)
    {
        Marker.transform.localPosition = icon.Body.Position;

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Selector.transform.localPosition = SelectorPosition = icon.Body.Position;
            ShipHandler.Instance.ActiveShip.Position.SetSolarDestination(SelectorPosition);
        }

        if (Vector2.Distance(ShipHandler.Instance.ActiveShip.Position.Solar, icon.Body.Position) > 15) return;

        var menu = Instantiate(Resources.Load<MenuStargate>("Terminals/Navigation/Prefabs/Menu_Stargate"));
        menu.transform.SetParent(MainCanvas.Instance.transform, false);

        Stargate stargate = icon.Body as Stargate;

        menu.OnClose += (x) => { ShipHandler.Instance.ActiveShip.Position.JumpToGalaxy(stargate.Target); GenerateSolarSystem(); };
    }

    private void OnPlanetClicked(TerminalNavigationSolarIcon icon)
    {

    }

    private void OnSunClicked( TerminalNavigationSolarIcon icon )
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.dragging != false) return;
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Vector3 pos = eventData.position / 2f;
            pos.x -= 480;
            pos.y -= 270;
            pos = pos.RoundToInt();
            pos = pos - Content.transform.parent.localPosition;

            Selector.transform.localPosition = SelectorPosition = pos;

            if (Input.GetKey(KeyCode.LeftControl))
            {
                ShipHandler.Instance.ActiveShip.Position.Solar = pos;
                ShipHandler.Instance.ActiveShip.Position.SolarTarget = pos;
            }
            else
            {
                ShipHandler.Instance.ActiveShip.Position.SetSolarDestination(pos);
            }
        }
    }
    #endregion
}