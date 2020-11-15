using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView PV;
    public PlayerController myAvatar;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        int spawnPicker = Random.Range(0, GameSetup.GS.spawnPoints.Length);
        if (PV.IsMine) {
            GameObject avatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Player"), GameSetup.GS.spawnPoints[spawnPicker].position,GameSetup.GS.spawnPoints[spawnPicker].rotation, 0);
            myAvatar = avatar.GetComponent<PlayerController>();
            //Camera
            myAvatar.mCameraSetup(GameSetup.GS.myCamera);
            GameSetup.GS.myCamera.GetComponent<mCamera>().thisPlayer = myAvatar.cameraTarget;
        }
    }

}
