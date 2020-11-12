using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerShoot1 : MonoBehaviourPunCallbacks
{
    //Bullet
    [SerializeField]
    private GameObject bulletSpawnPoint = null;
    [SerializeField]
    public GameObject bullet = null;
    [SerializeField]
    private CharacterController controller = null;
    private bool groundedPlayer;

    //Duration and Able to hit
    public float waitTime; 
    public bool ableShoot = true;
    //Bullet Time
    private int bulletLimit = 0;
    private int bulletPause = 0;
    private int bulletSpacing = 0;
    
    //Bullet Audio
    private AudioSource audioBullet = null;
    // Update is called once per frame
    private void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        audioBullet = audios[0];
    }
    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer)
            Shoot();
    }
    void Shoot()
    {
        if (Input.GetMouseButton(0) && ableShoot == true)
        {
            Vector3 clickPosition = -Vector3.one;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            audioBullet.clip = (AudioClip)Resources.Load("Sounds/Bullet");

            if (Physics.Raycast(ray, out hit))
            {
                clickPosition = hit.point;
            }
            Debug.Log(clickPosition);

            if (bulletLimit < 5)
            {
                bulletSpacing++;
                if (bulletSpacing > 5)
                {
                    bulletLimit++;               
                    audioBullet.Play();
                    Instantiate(bullet.transform, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
                    bulletSpacing = 0;
                }
            }
            else
            {
                bulletPause++;
                if (bulletPause > 20)
                {
                    audioBullet.Stop();
                    bulletLimit = 0;
                    bulletPause = 0;
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            audioBullet.Stop();
            bulletLimit = 0;
            bulletPause = 0;
            bulletSpacing = 0;
        }
    }
}
