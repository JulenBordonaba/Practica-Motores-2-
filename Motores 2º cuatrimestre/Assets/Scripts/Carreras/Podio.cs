using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Podio : MonoBehaviour
{
    public int podio = 0;


    public void Posicionar(int jugador)
    {
        G.positions[jugador] = podio;
        podio++;
    }
}
