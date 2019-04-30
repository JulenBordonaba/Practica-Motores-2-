using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerComida : MonoBehaviour {
    bool eatable;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
            print("There is something in front of the object!");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(transform.tag=="comida"&& Input.GetButtonDown("Fire1") && eatable==true)
        {
            eatable = false;
            //Destroy(comida)
        }
    }
}
