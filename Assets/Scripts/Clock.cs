using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Clock : MonoBehaviour
{
    private GameObject time;
    public Text thisText;
    // Start is called before the first frame update
    void Start()
    {
        time = GameObject.FindWithTag("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        if (time.GetComponent<Timer>().t % 60 < 10)
            thisText.text = "Timer: " + time.GetComponent<Timer>().minutes + ":0" + time.GetComponent<Timer>().seconds;
        else
            thisText.text = "Timer: " + time.GetComponent<Timer>().minutes + ":" + time.GetComponent<Timer>().seconds;
    }
}
