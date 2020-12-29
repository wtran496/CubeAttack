using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;
    public GameObject door4;
    public int doorCheck = 0;
    // Update is called once per frame
    void Update()
    {
        //MAKE ENEMIES ON FLOOR
        if (doorCheck == 2)
        {
            door2.SetActive(false); 
            doorCheck++;
        }
        if (doorCheck == 6) {
            door3.SetActive(false);
            doorCheck++;
        }
        if (doorCheck == 15)
        {
            door4.SetActive(false);
            doorCheck++;
        }
    }
}
