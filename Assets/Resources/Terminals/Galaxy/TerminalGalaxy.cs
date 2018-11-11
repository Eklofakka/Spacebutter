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

    public override IEnumerator OpenTerminal()
    {
        Open = ToBeClosed = false;

        GenerateGalaxy();

        while (ToBeClosed == false) yield return null;

        Open = ToBeClosed = false;
    }

    private void GenerateGalaxy()
    {
        List<SolarSystem> solarsystems = ConstellationHandler.Constellation.SolarSystems;

        List<Tuple<int, int>> alreadyDrawnConnections = new List<Tuple<int, int>>();

        foreach (var solarsytem in solarsystems)
        {
            GameObject solarsystemObj = Instantiate( SolarsystemPrefab );
            solarsystemObj.transform.SetParent( Content, false );
            
            solarsystemObj.transform.localPosition = solarsytem.Position.ToV3() * SCALE;

            solarsystemObj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = solarsytem.Name;

            GenerateStargateLines(solarsytem, solarsystemObj, alreadyDrawnConnections);
        }
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

            GameObject line = DrawPixelLine.Line(solarsystem.Position * SCALE, targetSystem.Position * SCALE, Color.white, 4);
            line.transform.SetParent(solarsystemObj.transform, false);

            int xOffset = solarsystem.Position.x < targetSystem.Position.x ? 0 : 1;
            int yOffset = solarsystem.Position.y < targetSystem.Position.y ? 0 : 1;

            Texture2D texture = line.GetComponent<Image>().sprite.texture;

            line.transform.localPosition += new Vector3(0 - (xOffset * texture.width), 0 - (yOffset * texture.height));
        }
    }
}
