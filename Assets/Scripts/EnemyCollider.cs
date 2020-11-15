using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class EnemyCollider : MonoBehaviourPunCallbacks
{
    private GameObject player;
    public int damage = 10;
    public void OnCollisionEnter(Collision col)
    {      
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHealth>().health -= damage;
        }
    }
}
