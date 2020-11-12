using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBoss : MonoBehaviour
{
    private float speed = 2;
    private float startDistance = 0;
    private float maxDistance = 2;
    private float damage = 10;
    private GameObject player;
    private int state = 0;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 7f * speed);
        startDistance += 1 * Time.deltaTime;
        if (startDistance >= maxDistance)
        {
            state++;
            if (state == 2)
            {
                Destroy(this.gameObject);
            }
            Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(targetPosition);
            maxDistance = 6;
            speed = 5;
            startDistance = 0;
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<PlayerHealth>().health -= damage;
            Destroy(this.gameObject);
        }
        if (other.tag == "Wall") {
            Destroy(this.gameObject);
        }
    }
}
