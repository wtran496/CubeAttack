using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerBomb : MonoBehaviourPunCallbacks
{
    public float damage;
    public float radius = 5f;
    public float force = 500f;
    private GameObject triggeringEnemy;
    protected float Animation;
    public float delay = 3f;
    RaycastHit hit;
    Ray ray;
    bool ableMouse = true;
    Vector3 clickPosition = -Vector3.one;

    private IEnumerator WaitToDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Explode();
    }
    void FixedUpdate()
    {
        print("PlayerBomb: "+ this.transform.position);
        Animation += Time.deltaTime;
        Animation = Animation % 1f;
        if (ableMouse)
            MousePosition();
        ableMouse = false;
        if (Physics.Raycast(ray, out hit))
        {
            clickPosition = hit.point;
        }
        Vector3 limitRange = Vector3.ClampMagnitude(clickPosition, 1f);
        transform.position = MathParabola.Parabola(this.transform.position, clickPosition, 2f, Animation / 1f);
        StartCoroutine(WaitToDestroy(.8f));
    }

    void MousePosition() {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            EnemyHealth rb = nearbyObject.GetComponent<EnemyHealth>();
            if (rb != null)
            {
                rb.health -= 100;
            }
        }
        PhotonNetwork.Destroy(this.gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Boss" || other.tag == "Boss Minion") {
            Explode();
        }
    }
}
