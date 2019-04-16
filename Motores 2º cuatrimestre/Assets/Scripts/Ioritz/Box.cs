using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    private int amount;
    
    [Tooltip("Objeto que soltara al destruirse")]
    public GameObject ScorePrefab;
    [Tooltip("Score maximo que podra soltar")]
    public int max = 10;

    // Use this for initialization
    void Start()
    {
        amount = Random.Range(0, max);  //Las cajas soltaran una cantidad aleatoria de scores entre 0 y el maximo
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Martillo()  //Destrulle la caja y genera los drops
    {
        for (int n = 0; n < amount; n++)
        {
            Instantiate(ScorePrefab, transform.position, Quaternion.identity);
        }       
        
        Destroy(gameObject);
    }
    
}
