using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActive : MonoBehaviour
{

    public void switchText(GameObject buttonText) {
        if (buttonText.activeSelf)
        {
            buttonText.SetActive(false);
        }
        else {
            buttonText.SetActive(true);
        }
    }
    public void switchFalse(GameObject otherButtons1) {
        otherButtons1.SetActive(false);
    }
    public void switchFalse2(GameObject otherButtons2)
    {
        otherButtons2.SetActive(false);
    }
}
