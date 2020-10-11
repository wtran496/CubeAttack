using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLink : MonoBehaviour
{
    private Transform link;
    private GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        link = this.transform.GetChild(0);
        boss = GameObject.FindGameObjectWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(this.transform.position, boss.transform.position);
        link.transform.localScale = new Vector3(dist/5, .2f, .2f);

        Vector3 targetPosition = new Vector3(boss.transform.position.x, transform.position.y, boss.transform.position.z);
        transform.LookAt(targetPosition);
    }
}
