using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSetup : MonoBehaviour
{
    public static GameSetup GS;
    public Transform[] spawnPoints;

    public Camera myCamera;

    private void Awake()
    {
        GameSetup.GS = this;
    }
    private void OnEnable()
    {
        if (GameSetup.GS == null) {
            GameSetup.GS = this;
        }
    }
}
