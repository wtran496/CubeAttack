using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleActive : MonoBehaviour
{
    public GameObject Help1;
    public GameObject Help2;
    public GameObject Help3;
    public GameObject title;
    // Update is called once per frame
    void Update()
    {
        if (!Help1.activeSelf && !Help2.activeSelf && !Help3.activeSelf)
        {
            title.SetActive(true);
        }
        else {
            title.SetActive(false);
        }
    }
}
