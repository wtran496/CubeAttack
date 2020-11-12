using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Transform playerTransform;

    public GameObject bullet;
    public Transform bulletSpawnPoint;
    private Transform bulletSpawned;
    private Transform pistolHolder;

    //public float speed;
    //public float stoppingDistance;
    //public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private int bulletLimit = 0;
    private int bulletPause = 0;
    private int bulletSpacing = 0;

    public void Start()
    {
        timeBtwShots = startTimeBtwShots;
        pistolHolder = this.transform.GetChild(0);
        bulletSpawnPoint = pistolHolder.GetChild(2);
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = GameObject.FindWithTag("Player").transform;
        Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>(), true);

    }
    public void Update()
    {
        Shoot();
    }
    public void Shoot()
    {
        //if (Vector3.Distance(transform.position, playerTransform.position) > stoppingDistance)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        //}
        //else if (Vector3.Distance(transform.position, playerTransform.position) < stoppingDistance && Vector3.Distance(transform.position, playerTransform.position) > retreatDistance)
        //{
        //    transform.position = this.transform.position;
        //}
        //else if (Vector3.Distance(transform.position, playerTransform.position) < retreatDistance)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, -speed * Time.deltaTime);
        //}
        if (bulletLimit < 5)
        {
            bulletSpacing++;
            if (bulletSpacing > 5)
            {
                if (timeBtwShots < 2)
                {
                    bulletLimit++;
                    bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
                    bulletSpawned.rotation = this.transform.rotation;
                    timeBtwShots = startTimeBtwShots;
                    bulletSpacing = 0;
                }
                else
                {
                    timeBtwShots -= Time.deltaTime;
                }
            }
        }
        else
        {
            bulletPause++;
            if (bulletPause > 50)
            {
                bulletLimit = 0;
                bulletPause = 0;
            }
        }

        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(targetPosition);
    }

}
