using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class EnemyMelee : MonoBehaviourPunCallbacks
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

    private bool backUp = false;

    // Start is called before the first frame update
    void Start()
    {
        weapon = this.transform.GetChild(0);
        skillIndicator.GetComponent<Image>().enabled = false;
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = GameObject.FindWithTag("Player").transform;
     //   Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>(), true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (backUp) {
        //    Debug.Log("MOVE BACK WORKS");
        //   // MoveBack();
        //}
        Swing();        
        Fading();
        //Running();
    }

    private void Fading()
    {
        if (t <= 1) { //Timer
            t += .05f;
        }
        else if (t > 1 && dashEnabled == false){    
            t = 0;
            dashNow++;      
        }
        if (dashNow == rand) {
            gameObject.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePosition;
            backUp = false;
            skillIndicator.GetComponent<Image>().enabled = false;
            dashEnabled = true;
            Dash();
            
        }
        if (!dashEnabled) //show UI
        {           
            skillIndicator.GetComponent<Image>().enabled = true;
            Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(targetPosition);
        }
        GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, t);
    }

    void Dash() {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * Time.fixedDeltaTime * speed, ForceMode.VelocityChange);
        startDistance += 1 * Time.fixedDeltaTime;
        if (startDistance >= maxDistance) {
            dashNow = 0;
            dashEnabled = false;
            t = 0;
            startDistance = 0;
            rand = Random.Range(2, 10);
        }
    }
    //part of swinging weapon 
    //go toward character
    //private void Running() {
    //    if (Vector3.Distance(transform.position, playerTransform.position) > stoppingDistance)
    //    {
    //        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, speed * Time.fixedDeltaTime);
    //    }
    //}

    private void Swing() {
        weapon.Rotate(0, 196, 0);
    }

    private void MoveBack() {
        gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * Time.fixedDeltaTime * (speed/5), ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision collision)
    {      
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Player") {
        dashNow = 0;
        dashEnabled = false;
        t = 0;
        startDistance = 0;
        rand = Random.Range(2, 10);           
            if (collision.gameObject.tag == "Player")
            {
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;        
            }
        }
        
    }


}
