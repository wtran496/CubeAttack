using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Slider bossSlider;
    public GameObject bossHealth;
    public EnemyHealth boss;
    // Start is called before the first frame update
    void Start()
    {
        bossHealth.SetActive(true);
        bossSlider.maxValue = boss.health;
    }

    // Update is called once per frame
    void Update()
    {       
       bossSlider.value = boss.health; 
    }
}
