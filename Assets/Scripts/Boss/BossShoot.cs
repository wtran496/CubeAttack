using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    private GameObject player;
    private IEnumerator coroutine;
    private IEnumerator WaitAndPrint(float waitTime)
    {
        ableShoot = false;
        yield return new WaitForSeconds(waitTime);
        Shoot();
        
        ableShoot = true;
    }

    private Transform bulletSpawnPoint;
    public GameObject bulletBomb;
    
    bool ableShoot = true;

    private void Start()
    {
        bulletSpawnPoint = this.transform.GetChild(0);
        player = GameObject.FindWithTag("Player");
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void Update()
    {
        if (ableShoot)
        {
            coroutine = WaitAndPrint(.15f);
            StartCoroutine(coroutine);
        }
        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(targetPosition);
    }

    private void Shoot() {
        bulletSpawnPoint.transform.localRotation = Quaternion.Euler(bulletSpawnPoint.transform.rotation.x, bulletSpawnPoint.transform.rotation.y-Arc(), bulletSpawnPoint.transform.rotation.z);
        Instantiate(bulletBomb.transform, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
    }

    private int Arc() {

        return Random.Range(-65, 65);
    }

}
