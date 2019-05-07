using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLaberinto : MonoBehaviour
{
    public GameManagerLaberinto gmLaberinto;
    private int llegados = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<PlayerController>().enabled = false;
            G.positions[other.gameObject.GetComponent<Player>().numPlayer] = llegados + 1;
            llegados += 1;
            if(llegados>=G.activePlayers-1)
            {
                gmLaberinto.EndGame();
            }
        }
    }

}
