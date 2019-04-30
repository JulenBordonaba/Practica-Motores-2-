using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerComida : MonoBehaviour {
    bool eatable;
    public GameObject[] comida;
    public GameObject plato;
	// Use this for initialization
	void Start () {
        RecorrerComida();
       
        foreach(GameObject go in comida)
        {
            
            go.SetActive(false);
        }
	}

    // Update is called once per frame
    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 10.0f))
        {
            foreach(GameObject go in comida)
            {
                if (go.transform.tag == hit.transform.tag && Input.GetButtonDown("Space"))
                   
                    go.SetActive (true);
                
            } 

        }

            
    }
    
    public void RecorrerComida()
    {
        for (int i = 0; i < comida.Length; i++)
        {
           
        }
    }
}
