using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMusic : MonoBehaviour
{
    public AudioClip newTrack;

    private Musical theAM;
    // Start is called before the first frame update
    void Start()
    {
        theAM = FindObjectOfType<Musical>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            if (newTrack != null) {
                theAM.ChangeBGM(newTrack);
            }
        }
    }
}
