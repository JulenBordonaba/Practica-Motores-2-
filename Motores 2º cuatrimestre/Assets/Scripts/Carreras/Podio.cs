using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Podio : MonoBehaviour
{
    public int podio = 0;

    public GameObject jugador0;
    public GameObject jugador1;
    public GameObject jugador2;
    public GameObject jugador3;

    private void Update()
    {
        if((jugador0.activeInHierarchy == false || jugador0.GetComponent<ContadorVueltas>().vueltasActuales == jugador0.GetComponent<ContadorVueltas>().vueltasMaximas) && (jugador1.activeInHierarchy == false || jugador1.GetComponent<ContadorVueltas>().vueltasActuales == jugador1.GetComponent<ContadorVueltas>().vueltasMaximas) && (jugador2.activeInHierarchy == false || jugador2.GetComponent<ContadorVueltas>().vueltasActuales == jugador2.GetComponent<ContadorVueltas>().vueltasMaximas) && (jugador3.activeInHierarchy == false || jugador3.GetComponent<ContadorVueltas>().vueltasActuales == jugador3.GetComponent<ContadorVueltas>().vueltasMaximas))
        {
            SceneManager.LoadScene("Podium2");
        }
    }


    public void Posicionar(int jugador)
    {
        G.positions[jugador] = podio;
        podio++;
    }
}
