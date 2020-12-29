﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class EnemyHealth : MonoBehaviourPunCallbacks
{
    public float maxHealth;
    public float health = 5000;
    public float pointsPlayer = 50;
    private GameObject player;
    private Boss1 boss;
    private Doors door;
    // private GameObject bossObject;
    private void Start()
    {
        maxHealth = health;
        boss = FindObjectOfType<Boss1>();
        door = FindObjectOfType<Doors>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        door.doorCheck++;
        if (this.tag == "Boss Minion")
        {
            boss.minionLimit--;
            Debug.Log(boss.minionLimit);
        }
        if (this.tag == "Boss") {
            SceneManager.LoadScene("Win");
        }
        PhotonNetwork.Destroy(this.gameObject);
    }
}
