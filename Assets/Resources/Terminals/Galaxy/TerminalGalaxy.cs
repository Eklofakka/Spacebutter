using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TerminalGalaxy : ITerminal
{
    public static bool Open { get; private set; } = false;

    public static readonly int SCALE = 8;

    [Header("Prefabs")]
    [SerializeField] private Transform Content;
    [SerializeField] private GameObject SolarsystemPrefab;

    private Transform PlayerGalaxyIndicator;

    public override IEnumerator OpenTerminal()
    {
        Open = ToBeClosed = false;

        GenerateGalaxy();

        CameraHandler.Instance.SwitchCamera(CameraHandler.Cameras.TERMINAL);

        while (ToBeClosed == false) yield return null;

        Open = ToBeClosed = false;

        CameraHandler.Instance.SwitchCamera(CameraHandler.Cameras.SHIP);
    }

    private void GenerateGalaxy()
    {
        List<SolarSystem> solarsystems = ConstellationHandler.Constellation.SolarSystems;

        List<Tuple<int, int>> alreadyDrawnConnections = new List<Tuple<int, int>>();

        List<Vector2> positions = new List<Vector2>();

        foreach (var solarsytem in solarsystems)
        {
            GameObject solarsystemObj = Instantiate( SolarsystemPrefab );
            solarsystemObj.transform.SetParent( Content, false );
            
            solarsystemObj.transform.localPosition = solarsytem.Position.ToV3() / 4;

            positions.Add( solarsytem.Position );

            GenerateStargateLines(solarsytem, solarsystemObj, alreadyDrawnConnections);
        }

        float totalx = 0;
        float totaly = 0;
        foreach (var pos in positions)
        {
            totalx += pos.x;
            totaly += pos.y;
        }

        Vector3 newCamPos = new Vector3( (totalx / positions.Count) / 4, (totaly / positions.Count) / 4, 18f ).RoundToScale(32);
        CameraHandler.Instance.Terminal.transform.position = newCamPos;

        GameObject dragable = new GameObject();
        dragable.AddComponent<DragCamera>();

        dragable.AddComponent<BoxCollider2D>();
        dragable.GetComponent<BoxCollider2D>().isTrigger = true;
        dragable.GetComponent<BoxCollider2D>().size = new Vector2(20, 20);

        dragable.transform.SetParent( Content.transform, false );
        newCamPos.z = 1;
        dragable.transform.localPosition = newCamPos;

        CreatePlayerCircle();
    }

    private void GenerateStargateLines( SolarSystem solarsystem, GameObject solarsystemObj, List<Tuple<int, int>> alreadyDrawnConnections )
    {
        foreach (var stargate in solarsystem.Stargates)
        {
            SolarSystem targetSystem = ConstellationHandler.Constellation.SolarSystems[stargate.Target.SolarsystemID];

            if (alreadyDrawnConnections.Any( x => x.First == solarsystem.SolarsystemID && x.Second == targetSystem.SolarsystemID ) ||
                alreadyDrawnConnections.Any(x => x.First == targetSystem.SolarsystemID && x.Second == solarsystem.SolarsystemID))
            {
                continue;
            }

            alreadyDrawnConnections.Add(new Tuple<int, int>(solarsystem.SolarsystemID, targetSystem.SolarsystemID));

            GameObject line = DrawPixel.Line.Draw(solarsystem.Position * SCALE, targetSystem.Position * SCALE, new Color( 1, 1, 1, 0.5f ), 4);
            line.transform.SetParent(solarsystemObj.transform, false);

            int xOffset = solarsystem.Position.x < targetSystem.Position.x ? 0 : 1;
            int yOffset = solarsystem.Position.y < targetSystem.Position.y ? 0 : 1;

            Texture2D texture = line.GetComponent<SpriteRenderer>().sprite.texture;

            line.transform.localPosition += new Vector3(0 - (xOffset * texture.width), 0 - (yOffset * texture.height)) / 32;
        }
    }

    private void CreatePlayerCircle()
    {
        SolarSystem solarsystem = ConstellationHandler.Constellation.SolarSystems[ShipHandler.Instance.ActiveShip.Position.SolarID];

        GameObject circle = DrawPixel.Circle.Draw(6, Color.white, true);
        circle.transform.SetParent( Content, false );

        circle.transform.localPosition = PositionToContentPosition( solarsystem.Position, 6 );

        PlayerGalaxyIndicator = circle.transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Open = false;

            ToBeClosed = true;
        }

        if ( PlayerGalaxyIndicator != null )
        {
            SolarSystem solarsystem = ConstellationHandler.Constellation.SolarSystems[ShipHandler.Instance.ActiveShip.Position.SolarID];

            PlayerGalaxyIndicator.localPosition = PositionToContentPosition( solarsystem.Position, 6 ) / 32;
        }
    }

    private Vector3 PositionToContentPosition( Vector2 pos, int offset )
    {
        Vector2 v3 = pos * TerminalGalaxy.SCALE;
        v3.x -= offset;
        v3.y -= offset + 1;

        return new Vector3(v3.x, v3.y, 0f);
    }
}
