using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iman : MonoBehaviour
{
    public List<GameObject> bolas = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Button2" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode))
        {
            for(int i=0;i<bolas.Count;i++)
            {
                bolas[i].GetComponent<Rigidbody>().isKinematic = false;
                bolas[i].GetComponent<Atraer>().enabled = false;
                bolas[i].transform.parent = null;
            }
            bolas.Clear();
        }
    }
}
