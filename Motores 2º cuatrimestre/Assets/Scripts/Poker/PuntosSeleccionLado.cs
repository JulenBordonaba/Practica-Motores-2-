using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosSeleccionLado : MonoBehaviour
{
    public GameObject[] cartas; // corazones rombos treboles picas y vacio
    public Material[] materialCartas;
    public Color[] colores; // rojo azul verde amarillo
    public GameManagerPoker gameManager;

    public bool acierto;
    public int llegado;
    

    

    public void ActivarImagen(int Carta, int Color, bool Buena)
    {
        cartas[Carta].SetActive(true);
        materialCartas[Carta].color = colores[Color];
        acierto = Buena;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (acierto)
            {
                if(llegado == 0 && other.GetComponent<ElegirLadoPoker>().enabled == true)
                {
                    other.GetComponent<ManagerPuntosPoker>().puntos += 5;
                    llegado++;
                    other.GetComponent<ElegirLadoPoker>().enabled = false;
                    gameManager.sumarSeleccionados();
                    return;
                }
                else if(llegado == 1 && other.GetComponent<ElegirLadoPoker>().enabled == true)
                {
                    other.GetComponent<ManagerPuntosPoker>().puntos += 3;
                    llegado++;
                    other.GetComponent<ElegirLadoPoker>().enabled = false;
                    gameManager.sumarSeleccionados();
                    return;
                }
                else if (llegado == 2 && other.GetComponent<ElegirLadoPoker>().enabled == true)
                {
                    other.GetComponent<ManagerPuntosPoker>().puntos += 2;
                    llegado++;
                    other.GetComponent<ElegirLadoPoker>().enabled = false;
                    gameManager.sumarSeleccionados();
                    return;
                }
                else if (llegado == 3 && other.GetComponent<ElegirLadoPoker>().enabled == true)
                {
                    other.GetComponent<ManagerPuntosPoker>().puntos += 1;
                    llegado++;
                    other.GetComponent<ElegirLadoPoker>().enabled = false;
                    gameManager.sumarSeleccionados();
                    return;
                }
            }
            else
            {
                if (other.GetComponent<ElegirLadoPoker>().enabled == true)
                {
                    other.GetComponent<ElegirLadoPoker>().enabled = false;
                    gameManager.sumarSeleccionados();
                }
            }
        }
    }

    public void ResetearImagenes()
    {
        for(int i = 0; i <= 4; i++)
        {
            cartas[i].SetActive(false);
        }
    }
}
