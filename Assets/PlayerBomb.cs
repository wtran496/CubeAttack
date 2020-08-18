using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBomb : MonoBehaviour
{
    public float damage;
    public float radius = 5f;
    public float force = 500f;
    private GameObject triggeringEnemy;
    protected float Animation;
    public float delay = 3f;
    //bool hasExploded = false;
    private IEnumerator coroutine;
    private IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
    private IEnumerator WaitToDestroy(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Explode();
    }
    void Update()
    {
        print(this.transform.position);
        Animation += Time.deltaTime;
        Animation = Animation % 1f;
        transform.position = MathParabola.Parabola(this.transform.position, this.transform.position * 5f, 5f, Animation / 1f);
        StartCoroutine(WaitToDestroy(.95f));
    }

    void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders) {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();           
                if (rb != null) {
                rb.AddExplosionForce(force, transform.position, radius);
            }
        }
        Destroy(this.gameObject);
    }

}
