using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class Health : MonoBehaviour
{
    public Slider playerSlider3D;
    public Slider playerSlider2D = null;
    //PhotonView photonView;
    private GameObject player;
   // public Player player;
    // Start is called before the first frame update
    //void Start()
    //{
    //    //photonView = GetComponent<PhotonView>();
    //    //if (photonView.IsMine)
    //    //{
    //        StartHealth();
    //   // }
    //}
    //[PunRPC]
    //void StartHealth() {
    //    playerSlider2D = GetComponent<Slider>();
    //    player = GameObject.FindGameObjectWithTag("Player");
    //    playerSlider2D.maxValue = player.GetComponent<PlayerHealth>().health;
    //    playerSlider3D.maxValue = player.GetComponent<PlayerHealth>().health;
    //}
    // Update is called once per frame
    void Update()
    {
        if (playerSlider2D != null)
        {
            Debug.Log("HEALTH HERE");
            playerSlider2D.value = player.GetComponent<PlayerHealth>().health;
            playerSlider3D.value = playerSlider2D.value;
        }
    }
}
