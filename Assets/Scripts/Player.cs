using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //Movement
    public float movementSpeed = 7;

    //Points
    public float points;

    //Player
    public GameObject playerObj;
    public Rigidbody rigid;

    //Bullet
    public GameObject bulletSpawnPoint;
    public float waitTime;
    public GameObject bullet;
    public bool ableShoot = true;

    //Health
    public float maxHealth;
    public float health = 1000;

    private float jumpForce = 5.0f;
    //test
    public float distToGround = 0.5f;
    //Animation
    //Animator anim;
                                                                                                                                                                                                                                                                                
    bool isGrounded() {  return Physics.Raycast(transform.position, Vector3.down, distToGround);}

    //Bullet Time
    private int bulletLimit = 0;
    private int bulletPause = 0;
    private int bulletSpacing = 0;

    //Audio
    public AudioSource pew;

    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        maxHealth = health;
        //anim = GetComponent<Animator>();
    }

    void Update()
    {
        //Ray checkGround = new Ray(transform.position, -transform.up);
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, -Vector3.up, out hit))
        //{
        //   distToGround = hit.distance;
        //}
        //Debug.Log(isGrounded());
        //print("dist: " + (distToGround) + " , pos.y" + transform.position.y);
        Cam();
        
        if (isGrounded())
        {
            Movement();
            jump();
            Shoot();
        }
        Die();
    }
    void Shoot()
    {
        if (Input.GetMouseButton(0) && ableShoot == true)
        {
            Vector3 clickPosition = -Vector3.one;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                clickPosition = hit.point;
            }
            Debug.Log(clickPosition);

            //if (plane.Raycast(ray, out distance))
            //{
            //    Vector3 target = ray.GetPoint(distance);
            //    Vector3 direction = target - transform.position;
            //    float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            //    transform.rotation = Quaternion.Euler(0, rotation, 0);
            //}
            //anim.SetBool("attacking", true);
            //if (anim.GetBool("running") == true)
            //{
            //    //anim.SetBool("running", false);
            //    anim.SetInteger("condition", 3);
            //}
            //if (anim.GetBool("running") == false)
            //{
            //    anim.SetInteger("condition", 2);
            //}
            if (bulletLimit < 5)
            {
                bulletSpacing++;
                if (bulletSpacing > 5) {
                    bulletLimit++;
                    pew.Play();
                    Instantiate(bullet.transform, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);                 
                    bulletSpacing = 0;
                }
            }
            else {
                bulletPause++;
                if (bulletPause  > 20) {
                    pew.Stop();
                    bulletLimit = 0;
                    bulletPause = 0;
                }
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            pew.Stop();
            bulletLimit = 0;
            bulletPause = 0;
            bulletSpacing = 0;
        }
        //if (Input.GetMouseButtonUp(0))
        //{
        //    anim.SetInteger("condition", 0);
        //    anim.SetBool("attacking", false);
        //}
    }
    
    void jump() {
        if (Input.GetKeyDown(KeyCode.Space))
        {  
            Vector3 jumpVelocity = new Vector3(0f, jumpForce, 0f);
            rigid.velocity = rigid.velocity + jumpVelocity;
            print(this.transform.position);
        }
    }

    void Die()
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    void Cam() {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation = Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 7f * Time.deltaTime);
        }
    }

    void Movement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal * movementSpeed * Time.deltaTime, 0, vertical * movementSpeed * Time.deltaTime);
        rigid.MovePosition(transform.position + movement);

        //if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S))
        //{
        //    anim.SetBool("running", false);
        //    anim.SetInteger("condition", 0);
        //}
    }
}

