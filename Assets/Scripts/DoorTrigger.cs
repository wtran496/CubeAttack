using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject door;
    public GameObject floor;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){
            door.SetActive(true);
            floor.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
