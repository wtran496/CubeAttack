using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public Slider playerSlider3D;
    Slider playerSlider2D;

    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        playerSlider2D = GetComponent<Slider>();
        playerSlider2D.maxValue = player.health;
        playerSlider3D.maxValue = player.health;
    }

    // Update is called once per frame
    void Update()
    {
        playerSlider2D.value = player.health;
        playerSlider3D.value = playerSlider2D.value;
    }
}
