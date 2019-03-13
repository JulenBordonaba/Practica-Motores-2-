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
        GameObject.FindGameObjectWithTag("Car1").GetComponent<MovimientoCoche>().enabled = true;
        GameObject.FindGameObjectWithTag("Car2").GetComponent<MovimientoCoche>().enabled = true;
        GameObject.FindGameObjectWithTag("Car3").GetComponent<MovimientoCoche>().enabled = true;
        GameObject.FindGameObjectWithTag("Car4").GetComponent<MovimientoCoche>().enabled = true;

    }

    public void Off()
    {
        GameObject.FindGameObjectWithTag("Car1").GetComponent<MovimientoCoche>().enabled = false;
        GameObject.FindGameObjectWithTag("Car2").GetComponent<MovimientoCoche>().enabled = false;
        GameObject.FindGameObjectWithTag("Car3").GetComponent<MovimientoCoche>().enabled = false;
        GameObject.FindGameObjectWithTag("Car4").GetComponent<MovimientoCoche>().enabled = false;
    }
}
