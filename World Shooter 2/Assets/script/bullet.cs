using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 50;
    public float flyTime = 3;

    Rigidbody rb;


    void Update()
    {
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(transform.forward * speed , ForceMode.VelocityChange);
        rb.AddForce(transform.forward * speed);
        Invoke("DestroyBullet", flyTime);
    }



    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
