using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShootLink : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private float counter;
    private float dist;
    public Transform origin;
    public Transform destination;

    public float lineDrawSpeed = 6f;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetWidth(.45f, .45f);        
    }
    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(0, origin.position);

        dist = Vector3.Distance(origin.position, destination.position);
        if (counter < dist)
        {
           
            counter += .1f / lineDrawSpeed;
            float x = Mathf.Lerp(0, dist, counter);

            Vector3 pointA = origin.position;
            Vector3 pointB = destination.position;

            Vector3 pointAlongLine = x * Vector3.Normalize(pointB - pointA) + pointA;

            lineRenderer.SetPosition(1, pointAlongLine);
        }
    }
}
