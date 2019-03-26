using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiempoVuelta : MonoBehaviour {

    public Text[] Jugadores;

    private float[] TiemposJugadores;

    private List<GameObject> coches = new List<GameObject>();

    public GameObject tiempos;

    private void Awake()
    {
        tiempos.SetActive(false);
    }

    void Update()
    {
        if (GameObject.Find("Jugador0").GetComponent<MovimientoCoche>().enabled == false && GameObject.Find("Jugador1").GetComponent<MovimientoCoche>().enabled == false && GameObject.Find("Jugador2").GetComponent<MovimientoCoche>().enabled == false && GameObject.Find("Jugador3").GetComponent<MovimientoCoche>().enabled == false && Time.deltaTime >= 3)
        {
            tiempos.SetActive(true);
            Jugadores[0].text = "Jugador" + coches[0].GetComponent<MovimientoCoche>().jugador.ToString() + ":    " + ((int)coches[0].GetComponent<MovimientoCoche>().tiempoCarrera / 60).ToString() + ":" + (coches[0].GetComponent<MovimientoCoche>().tiempoCarrera % 60).ToString("f2");
            Jugadores[1].text = "Jugador" + coches[1].GetComponent<MovimientoCoche>().jugador.ToString() + ":    " + ((int)coches[1].GetComponent<MovimientoCoche>().tiempoCarrera / 60).ToString() + ":" + (coches[1].GetComponent<MovimientoCoche>().tiempoCarrera % 60).ToString("f2");
            Jugadores[2].text = "Jugador" + coches[2].GetComponent<MovimientoCoche>().jugador.ToString() + ":    " + ((int)coches[2].GetComponent<MovimientoCoche>().tiempoCarrera / 60).ToString() + ":" + (coches[2].GetComponent<MovimientoCoche>().tiempoCarrera % 60).ToString("f2");
            Jugadores[3].text = "Jugador" + coches[3].GetComponent<MovimientoCoche>().jugador.ToString() + ":    " + ((int)coches[3].GetComponent<MovimientoCoche>().tiempoCarrera / 60).ToString() + ":" + (coches[3].GetComponent<MovimientoCoche>().tiempoCarrera % 60).ToString("f2");
        }
    }

    public void AddCarToArray(GameObject coche)
    {
        coches.Add(coche);
    }
}
