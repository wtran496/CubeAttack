using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderContinuous : MonoBehaviour
{
    private GameObject player;
    public int damage = 10;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<PlayerHealth>().health -= damage;
        }
    }
}
