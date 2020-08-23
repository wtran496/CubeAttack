using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float pointsPlayer = 50;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        print("Enemy " + this.gameObject.name + " has died!");
        player.GetComponent<Player>().points += pointsPlayer;
        Destroy(this.gameObject);
    }
}
