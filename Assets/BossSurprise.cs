using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSurprise : MonoBehaviour
{
    //Color
    public Color startColor;
    public Color endColor;
    private float colorTimer = 5f;
    private int colorMax = 50;
    private float colorInc = 1f;
    //Spawn
    public GameObject bulletSpawn1;
    public GameObject bulletSpawn2;
    public GameObject bulletSpawn3;
    public GameObject bulletSpawn4;
    public GameObject gun;
    public GameObject melee;
    private GameObject spawnMinion;

    private bool ableDash = true;
    private IEnumerator coroutine;
    private IEnumerator WaitAndMove(float waitTime)
    {
        int rand = Random.Range(0, 360);
        transform.Rotate(0, rand, 0);
        startDistance = 0;
        ableDash = false;
        GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, colorTimer);
        yield return new WaitForSeconds(waitTime);
        ableDash = true;
    }

    //Dash out boss
    private int speed = 2;
    private float startDistance = 0;
    private readonly float maxDistance = 1;

    //health
    public int health = 1000;
    private bool explode = false;
    int exploding = 0;
    // Update is called once per frame
    void Update()
    {
        ColorTime();
        Die();
        if (explode == true) {
            Explode();
        }
        if (startDistance <= maxDistance)
        {            
            Dash();            
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, colorTimer);
            if (ableDash)
            {
                coroutine = WaitAndMove(5f);
                StartCoroutine(coroutine);
            }
        }
    }
    void ColorTime() {
        if (colorTimer <= colorMax)
        {
            colorTimer += colorInc;
        }
        else if (colorTimer > 1)
        {
            colorTimer = 0;
            colorInc += .05f;
            exploding++;
        }
        if (exploding == 30)
            explode = true;

    }
    void Dash() {
        transform.Translate(Vector3.forward * Time.deltaTime * 7f * speed);
        startDistance += 1 * Time.deltaTime;
    }

    void Explode() {
        Randomize();
        Instantiate(spawnMinion.transform, bulletSpawn1.transform.position, bulletSpawn1.transform.rotation);
        Randomize();
        Instantiate(spawnMinion.transform, bulletSpawn2.transform.position, bulletSpawn2.transform.rotation);
        Randomize();
        Instantiate(spawnMinion.transform, bulletSpawn3.transform.position, bulletSpawn3.transform.rotation);
        Randomize();
        Instantiate(spawnMinion.transform, bulletSpawn4.transform.position, bulletSpawn4.transform.rotation);
        Destroy(this.gameObject);
    }
    int RandomizeRotation() {
        return Random.Range(0, 3);
    }
    void Randomize()
    {
        int rand = Random.Range(0, 10);
        if (rand % 2 == 0)
           spawnMinion = gun;
        else
            spawnMinion = melee;
    }

    void Die()
    {
        if (health < 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall" || other.tag == "Player")
        {
          //  startDistance = 999;
            transform.Rotate(0, this.transform.position.y - 180, 0);
        }
    }
}
