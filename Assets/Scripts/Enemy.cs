using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public Transform playerTransform;

    public GameObject bullet;
    public Transform bulletSpawnPoint;
    private Transform bulletSpawned;
    private Transform pistolHolder;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public void Start()
    {
        timeBtwShots = startTimeBtwShots;
        pistolHolder = this.transform.GetChild(0);
        bulletSpawnPoint = pistolHolder.GetChild(2);

    }
    public void Update()
    {
        Shoot();
    }
    public void Shoot() {
        if (Vector3.Distance(transform.position, playerTransform.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
        else if (Vector3.Distance(transform.position, playerTransform.position) < stoppingDistance && Vector3.Distance(transform.position, playerTransform.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector3.Distance(transform.position, playerTransform.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, -speed * Time.deltaTime);
        }
        if (timeBtwShots < 2)
        {
            bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
            bulletSpawned.rotation = this.transform.rotation;
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
        this.transform.LookAt(playerTransform.transform);
    }
}
