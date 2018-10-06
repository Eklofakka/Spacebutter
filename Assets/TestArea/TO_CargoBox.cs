using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TO_CargoBox : TileObject
{
    public static List<TO_CargoBox> CargoBoxes { get; set; } = new List<TO_CargoBox>();

    public List<string> Content { get; private set; }

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

        Content = new List<string>();
        Content.Add( "Shorts" );
        Content.Add( "Guns" );
        Content.Add( "Pineapples" );
        Content.Add( "Half-Slave" );
        Content.Add( "Socks" );
        Content.Add( "Anti-Therm Clear" );
        Content.Add( "XT-24" );
        Content.Add( "XT-24" );
        Content.Add( "XT-25" );
        Content.Sort();
    }
}