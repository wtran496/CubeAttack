using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSetup : MonoBehaviour
{
    public static GameSetup GS;
    public Transform[] spawnPoints;
    public int doorTrigger = 0;
    public Camera myCamera;

    public int GetDoorTrigger() {
        return doorTrigger;
    }

    public void IncDoorTrigger() {
        doorTrigger++;
    }
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
