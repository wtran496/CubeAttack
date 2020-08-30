using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSurprise : MonoBehaviour
{
    //Color
    public Color startColor;
    public Color endColor;
    private float colorTimer = 1f;

    //Spawn
    public GameObject bulletSpawn1;
    public GameObject bulletSpawn2;
    public GameObject bulletSpawn3;
    public GameObject bulletSpawn4;
    public GameObject gun;
    public GameObject melee;
    private GameObject spawnMinion;

    //Dash out boss
    private int speed;
    private float startDistance = 0;
    private readonly float maxDistance = 2;

    //health
    public int health = 1000;
    // Update is called once per frame
    void Update()
    {
        Die();
        if (colorTimer == 0) {
            Explode();
        }
        if (startDistance >= maxDistance)
            Dash();
        else
        {
            GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, colorTimer);
            colorTimer -= .05f;
        }
    }

    void Dash() {
        transform.Translate(Vector3.forward * Time.deltaTime * 7f * speed);
        startDistance += 1 * Time.deltaTime;
    }

    void Explode() {
        Instantiate(spawnMinion.transform, bulletSpawn1.transform.position, bulletSpawn1.transform.rotation);
        Instantiate(spawnMinion.transform, bulletSpawn2.transform.position, bulletSpawn2.transform.rotation);
        Instantiate(spawnMinion.transform, bulletSpawn3.transform.position, bulletSpawn3.transform.rotation);
        Instantiate(spawnMinion.transform, bulletSpawn4.transform.position, bulletSpawn4.transform.rotation);
        Destroy(this.gameObject);
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
        if (health > 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            startDistance = 999;
        }
    }
}
