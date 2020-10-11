using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    public string minutes;
    public string seconds;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Menu" || SceneManager.GetActiveScene().name == "Game Over")
            Destroy(this.gameObject);
        else if (SceneManager.GetActiveScene().name == "Scene1")
        {
            t = Time.time - startTime;

            minutes = ((int)t / 60).ToString();
            seconds = (t % 60).ToString("f2");
            DontDestroyOnLoad(this);
        }
    }
}
