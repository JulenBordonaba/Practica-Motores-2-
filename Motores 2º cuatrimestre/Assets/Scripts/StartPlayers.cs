using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayers : MonoBehaviour
{
    [Tooltip("Arrastra los gameObject de los jugadores")]
    public List<GameObject> players = new List<GameObject>();//

    private void Start()
    {
        ActivarNumeroJugadores();//Activa jugadores hasta el numero de jugadores en juego
    }

    private void ActivarNumeroJugadores()//Activa jugadores hasta el numero de jugadores en juego
    {
        foreach (GameObject jugador in players)//primero desactiva todos los players
        {
            jugador.SetActive(false);
        }
        for (int i = 0; i < GameManagerGlobal.i.numeroJugadores; i++)//activa players hasta el numero de jugadores actual
        {
            players[i].SetActive(true);
        }
    }
}
