using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class mCamera : MonoBehaviourPunCallbacks
{
    public Transform thisPlayer = null;
    public float smooth = 0.3f;
    public float height = 10;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (thisPlayer != null)
        {
            Vector3 pos = new Vector3
            {
                x = thisPlayer.position.x,
                z = thisPlayer.position.z - 14f,
                y = thisPlayer.position.y + height
            };
            transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smooth);
        }
    }
}
