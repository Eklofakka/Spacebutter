using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lined : MonoBehaviour
{
    LineRenderer Renderer;

    // Start is called before the first frame update
    void Start()
    {
        Renderer = GetComponent<LineRenderer>();
    }

    public void Init(int startx, int starty, int endx, int endy)
    {
        Vector3[] points = new Vector3[2];
        points[0] = new Vector3( startx, starty, 0 );
        points[1] = new Vector3( endx, endy, 0 );


        GetComponent<LineRenderer>().SetPositions(points);
    }
}
