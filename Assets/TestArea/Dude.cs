using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dude : MonoBehaviour
{
    public float speed = 2f;

    float x = 0;
    float y = 0;

    public bool rigid = false;

    private Rigidbody2D RB;
    private SpriteRenderer SR;

    public static Dude Main { get; set; }

    public bool CanMove = true;

    private void Awake()
    {
        Main = this;
    }

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (CanMove == false) return;

        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

    }

    void FixedUpdate()
    {
        if (rigid)
        {
            RB.velocity = new Vector3(x, y, 0.0f) * speed * Time.fixedDeltaTime;
        }
    }


}
