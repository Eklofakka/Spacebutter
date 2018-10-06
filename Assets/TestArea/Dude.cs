using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dude : MonoBehaviour
{
    public float speed = 2f;
    // Start is called before the first frame update

    float x = 0;
    float y = 0;

    public bool rigid = false;

    private Rigidbody2D RB;
    private SpriteRenderer SR;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        //if (rigid == false)
        //    transform.position += new Vector3(x, transform.position.z / transform.position.y, y) * Time.deltaTime * speed;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = new Vector3( transform.position.x, -transform.position.z, transform.position.z);

        //transform.position = new Vector3(transform.position.x, (transform.position.z ), transform.position.z);
        if (rigid)
        {
            //if ( x != 0.0f || y != 0.0f )

            RB.velocity = new Vector3(x, y, 0.0f) * speed * Time.fixedDeltaTime;
            //RB.MovePosition( transform.position + ( new Vector3(x, 0.0f, y) * speed * Time.fixedDeltaTime ) );
        }
    }


}
