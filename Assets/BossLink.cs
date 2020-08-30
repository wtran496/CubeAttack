using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLink : MonoBehaviour
{
    private Transform link;
    public GameObject boss;
   
    // Start is called before the first frame update
    void Start()
    {
        link = this.transform.GetChild(0);   
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 centerPos = new Vector3(0, 0, (-10));
        //link.transform.position = centerPos;

        float scaleY = Mathf.Abs(transform.position.y + boss.transform.position.y);
        link.transform.localScale = new Vector3(.2f, scaleY, .2f);

        Vector3 targetPosition = new Vector3(boss.transform.position.x, transform.position.y, boss.transform.position.z);
        transform.LookAt(targetPosition);
    }
}
