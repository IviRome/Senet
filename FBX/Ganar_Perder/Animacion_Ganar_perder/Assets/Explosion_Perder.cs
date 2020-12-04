using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Perder : MonoBehaviour
{
    // Start is called before the first frame update
    public float minForce;

    public float maxForce;

    public float radius;

    public float DestroyDelay;

    void Start()
    {

        Explode();
    }

    public void Explode()
    {
        foreach(Transform t in transform)
        {
            var rb = t.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(Random.Range(minForce,maxForce),transform.position,radius );
            }
            Destroy(t.gameObject, DestroyDelay);
        }
        
    }
}
