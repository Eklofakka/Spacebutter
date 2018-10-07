using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TO_CargoBox : TileObject
{
    public static List<TO_CargoBox> CargoBoxes { get; set; } = new List<TO_CargoBox>();

    public List<CargoBoxContent> Content { get; private set; }

    public int Weight = 10;

    public int MaxVol = 1;

    public int CurVol
    {
        get
        {
            return Content.Count;
        }
    }

    private void Start()
    {
        CargoBoxes.Add( this );

        Content = new List<CargoBoxContent>();
        Content.Add( new CargoBoxContent("Shorts") );
        Content.Add( new CargoBoxContent("Guns") );
        Content.Add( new CargoBoxContent("Pineapples") );
        Content.Add( new CargoBoxContent("Half-Slave") );
        Content.Add( new CargoBoxContent("Socks") );
        Content.Add( new CargoBoxContent("Anti-Therm Clear") );
        Content.Add( new CargoBoxContent("XT-24") );
        Content.Add( new CargoBoxContent("XT-24") );
        Content.Add( new CargoBoxContent("XT-25") );
        Content.Sort((x, y) => x.Name.CompareTo(y.Name));
    }
}