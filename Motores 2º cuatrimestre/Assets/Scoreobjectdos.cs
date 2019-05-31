using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreobjectdos : MonoBehaviour
{
    static public List<GameObject> scorelist = new List<GameObject>();

    void Start()
    {
        scorelist.Add(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void destruir()
    {
        Destroy(gameObject);
    }

}
