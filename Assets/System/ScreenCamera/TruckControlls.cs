using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckControlls : MonoBehaviour
{
    private Vector3 targetPos;

    public float speed = 50f;

    public GameObject follow;

    private Vector3 offset;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 120;

        offset = follow.transform.position - transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        //targetPos = new Vector3(follow.transform.position.x, transform.position.y, 0f);

        Vector3 velocity = follow.transform.position - transform.position * speed;

        //transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 1.0f, Time.deltaTime);

        //transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);

        transform.position = new Vector3(follow.transform.position.x, follow.transform.position.y - 2, 0f);
    }
}
