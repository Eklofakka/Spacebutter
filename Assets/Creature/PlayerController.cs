using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, ICreature
{
    // ICreature
    public Vector2 Position { get; set; }
    public float Speed { get; set; }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x == 0.0f && y == 0.0f) return;

        transform.position += new Vector3( x, 0, y );
    }
}
