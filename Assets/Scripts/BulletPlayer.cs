using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : MonoBehaviour
{
    public float speed;
    float startDistance = 0;
    public float maxDistance = 5;
    private GameObject triggeringEnemy;
    public float damage;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 7f * speed);
        startDistance += 1 * Time.deltaTime;
        if (startDistance >= maxDistance)
            Destroy(this.gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Boss" || other.tag == "Boss Minion")
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<EnemyHealth>().health -= damage;
            Destroy(this.gameObject);
        }
        if (other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
