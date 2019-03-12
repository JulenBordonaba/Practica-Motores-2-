using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despegar : MonoBehaviour {

    public float fuerza;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Ball")
    //    {
    //        rb.AddForce(Vector3.up * fuerza, ForceMode.VelocityChange);
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            rb.AddForce(Vector3.up * fuerza, ForceMode.VelocityChange);
        }
    }
}
