using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{

    private Rigidbody rb;
       
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 10f); //El objeto despawneara a los 10 segundos
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-2, 2), Random.Range(2, 4), Random.Range(-2, 2)); //El objeto al espawnear ira en una direccion random
    }

    // Update is called once per frame
    void Update()
    {

    }
}
