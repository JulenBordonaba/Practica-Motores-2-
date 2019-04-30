using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerRugby : MonoBehaviour
{

    [Tooltip("La lista se generará a partir de una variable global para todo el juego que tiene la cantidad de jugadores que estan jugando")]
    public List<GameObject> players = new List<GameObject>();//
    List<GameObject> ganadores = new List<GameObject>();//lista a la que se añadirán todos los ganadores
    List<GameObject> segundos = new List<GameObject>();//lista a la que se añadirán todos los jugadores en segunda posicion
    List<GameObject> terceros = new List<GameObject>();//lista a la que se añadirán todos los jugadores en segunda posicion
    List<GameObject> cuartos = new List<GameObject>();//lista a la que se añadirán todos los jugadores en segunda posicion

    private bool finJuego;//booleana auxiliar para controlar que el juego ya ha acabado y no llamar constantemente a la función finDeJuego

    void Update()
    {
        int contadorJugadoresAcabados = 0;//un contador que suma jugadores eliminados y/o en meta
        foreach (GameObject player in players)//bucle para recorrer todos los jugadores
        {
            //si el jugador ha llegado a meta o está eliminado se suman al contador
            if (player.GetComponent<MiniGameScores>().onGoal == true || player.GetComponent<Player>().eliminated == true)
            {
                contadorJugadoresAcabados++;
            }
        }

        //si el contador es igual al numero de jugadores
        if (contadorJugadoresAcabados == players.Capacity)//puede que haya que cambiar las referencias de players.Capacity por el numero de jugadores del GameManager
        {
            //si no se habia acabado el juego todavía
            if (!finJuego)
            {
                //llamar a la función que controla el fin de juego. Ganador, posiciones, llamar al podio...
                finDeJuego();
            }

        }
    }

    void finDeJuego()
    {
        GameObject temporal;//varaible temporal para ordenar los jugadores
        int auxGanador = -10000;//variable auxiliar con la mayor puntiacion
        int auxSegundo = -10000;//variable auxiliar con la segunda mayor puntiacion
        int auxTercero = -10000;//variable auxiliar con la tercera mayor puntiacion

        finJuego = true;//se pone a true la variable auxiliar que controla que el juego ha acabado

        //primero ordeno los jugadores que han llegado a la meta de mayor a menor puntuación ignorando aquellos que no han llegado a la meta
        for (int i = 0; i < players.Capacity; i++)
        {
            for (int j = 0; j < players.Capacity - 1; j++)
            {
                if ((players[j].GetComponent<MiniGameScores>().time < players[j + 1].GetComponent<MiniGameScores>().time))
                { // Ordena el array de mayor a menor
                    temporal = players[j];
                    players[j] = players[j + 1];
                    players[j + 1] = temporal;
                }
            }
        }
    }
}
