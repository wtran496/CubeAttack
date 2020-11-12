using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject quickStartButton = null;
    [SerializeField]
    private GameObject quickCancelButton = null;
    [SerializeField]
    private int RoomSize = 0;

    private IEnumerator CancelWait(float waitTime) {
        quickCancelButton.GetComponent<Button>().interactable = false;
        PhotonNetwork.LeaveRoom();     
        yield return new WaitForSeconds(waitTime);
        quickStartButton.SetActive(true);
        quickCancelButton.SetActive(false);
        quickCancelButton.GetComponent<Button>().interactable = true;

    }

    public override void OnConnectedToMaster() {
        PhotonNetwork.AutomaticallySyncScene = true; //Makes it so whatever scene the master client has loaded in the scne all other clients will load
        quickStartButton.SetActive(true);
    }

    public void QuickStart() {
        quickStartButton.SetActive(false);
        quickCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Quick start");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join a room");
        CreateRoom();
    }

    void CreateRoom() {
        Debug.Log("Creating room now");
        int randomRoomNumber = Random.Range(0, 10000); //creating random name for the room
        RoomOptions roomOps = new RoomOptions() { 
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = (byte)RoomSize
    };
        PhotonNetwork.CreateRoom("Room " + randomRoomNumber, roomOps);
        Debug.Log(randomRoomNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join a room...trying again");
        CreateRoom();
    }

    public void QuickCancel() {
        StartCoroutine(CancelWait(2f));
    }
}
