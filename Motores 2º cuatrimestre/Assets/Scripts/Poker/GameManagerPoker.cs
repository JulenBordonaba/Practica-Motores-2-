using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPoker : MonoBehaviour
{
    public int rondas = 1;

    public GameObject[] jugadores;

    public GameObject[] posiciones;

    public int seleccionados;

    private int seleccionadorPosicion;
    private bool imagenesPuestas = false;
    
    
    void Update()
    {
        if(seleccionados >= 4)
        {
            rondas++;
            seleccionados = 0;
            imagenesPuestas = false;
            for (int i = 0; i <= 3; i++)
            {
                jugadores[i].GetComponent<ElegirLadoPoker>().ResetearPosicion();
                posiciones[i].GetComponent<PuntosSeleccionLado>().ResetearImagenes();
            }
                

        }

        if(rondas == 1 && !imagenesPuestas)
        {
            seleccionadorPosicion = Random.Range(0, 3);
            print(seleccionadorPosicion);

            for(int i = 0; i <= 3; i++)
            {
                if(i == seleccionadorPosicion)
                    posiciones[seleccionadorPosicion].GetComponent<PuntosSeleccionLado>().ActivarImagen(0, 0, true);
                else
                    posiciones[i].GetComponent<PuntosSeleccionLado>().ActivarImagen(4, 1, false);
            }
            imagenesPuestas = true;
        }
    }



    public void sumarSeleccionados()
    {
        seleccionados++;
    }
}
