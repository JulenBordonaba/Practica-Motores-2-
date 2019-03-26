using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollisionType
{
    trigger,collision
}

public class Despegar : MonoBehaviour {

    public float fuerza;
    public string collisionTag = "";
    public CollisionType collisionType;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (collisionType != CollisionType.trigger) return;
        if (other.tag == collisionTag)
        {
            rb.AddForce(Vector3.up * fuerza, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collisionType != CollisionType.collision) return;
        if (collision.gameObject.tag == collisionTag)
        {
            rb.AddForce(Vector3.up * fuerza, ForceMode.VelocityChange);
        }
    }
}
