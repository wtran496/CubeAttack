using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float speed;
    float startDistance = 0;
    public float maxDistance = 5;
    public float damage;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 7f * speed);
        startDistance += 1 * Time.deltaTime;
        if (startDistance >= maxDistance) {
            Destroy(this.gameObject);
        }
            
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //player = GameObject.FindWithTag("Player");
            other.GetComponent<PlayerHealth>().health -= 10;
            Destroy(this.gameObject);     
        }
        if (other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
