using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagePelotas : MonoBehaviour
{
    [Tooltip("Arrastra los gameObject de los jugadores")]
    public List<GameObject> players = new List<GameObject>();//

    private bool finJuego;//booleana auxiliar para controlar que el juego ya ha acabado y no llamar constantemente a la función finDeJuego

    void Update()
    {
        int contadorJugadoresAcabados = 0;//un contador que suma jugadores eliminados y/o en meta
        foreach (GameObject player in players)//bucle para recorrer todos los jugadores
        {
            //si el jugador ha llegado a meta o está eliminado se suman al contador
            if (player.GetComponent<Player>().eliminated == true)
            {
                contadorJugadoresAcabados++;
            }
        }

        //si el contador es igual al numero de jugadores
        if (contadorJugadoresAcabados == (GameManagerGlobal.i.numeroJugadores - 1) || TimeCount.i.time <= 0)//puede que haya que cambiar las referencias de players.Capacity por el numero de jugadores del GameManager
        {
            //si no se habia acabado el juego todavía
            if (!finJuego)
            {
                //animación de fin de juego
                //llamar a la función que controla el fin de juego. Ganador, posiciones, llamar al podio...
                FinDeJuego();
            }

        }
    }

    void FinDeJuego()
    {
        GameObject temporal;//varaible temporal para ordenar los jugadores
        finJuego = true;//se pone a true la variable auxiliar que controla que el juego ha acabado

        //primero otorgamos puntuacioón a aquellos jugadores que no han sido eliminados. Para que no tengan 10000 y cuenten como no participando
        foreach (GameObject jugaodr in players)
        {
            if (!jugaodr.GetComponent<Player>().eliminated && jugaodr.activeSelf == true)//si el jugador esta jugando y no ha sido eliminado
                jugaodr.GetComponent<MiniGameScores>().time = -1;//optiene el menor tiempo
        }

        //luego ordeno los jugadores que han llegado a la meta de mayor a menor tiempo ignorando aquellos que no han llegado a la meta
        for (int i = 0; i < players.Count; i++)
        {
            for (int j = 0; j < players.Count - 1; j++)
            {
                if ((players[j].GetComponent<MiniGameScores>().time > players[j + 1].GetComponent<MiniGameScores>().time))
                { // Ordena el array de menor a mayor
                    temporal = players[j];
                    players[j] = players[j + 1];
                    players[j + 1] = temporal;
                }
            }
        }

        //por ultimo se añaden a su posicion
        int primeros = -1;//variable auxiliar para calcular la cantidad de primeros en el juego
        for (int i = 0; i < players.Count; i++)//añadir a cada jugador a su posicion 
        {
            if (players[i].GetComponent<MiniGameScores>().time != 10000)//si no han participado. 10000 es el valor por defecto del tiempo. Si no es menor, es que no está jugando
            {
                if (players[i].GetComponent<MiniGameScores>().time == -1)//si ha quedado primero
                {
                    players[i].GetComponent<MiniGameScores>().position = 1;//añadir posicion
                    G.positions[players[i].GetComponent<Player>().numPlayer] = players[i].GetComponent<MiniGameScores>().position;//añadir posicion para el podio
                    primeros++;
                }
                else
                {
                    players[i].GetComponent<MiniGameScores>().position = (i + 1) - (primeros);//añadir posicion
                    G.positions[players[i].GetComponent<Player>().numPlayer] = players[i].GetComponent<MiniGameScores>().position;//añadir posicion para el podio
                }

            }

        }

        //cargar siguiente escena
        SceneManager.LoadScene("Podium2");
    }
}
