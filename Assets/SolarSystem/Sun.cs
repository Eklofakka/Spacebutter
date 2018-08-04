using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun {

    public string Name { get; set; }

    public Sun()
    {
        Name = Random.Range(1000, 9999).ToString();
    }
}
