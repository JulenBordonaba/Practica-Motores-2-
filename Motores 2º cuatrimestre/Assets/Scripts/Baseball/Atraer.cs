using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atraer : MonoBehaviour
{
    public float attractionForce = 1;


    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Attract(Rigidbody objectToAttract)
    {
        Vector3 direction = rb.position - objectToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = attractionForce * (rb.mass * objectToAttract.mass) / Mathf.Pow(distance, 2);

        Vector3 force = direction.normalized * forceMagnitude;

        objectToAttract.AddForce(force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetButton("Button1" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode))
        {
            if (other.gameObject.tag == "Atraible")
            {
                if (other.gameObject.GetComponent<Rigidbody>())
                {
                    Attract(other.gameObject.GetComponent<Rigidbody>());
                }
            }
        }
            
    }

}
