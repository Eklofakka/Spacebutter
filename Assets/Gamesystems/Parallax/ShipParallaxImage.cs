using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipParallaxImage : MonoBehaviour
{
    public bool Moving { get; private set; }

    public Vector3 Speed { get; set; } = new Vector3(2, 0, 0);

    private Vector3 StartPosition = new Vector3(15, 5 , 0);

    void Update()
    {
        if (ShipHandler.Instance.ActiveShip.Position.Moving == false) return;

        transform.position -= Speed * Time.deltaTime;

        if (transform.localPosition.x <= -45)
            transform.localPosition = StartPosition;
    }
}
