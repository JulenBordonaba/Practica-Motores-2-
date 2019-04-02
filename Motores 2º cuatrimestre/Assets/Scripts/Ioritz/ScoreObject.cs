using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{

    private Rigidbody rb;



    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 10f);
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-2, 2), 3, Random.Range(-2, 2));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
