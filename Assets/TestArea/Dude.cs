using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        // TODO: DUH
        if ( Input.GetKeyDown(KeyCode.F) )
        {
            Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 1);
            
            List<Tuple<IInteract, Vector2>> cs = new List<Tuple<IInteract, Vector2>>();
            foreach (Collider2D c in cols)
            {
                IInteract t = c.GetComponent<IInteract>();

                if (t != null)
                    cs.Add(new Tuple<IInteract, Vector2>(t, c.transform.position));

            }

            if (cs.Count < 1) return;
            List<Tuple<IInteract, Vector2>> sorted = cs.OrderBy(o => Vector2.Distance(o.Second, transform.position)).ToList();

            sorted[0].First.Interact();
        }
    }

    void FixedUpdate()
    {
        if (rigid)
        {
            RB.velocity = new Vector3(x, y, 0.0f) * speed * Time.fixedDeltaTime;
        }
    }


}
