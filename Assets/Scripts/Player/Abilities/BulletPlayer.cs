using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class BulletPlayer : MonoBehaviourPunCallbacks
{
    public float speed;
    float startDistance = 0;
    public float maxDistance = 5;
    private GameObject triggeringEnemy;
    public float damage;

    // Update is called once per frame
    void Update()
    {
        BulletDistance();       
    }

    void BulletDistance() {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        startDistance += 1 * Time.deltaTime;
        if (startDistance >= maxDistance)
            PhotonNetwork.Destroy(this.gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Boss" || other.tag == "Boss Minion")
        {
            triggeringEnemy = other.gameObject;
            triggeringEnemy.GetComponent<EnemyHealth>().health -= damage;
            PhotonNetwork.Destroy(this.gameObject);
        }
        if (other.tag == "Wall")
        {
            PhotonNetwork.Destroy(this.gameObject);
        }
    }
}
