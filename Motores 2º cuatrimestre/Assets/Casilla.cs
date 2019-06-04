using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Scores {

};

public class Casilla : MonoBehaviour
{    
    public int[] scores = new int[5];
    public GameObject scoreobject;

    void Start()
    {
        //Instantiate(scoreobject, transform.position + new Vector3(0, 0.3f +0.4f*i , 0), Quaternion.identity);

    }
    void Update()
    {
        
    }

    public void Spawn(int ronda)
    {
        for (int i = 0; i < scores[ronda]; i++)
        {
            Instantiate(scoreobject, transform.position + new Vector3(ronda,0.3f+0.4f*i,0), Quaternion.identity);
        }
    }
}
