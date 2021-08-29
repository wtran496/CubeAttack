using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class PlayerHealth : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    //Health
    public float maxHealth = 0;
    public float health = 1000;
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }
    void Die()
    {
        if (health <= 0)
        {
         //   Destroy(PhotonRoomCustomMatch.room.gameObject);
            if (PhotonNetwork.InRoom)
                PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene("Game Over");
        }
    }
    // Update is called once per frame
    void Update()
    {
        Die();
    }
}
