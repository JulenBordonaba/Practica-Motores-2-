using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour {

    public float velocity = 1;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        
	}
	
	// Update is called once per frame
	void Update () {
        rb.velocity = rb.velocity.normalized * velocity;
        if(rb.velocity.magnitude==0)
        {
            RandomDirection();
        }
	}

    public void RandomDirection()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
        Vector2 vel = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized*velocity;
        rb.velocity = new Vector3(vel.x, 0, vel.y);
    }
}
