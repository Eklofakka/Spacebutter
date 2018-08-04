using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet {

    public string Name { get; set; }
    
    public enum Types { Terran = 0, Gas = 1, Barren = 2, Lava = 3, Oceanic = 4 }

    public Types Type { get; set; }

    public Planet()
    {
        Name = UnityEngine.Random.Range(1000, 9999).ToString();

        Array types = Enum.GetValues(typeof(Types));

        Type =  (Types)types.GetValue(UnityEngine.Random.Range(0, types.Length));
    }
}
