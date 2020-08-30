using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotateShoot : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    private Transform bulletSpawned;
    public GameObject bullet;

    private float timeBtwShots = 0;
    public float startTimeBtwShots = 0;
    private float speed = 3f;

    void Update() {
        transform.Rotate(0, 50 * Time.deltaTime * speed, 0);
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
    }
}
