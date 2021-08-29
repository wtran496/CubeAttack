using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColliderContinuous : MonoBehaviour
{
    public int damage = 10;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().health -= damage;
        }
    }
}
