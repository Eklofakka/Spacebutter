using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : SolarSystemBody
{
    public static List<string> Names = new List<string>()
    {
        "New Mojave",
        "Ahemait II",
        "Anith",
        "Telmun",
        "Nehebkau",
        "New Sahul",
        "Bara Tani",
        "8546 Canum V",
        "New Gaia",
        "5783 Xing Xiu VI",
        "Renenet",
        "8062 Maenali VII",
        "B'Meri",
        "Akul VI",
        "4719 Felis VI",
        "Uinen",
        "Feri",
        "5958 Lyrae VII",
        "Squarro",
        "New Titan",
        "Lori",
        "Zera M'Idar's Stand",
        "Teta",
        "Xelniea",
        "2152 Eridani VII",
        "Shata",
        "Majy",
        "M'Morko",
        "New Oberon",
        "9782 Solarii Prime",
        "Utumno III",
        "New Mars",
        "3833 Leonis V",
        "New Phaeton",
        "New Pallas",
        "Shani B'Oduld's Stand",
        "New Deseret",
        "New Angeles",
        "New France",
        "7762 Fornacis II"
    };

    public string Name { get; set; }
    
    public enum Types { Terran = 0, Gas = 1, Barren = 2, Lava = 3, Oceanic = 4 }

    public Types Type { get; set; }

    public Planet()
    {
        Name = UnityEngine.Random.Range(1000, 9999).ToString();

        Array types = Enum.GetValues(typeof(Types));

        Type =  (Types)types.GetValue(UnityEngine.Random.Range(0, types.Length));
    }

    public Planet( Vector2 position )
    {
        Name = Names[UnityEngine.Random.Range( 0, Names.Count )];

        Array types = Enum.GetValues(typeof(Types));

        Type = (Types)types.GetValue(UnityEngine.Random.Range(0, types.Length));

        Position = position;
    }
}
