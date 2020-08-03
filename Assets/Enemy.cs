using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float pointsPlayer = 50;
    public GameObject player;

    public float waitTime;
    private float currentTime;
    private bool shot;

    public GameObject bullet;
    public Transform bulletSpawnPoint;
    private Transform bulletSpawned;
    private Transform pistolHolder;
    

    public void Start()
    {
        player = GameObject.FindWithTag("Player");

        pistolHolder = this.transform.GetChild(0);
        bulletSpawnPoint = pistolHolder.GetChild(2);

    }
    public void Update()
    {
        if (health <= 0) {
            Die();
        }

        this.transform.LookAt(player.transform);

        if (currentTime == 0) {
            Shoot();
        }
        if (shot && currentTime < waitTime) {
            currentTime += 1 * Time.deltaTime;
        }
        if (currentTime >= waitTime) {
            currentTime = 0;
        }
    }

    public void Die() {
        print("Enemy " + this.gameObject.name + " has died!");
        player.GetComponent<Player>().points += pointsPlayer;
        Destroy(this.gameObject);
    }
    public void Shoot() {
        shot = true;
        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.rotation = this.transform.rotation;
    }
}
