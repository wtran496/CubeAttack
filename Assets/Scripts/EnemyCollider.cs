using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private GameObject player;
    public int damage = 10;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void OnCollisionEnter(Collision col)
    {      
        if (col.gameObject.tag == "Player")
        {
            player.GetComponent<Player>().health -= damage;
        }
    }
}
