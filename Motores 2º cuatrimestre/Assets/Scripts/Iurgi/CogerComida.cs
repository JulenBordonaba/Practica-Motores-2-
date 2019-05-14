using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerComida : MonoBehaviour {
    bool eatable;
    public GameObject[] comida;
    
	// Use this for initialization
	void Start () {
        RecorrerComida();
        
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.forward, out hit, 100.0f))
        {
            foreach (GameObject c in comida)
            {
                if (hit.transform.tag == c.transform.tag)
                {
                    
                    c.SetActive(true);
                    print("hola");
                    
                }
            }



        }
    }
   /* private void OnTriggerEnter(Collider other)
    {
        if(transform.tag=="comida"&& Input.GetButtonDown("Fire1") && eatable==true)
        {
            eatable = false;
            //Destroy(comida)
        }
    }*/
    void RecorrerComida()
    {
        for (int i = 0; i < comida.Length; i++)
        {

        }
    }
   
}
