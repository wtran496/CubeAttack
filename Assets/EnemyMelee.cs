﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMelee : MonoBehaviour
{
    private GameObject player;
    private Transform playerTransform;

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

    private Transform weapon;
    private int rand = 6;
    // Start is called before the first frame update
    void Start()
    {
        weapon = this.transform.GetChild(0);
        skillIndicator.GetComponent<Image>().enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Swing();
        Fading();
        //Running();
    }

    private void Fading()
    {
        if (t <= 1) {
            t += .05f;
        }
        else if (t > 1 && dashEnabled == false){
            
            t = 0;
            dashNow++;
        }
        if (dashNow == rand) {
            //GetComponent<Collider>().isTrigger = true;
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

    void Dash() {
        
        //rb.AddForce((playerTransform.position - transform.position) * speed);
        transform.Translate(Vector3.forward * Time.deltaTime * 7f * speed);
        startDistance += 1 * Time.deltaTime;
        if (startDistance >= maxDistance) {
            dashNow = 0;
            dashEnabled = false;
            t = 0;
            startDistance = 0;
            rand = Random.Range(0, 10);
            // GetComponent<Collider>().isTrigger = false;
        }
    }
    //part of swinging weapon 
    //go toward character
    void Running() {
        if (Vector3.Distance(transform.position, playerTransform.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, -speed * Time.deltaTime);
        }
        else {
            Swing();
        }

    }
    void Swing() {
        weapon.Rotate(0, 196, 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<Player>().health -= 10;
        }
        if (other.tag == "Wall") {
            dashNow = 0;
            dashEnabled = false;
            t = 0;
            startDistance = 0;
           // GetComponent<Collider>().isTrigger = false;
        }
    }

}
