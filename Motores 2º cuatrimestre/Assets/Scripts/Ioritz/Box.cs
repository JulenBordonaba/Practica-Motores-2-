using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    public int amount;
    public int max = 10;
    public GameObject ScorePrefab;

    // Use this for initialization
    void Start()
    {
        amount = Random.Range(0, max);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Martillo()
    {
        for (int n = 0; n < amount; n++)
        {
            Instantiate(ScorePrefab, transform.position, Quaternion.identity);
        }
        //Player.i.Take(amount);
        
        Destroy(gameObject);
    }
    
}
