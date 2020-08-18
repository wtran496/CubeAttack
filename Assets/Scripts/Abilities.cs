using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Abilities : MonoBehaviour
{
    [Header("Ability 1")]
    public Image abilityImage1;
    public float cooldown1 = 5;
    bool isCooldown = false;
    public KeyCode ability1;

    //Ability 1 prefab variables
    public GameObject bulletSpawnPoint;
    public GameObject rocket;
    public Player body;

    //Ability 1 delay
    private IEnumerator coroutine;
    private IEnumerator WaitAndPrint(float waitTime)
    {     
        yield return new WaitForSeconds(waitTime);
        body.ableShoot = true;
    }

    //Ability 1 Input Variables
    Vector3 position;
    public Canvas ability1Canvas;
    public Image skillshot;
    public Transform player;

    [Header("Ability 2")]
    public Image abilityImage2;
    public float cooldown2 = 5;
    bool isCooldown2 = false;
    public KeyCode ability2;

    //Ability 2 Input Variables
    bool isDash = false;
    private IEnumerator speedCoroutine;
    private IEnumerator SpeedUp(float waitTime)
    {
        body.movementSpeed = 20f;
        yield return new WaitForSeconds(waitTime);
        body.movementSpeed = 7f;
        isCooldown2 = true;
        abilityImage2.fillAmount = 1;
        isDash = false;
    }
    

    [Header("Ability 3")]
    public Image abilityImage3;
    public float cooldown3 = 5;
    bool isCooldown3 = false;
    public KeyCode ability3;

    //Ability 3 Input Variables
    public Image targetCircle;
    public Image indicatorRangeCircle;
    public Canvas ability3Canvas;
    private Vector3 posUp;
    public float maxAbility2Distance;

    //Ability 3 variables
    public GameObject bomb;

    private void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;

        skillshot.GetComponent<Image>().enabled = false;
        targetCircle.GetComponent<Image>().enabled = false;
        indicatorRangeCircle.GetComponent<Image>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        Ability1();
        Ability2();
        Ability3();

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Ability 1 & 2 Inputs
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
        }

        //Ability 3 Inputs
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            posUp = new Vector3(hit.point.x, 10f, hit.point.z);
            position = hit.point;
        }
        
        Quaternion transRot = Quaternion.LookRotation(position - player.transform.position);
        transRot.eulerAngles = new Vector3(0, transRot.eulerAngles.y, transRot.eulerAngles.z);

        //Ability 1 Canvas Inputs
        ability1Canvas.transform.rotation = Quaternion.Lerp(transRot, ability1Canvas.transform.rotation, 0f);

        //Ability 3 Canvas Inputs
        var hitPosDir = (hit.point - transform.position).normalized;
        float distance = Vector3.Distance(hit.point, transform.position);
        distance = Mathf.Min(distance, maxAbility2Distance);
        var newHitPos = transform.position + hitPosDir * distance;
        ability3Canvas.transform.position = (newHitPos);
    }

    void Ability1()
    {
        if (Input.GetKey(ability1) && isCooldown == false)
        {
            skillshot.GetComponent<Image>().enabled = true;
            body.ableShoot = false;

            //Disable other UI
            indicatorRangeCircle.GetComponent<Image>().enabled = false;
            targetCircle.GetComponent<Image>().enabled = false;
        }

        if (skillshot.GetComponent<Image>().enabled == true && Input.GetMouseButtonDown(0))
        {           
            isCooldown = true;
            abilityImage1.fillAmount = 1;
            Blast();
            coroutine = WaitAndPrint(0.5f);
            StartCoroutine(coroutine);        
        }

        if (isCooldown)
        {
            
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;
            skillshot.GetComponent<Image>().enabled = false;

             if (abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    void Blast() {
        //WORK ON POSITION
        Instantiate(rocket.transform, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
        // how much the character should be knocked back
        //body.rigid.AddForce(5000, 0);
        //transform.position = new Vector3(-15.0f, 0.0f, 0.0f);
        //body.rigid.MovePosition(transform.position + transform.right * Time.fixedDeltaTime);
        //body.rigid.AddForce(-11f, 0, 0);
    }

    void Ability2()
    {
        if (Input.GetKey(ability2) && isCooldown2 == false && !isDash)
        {
            isDash = true;
            Dash();
            //Disable other UI
            skillshot.GetComponent<Image>().enabled = false;
            indicatorRangeCircle.GetComponent<Image>().enabled = false;
            targetCircle.GetComponent<Image>().enabled = false;
        }

        if (isCooldown2)
        {
            abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;
            if (abilityImage2.fillAmount <= 0)
            {
                abilityImage2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }

    void Dash() {
        StartCoroutine(SpeedUp(2f));  
    }

    void Ability3()
    {
        if (Input.GetKey(ability3) && isCooldown3 == false)
        {
            indicatorRangeCircle.GetComponent<Image>().enabled = true;
            targetCircle.GetComponent<Image>().enabled = true;
           
            //Disable Skillshot UI
            skillshot.GetComponent<Image>().enabled = false;
        }

        if (targetCircle.GetComponent<Image>().enabled == true && Input.GetMouseButtonDown(0)) {
            isCooldown3 = true;
            abilityImage3.fillAmount = 1;
            Explosion();
            coroutine = WaitAndPrint(0.5f);
            StartCoroutine(coroutine);
        }

        if (isCooldown3)
        {
            abilityImage3.fillAmount -= 1 / cooldown3 * Time.deltaTime;

            indicatorRangeCircle.GetComponent<Image>().enabled = false;
            targetCircle.GetComponent<Image>().enabled = false;

            if (abilityImage3.fillAmount <= 0)
            {
                abilityImage3.fillAmount = 0;
                isCooldown3 = false;
            }
        }
    }

    void Explosion() {
        Instantiate(bomb.transform, bulletSpawnPoint.transform.position, bulletSpawnPoint.transform.rotation);
    }
}