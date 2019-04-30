using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atraer : MonoBehaviour
{
    public float attractionForce = 1;
    public Iman iman;


    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        iman = GetComponent<Iman>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Attract(Rigidbody objectToAttract)
    {
        if (Input.GetButton("Button2" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode)) return;
        Vector3 direction = rb.position - objectToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = attractionForce * (rb.mass * objectToAttract.mass)/Mathf.Clamp(distance/3,0.1f,10f);

        Vector3 force = direction.normalized * forceMagnitude;

        objectToAttract.AddForce(force);
    }

    private void OnTriggerStay(Collider other)
    {
        
            if (other.gameObject.tag == "Atraible")
            {
                if (other.gameObject.GetComponent<Rigidbody>())
                {
                    Attract(other.gameObject.GetComponent<Rigidbody>());
                }
            }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Atraible")
        //{
        //    if(iman!=null)
        //    {
        //        collision.gameObject.GetComponent<Atraer>().enabled = true;
        //        collision.gameObject.GetComponent<Atraer>().iman = this.iman;
        //        collision.gameObject.GetComponent<Atraer>().iman.bolas.Add(collision.gameObject);
        //        collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //        //collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        //        collision.gameObject.transform.parent = iman.gameObject.transform;
                
        //    }

        //}
    }

}
