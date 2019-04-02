using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{

    public Rigidbody rb;



    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 1.5f);
        GetComponent<Rigidbody>().velocity = new Vector3(Random.Range(-1, 1), 3, Random.Range(-1, 1));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
