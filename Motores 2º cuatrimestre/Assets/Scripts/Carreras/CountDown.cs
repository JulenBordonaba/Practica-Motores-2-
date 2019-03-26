using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
    
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void On()
    {
        GameObject.Find("Jugador0").GetComponent<MovimientoCoche>().enabled = true;
        GameObject.Find("Jugador1").GetComponent<MovimientoCoche>().enabled = true;
        GameObject.Find("Jugador2").GetComponent<MovimientoCoche>().enabled = true;
        GameObject.Find("Jugador3").GetComponent<MovimientoCoche>().enabled = true;

    }

    public void Off()
    {
        GameObject.Find("Jugador0").GetComponent<MovimientoCoche>().enabled = false;
        GameObject.Find("Jugador1").GetComponent<MovimientoCoche>().enabled = false;
        GameObject.Find("Jugador2").GetComponent<MovimientoCoche>().enabled = false;
        GameObject.Find("Jugador3").GetComponent<MovimientoCoche>().enabled = false;
    }
}
