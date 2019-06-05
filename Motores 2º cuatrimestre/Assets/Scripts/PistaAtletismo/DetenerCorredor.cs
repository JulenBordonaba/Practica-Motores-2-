using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetenerCorredor : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag =="GameEnd") gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "GameEnd") gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
