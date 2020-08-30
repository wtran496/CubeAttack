using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    public GameObject player;
    public Transform playerTransform;

    public float stoppingDistance;
    public float speed;
    public float maxDistance;
    public float startDistance;

    public Color startColor;
    public Color endColor;
    private float t = 0;
    private float dashNow = 0;
    private bool dashEnabled = false;
    public Image skillIndicator;

    public Transform bulletSpawnPoint1;
    public Transform bulletSpawnPoint2;
    public Transform bulletSpawnPoint3;
    public Transform bulletSpawnPoint4;
    public GameObject bullet;
    public GameObject bulletBoss;
    private GameObject placeBullet;

    private float timeBtwShots;
    public float startTimeBtwShots;
    int randBullet;
    // Start is called before the first frame update
    void Start()
    {
        skillIndicator.GetComponent<Image>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Running();
        //Fading();
    }
    private void Fading()
    {
        if (t <= 1)
        {
            t += .05f;
        }
        else if (t > 1 && dashEnabled == false)
        {
            t = 0;
            dashNow++;
        }
        if (dashNow == 3)
        {
            skillIndicator.GetComponent<Image>().enabled = false;
            dashEnabled = true;
            Dash();
        }
        if (!dashEnabled)
        {
            skillIndicator.GetComponent<Image>().enabled = true;
            Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(targetPosition);
        }
        GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
    }
    void Dash()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 7f * speed);
        startDistance += 1 * Time.deltaTime;
        if (startDistance >= maxDistance)
        {
            dashNow = 0;
            dashEnabled = false;
            t = 0;
            startDistance = 0;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<Player>().health -= 10;
        }
        if (other.tag == "Wall")
        {
            dashNow = 0;
            dashEnabled = false;
            t = 0;
            startDistance = 0;
        }
    }

    void Randomize()
    {
        randBullet = Random.Range(0, 10);
        if (randBullet == 1)
            placeBullet = bulletBoss;
        else
            placeBullet = bullet;
    }

    void Running()
    {
        transform.Rotate(0, 10 * Time.deltaTime * speed, 0);
        //if (Vector3.Distance(transform.position, playerTransform.position) > stoppingDistance)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, transform.position, speed * Time.deltaTime);
        //}

        if (timeBtwShots < 0)
        {
            
            Randomize(); 
            Instantiate(placeBullet.transform, bulletSpawnPoint1.transform.position, bulletSpawnPoint1.transform.rotation);
            Randomize();
            Instantiate(placeBullet.transform, bulletSpawnPoint2.transform.position, bulletSpawnPoint2.transform.rotation);
            Randomize();
            Instantiate(placeBullet.transform, bulletSpawnPoint3.transform.position, bulletSpawnPoint3.transform.rotation);
            Randomize();
            Instantiate(placeBullet.transform, bulletSpawnPoint4.transform.position, bulletSpawnPoint4.transform.rotation);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

}
