using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rushing : MonoBehaviour
{
    public int frequency = 5;
    public float distanceRand = .2f;

    private float startDistance = 0;
    private float maxDistance = 1f;
    private bool ableDash = true;
    private int speed = 9;
    private int rand = 1;
    private bool randWall = false;
    private IEnumerator coroutine;
    private IEnumerator WaitAndMove(float waitTime)
    {
        ableDash = false;
        yield return new WaitForSeconds(waitTime);
        startDistance = 0;
        maxDistance = Random.Range(1, 3);
        speed = Random.Range(12, 15);
        distanceRand = Random.Range(.03f, .05f);
        ableDash = true;
        if (randWall == true)
        {
            if (rand % 2 == 0) {
                rand++;
            }
            else {
                rand--; }
            randWall = false;
        }
        else
        {
            rand = Random.Range(0, 4);
        }       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (startDistance <= maxDistance)
        {
            Dash();
        }
        else
        {
            if (ableDash)
            {
                coroutine = WaitAndMove(Random.Range(1,frequency));
                StartCoroutine(coroutine);
            }
        }
    }
    void Dash()
    {
        switch (rand)
        {           
            case 0:
                gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * .5f, ForceMode.VelocityChange);
                break;
            case 1:
                gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * .5f, ForceMode.VelocityChange);
                break;
            case 2:
                gameObject.GetComponent<Rigidbody>().AddRelativeForce(-.5f, 0, 0);
                break;
            case 3:
                gameObject.GetComponent<Rigidbody>().AddRelativeForce(.5f, 0, 0);
                break;
            default:
                Debug.Log("Rushing Script Default Error");
                break;
        };
        startDistance += distanceRand;
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Wall")
        {
            startDistance = 999;
            randWall = true;
        }
        if (col.gameObject.tag == "Player") {
            startDistance = 999;
        }
    }

}
