using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empuje : MonoBehaviour {

    
    public float pushForce = 1;
    public bool bajarMasa = true;

    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            if(bajarMasa)
            {
                rb.mass -= Mathf.Clamp(rb.mass - 1f, 0.1f, float.MaxValue);
            }
            

        }
        else if (collision.gameObject.tag == "Player")
        {
            Vector3 force = (transform.position - collision.transform.position).normalized * pushForce;

            rb.AddForce(force, ForceMode.VelocityChange);
            if (bajarMasa)
            {
                rb.mass -= Mathf.Clamp(rb.mass - 1f, 0.1f, float.MaxValue);
            }
            collision.gameObject.GetComponent<Rigidbody>().AddForce(-force, ForceMode.VelocityChange);
            collision.gameObject.GetComponent<Rigidbody>().mass -= Mathf.Clamp(rb.mass - 1f, 0.1f, float.MaxValue);
        }
    }
}
