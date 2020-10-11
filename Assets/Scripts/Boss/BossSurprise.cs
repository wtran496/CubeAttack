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

    //Explosion
    private bool explode = false;
    int exploding = 0;

    // Update is called once per frame
    void Update()
    {
        ColorTime();
        if (explode == true) {
            Explode();
        }
        GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, colorTimer);
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
        if (exploding == 15)
            explode = true;
    }
  
    void Explode() {
        Randomize();       
        Randomize();
        Randomize();
        Randomize();
        Destroy(this.gameObject);
    }

    void Randomize()
    {
        int rand = Random.Range(0, 10);
        if (rand % 2 == 0)
           spawnMinion = gun;
        else
            spawnMinion = melee;
        Instantiate(spawnMinion.transform, bulletSpawn1.transform.position, bulletSpawn1.transform.rotation);
    }
}
