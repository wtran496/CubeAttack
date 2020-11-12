using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class PlayerHealth : MonoBehaviourPunCallbacks
{
    //Health
    public float maxHealth = 0;
    public float health = 1000;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }
    void Die()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
    // Update is called once per frame
    void Update()
    {
        Die();
    }
}
