using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class PlayerController : MonoBehaviourPunCallbacks
{
    //Points
    public float points;

    //Camera
    public Camera thisCamera;
    public Transform cameraTarget;

    //Player
    public GameObject playerObj;
    private PhotonView PV;

    private void Start()
    {
        PV = this.GetComponent<PhotonView>();
    }
    void Update()
    {
        if (PV.IsMine)
            Cam();
    }

    public void mCameraSetup(Camera mainCamera) {
        thisCamera = mainCamera;
    }
    void Cam()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 7f * Time.deltaTime);
        }
    }

}
