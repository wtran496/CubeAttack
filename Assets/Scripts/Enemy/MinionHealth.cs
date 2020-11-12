using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinionHealth : MonoBehaviour
{
    public EnemyHealth enemy;
    public Slider enemySlider2D;
    void Start()
    {
        enemySlider2D.maxValue = enemy.health;
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        transform.Rotate(0, 180, 0);
        enemySlider2D.value = enemy.health;
    }
}
