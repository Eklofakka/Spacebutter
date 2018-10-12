using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICreature
{
    Vector2 Position { get; set; }

    float Speed { get; set; }
}
