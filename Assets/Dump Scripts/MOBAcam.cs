using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOBAcam : MonoBehaviour
{
    public float scrollSpeed;

    public float topBarrier;
    public float botBarrier;
    public float leftBarrier;
    public float rightBarrier;

    // Update is called once per frame
    void Update()
    {
        if (Input.mousePosition.y >= Screen.height * topBarrier)
            transform.Translate(Vector3.up * Time.deltaTime * scrollSpeed, Space.World);
        if (Input.mousePosition.y <= Screen.height * botBarrier)
            transform.Translate(Vector3.down * Time.deltaTime * scrollSpeed, Space.World);
        if (Input.mousePosition.y >= Screen.width * rightBarrier)
            transform.Translate(Vector3.right * Time.deltaTime * scrollSpeed, Space.World);
        if (Input.mousePosition.y <= Screen.width * leftBarrier)
            transform.Translate(Vector3.left * Time.deltaTime * scrollSpeed, Space.World);
    }
}
