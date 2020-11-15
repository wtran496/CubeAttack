using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class Health : MonoBehaviour
{   
    [SerializeField]
    private Slider playerSlider3D = null;
    private Slider playerSlider2D = null;
    [SerializeField]
    private GameObject player;

    private void Start()
    {
            playerSlider2D = GetComponent<Slider>();
            playerSlider2D.maxValue = player.GetComponent<PlayerHealth>().health;
            playerSlider3D.maxValue = player.GetComponent<PlayerHealth>().health;
    }
    // Update is called once per frame
    void Update()
    {
        if (playerSlider3D != null)
        {
            playerSlider2D.value = player.GetComponent<PlayerHealth>().health;
            playerSlider3D.value = playerSlider2D.value;
        }
    }
}
