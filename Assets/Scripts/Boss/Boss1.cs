using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    private GameObject player;
    private Transform playerTransform;
    public  int minionLimit = 0;  

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
    public Transform bossSpawn;
    public GameObject[] bossMinions;

    private float timeBtwShots = 0;
    public float startTimeBtwShots = 1000f;
    int randBullet;

    private IEnumerator ToMiddle(float waitTime)
    {
        atMiddle = false;
        yield return new WaitForSeconds(waitTime);
        atMiddle = true;
    }
    public Transform middle;
    private bool atMiddle = true;

    //health
    public EnemyHealth hp;

    // Start is called before the first frame update
    void Start()
    {
        skillIndicator.GetComponent<Image>().enabled = false;
        player = GameObject.FindWithTag("Player");
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp.health < hp.maxHealth / 2 && atMiddle)
            Fading();
        else
            Spinning();
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
      //  GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
    }

    private void moveTowards() {
        transform.position = Vector3.MoveTowards(transform.position, middle.position, speed * Time.deltaTime);
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
 

    void Randomize()
    {
        randBullet = Random.Range(0, 50);
        if (randBullet == 1)
            placeBullet = bulletBoss;
        else
            placeBullet = bullet;
    }

    void Spinning()
    {
        transform.Rotate(0, 10 * Time.deltaTime * speed, 0);

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

        if (!atMiddle) {
            moveTowards();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            dashNow = 0;
            dashEnabled = false;
            t = 0;
            startDistance = 0;
            if (minionLimit < 3)
            {
                Instantiate(bossMinions[Random.Range(0, 3)].transform, bossSpawn.transform.position, bossSpawn.transform.rotation);
                minionLimit++;
                startTimeBtwShots += .05f;
            }
            else {
                StartCoroutine(ToMiddle(50f));
                skillIndicator.GetComponent<Image>().enabled = false;
            }
        }
    }
}
