using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class DoorTrigger : MonoBehaviourPunCallbacks
{
    public GameObject door;
    public GameObject floor;
    public GameSetup enemyEncounter;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"){
            door.SetActive(true);
            //floor.SetActive(true);
            if (enemyEncounter.GetDoorTrigger() == 0)
            {
                PhotonNetwork.Instantiate(Path.Combine("EnemyPrefabs", "EnemyGun"), new Vector3(1, 1, -14), Quaternion.identity, 0);
                PhotonNetwork.Instantiate(Path.Combine("EnemyPrefabs", "EnemyGun"), new Vector3(45, 1, -14), Quaternion.identity, 0);
            }
            else if (enemyEncounter.GetDoorTrigger() == 1)
            {
                PhotonNetwork.Instantiate(Path.Combine("EnemyPrefabs", "Enemy Melee"), new Vector3(-31, 1, -42), Quaternion.identity, 0);
                PhotonNetwork.Instantiate(Path.Combine("EnemyPrefabs", "Enemy Melee"), new Vector3(-13, 1, -23), Quaternion.identity, 0);
                PhotonNetwork.Instantiate(Path.Combine("EnemyPrefabs", "Enemy Melee"), new Vector3(-31, 1, -23), Quaternion.identity, 0);
            }
            else if (enemyEncounter.GetDoorTrigger() == 2)
            {
                PhotonNetwork.Instantiate(Path.Combine("EnemyPrefabs", "EnemyGun"), new Vector3(-30, 1, 25), Quaternion.identity, 0);
                PhotonNetwork.Instantiate(Path.Combine("EnemyPrefabs", "EnemyGun"), new Vector3(-30, 1, 1), Quaternion.identity, 0);
                PhotonNetwork.Instantiate(Path.Combine("EnemyPrefabs", "EnemyGun"), new Vector3(42, 1, 37), Quaternion.identity, 0);
                PhotonNetwork.Instantiate(Path.Combine("EnemyPrefabs", "EnemyGun"), new Vector3(42, 1, 4), Quaternion.identity, 0);
                PhotonNetwork.Instantiate(Path.Combine("EnemyPrefabs", "Enemy Melee"), new Vector3(17, 1, 18), Quaternion.identity, 0);
                PhotonNetwork.Instantiate(Path.Combine("EnemyPrefabs", "Enemy Melee"), new Vector3(-17, 1, 18), Quaternion.identity, 0);
                PhotonNetwork.Instantiate(Path.Combine("EnemyPrefabs", "Enemy Melee"), new Vector3(1, 1, 9), Quaternion.identity, 0);
                PhotonNetwork.Instantiate(Path.Combine("EnemyPrefabs", "Enemy Melee"), new Vector3(1, 1, 33), Quaternion.identity, 0);
            }
            else {
                Debug.Log("ERROR");
            }
            enemyEncounter.IncDoorTrigger();
            Destroy(this.gameObject);
        }
    }
}
