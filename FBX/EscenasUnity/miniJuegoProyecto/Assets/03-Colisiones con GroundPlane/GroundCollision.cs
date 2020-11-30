using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{

    Rigidbody rb;

    Material material;

    Vector3 startPos;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        material = GetComponent<Renderer>().material;
        //startPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Suelo"))
        {
            material.color = Random.ColorHSV();
        }
    }

    public void Init()
    {
        Vector3 t = transform.position;
        t.y += .4f;
        transform.position = t;
        rb.isKinematic = false;
    }
}
