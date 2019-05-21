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
    

    

    public void ActivarImagen(int Carta, int Color, bool Buena,bool colorPropio)
    {
        cartas[Carta].SetActive(true);
        acierto = Buena;
        if (colorPropio)
            materialCartas[Carta].color = colores[Carta];
        else
            materialCartas[Carta].color = colores[Color];

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (acierto)
            {
                if(llegado == 0 )
                {
                    other.GetComponent<ManagerPuntosPoker>().puntos += 5;
                    llegado++;
                    gameManager.sumarSeleccionados();
                    return;
                }
                else if(llegado == 1 )
                {
                    other.GetComponent<ManagerPuntosPoker>().puntos += 3;
                    llegado++;
                    gameManager.sumarSeleccionados();
                    return;
                }
                else if (llegado == 2)
                {
                    other.GetComponent<ManagerPuntosPoker>().puntos += 2;
                    llegado++;
                    gameManager.sumarSeleccionados();
                    return;
                }
                else if (llegado == 3)
                {
                    other.GetComponent<ManagerPuntosPoker>().puntos += 1;
                    llegado++;
                    gameManager.sumarSeleccionados();
                    return;
                }
            }
            else
            {
                    gameManager.sumarSeleccionados();
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
