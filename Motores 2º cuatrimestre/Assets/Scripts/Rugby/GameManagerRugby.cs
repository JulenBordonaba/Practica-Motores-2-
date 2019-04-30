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
        if (contadorJugadoresAcabados == players.Capacity || TimeCount.i.time<=0)//puede que haya que cambiar las referencias de players.Capacity por el numero de jugadores del GameManager
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
        float auxGanador = -10000;//variable auxiliar con la mayor puntiacion
        float auxSegundo = -10000;//variable auxiliar con la segunda mayor puntiacion
        float auxTercero = -10000;//variable auxiliar con la tercera mayor puntiacion

        finJuego = true;//se pone a true la variable auxiliar que controla que el juego ha acabado

        //primero ordeno los jugadores que han llegado a la meta de mayor a menor puntuación ignorando aquellos que no han llegado a la meta
        for (int i = 0; i < players.Capacity; i++)
        {
            for (int j = 0; j < players.Capacity - 1; j++)
            {
                if ((players[j].GetComponent<MiniGameScores>().time > players[j + 1].GetComponent<MiniGameScores>().time))
                { // Ordena el array de menor a mayor
                    temporal = players[j];
                    players[j] = players[j + 1];
                    players[j + 1] = temporal;
                }
            }
        }

        ////guardar los puntos de la primera posición
        //auxGanador = players[0].GetComponent<MiniGameScores>().time;
        ////mensajes en consola para comprobar que funciona, una vez se pueda llamar a la escena podio se pueden eliminar
        //Debug.Log(auxGanador + "auxGanador");

        ////guardar los puntos de la segunda y tercera posición
        //foreach (GameObject player in players)
        //{
        //    //segunda posicion
        //    if (player.GetComponent<MiniGameScores>().time > auxGanador && player.GetComponent<MiniGameScores>().time != auxGanador)
        //    {
        //        auxSegundo = player.GetComponent<MiniGameScores>().time;
        //    }

        //    //tercera posicion
        //    else if (player.GetComponent<MiniGameScores>().time > auxSegundo && player.GetComponent<MiniGameScores>().time != auxSegundo && player.GetComponent<MiniGameScores>().time != auxGanador)
        //    {
        //        auxTercero = player.GetComponent<MiniGameScores>().time;
        //    }
        //}

        ////añadir jugadores a las listas de posicion
        //foreach (GameObject player in players)
        //{   //primera posicion
        //    if (player.GetComponent<MiniGameScores>().time == auxGanador)
        //    {
        //        player.GetComponent<MiniGameScores>().position = 1;
        //        ganadores.Add(player);
        //    }//segunda posicion
        //    else if (player.GetComponent<MiniGameScores>().time == auxSegundo)
        //    {
        //        player.GetComponent<MiniGameScores>().position = 2;
        //        segundos.Add(player);
        //    }//tercera posicion
        //    else if (player.GetComponent<MiniGameScores>().time == auxTercero)
        //    {
        //        player.GetComponent<MiniGameScores>().position = 3;
        //        terceros.Add(player);
        //    }
        //    else
        //    {
        //        player.GetComponent<MiniGameScores>().position = 4;
        //        cuartos.Add(player);
        //    }
        //}

        ////añadir al podio los jugadores
        //foreach (GameObject player in ganadores)
        //{
        //    G.positions[player.GetComponent<Player>().numPlayer] = player.GetComponent<MiniGameScores>().position;
        //}
        //foreach (GameObject player in segundos)
        //{
        //    G.positions[player.GetComponent<Player>().numPlayer] = player.GetComponent<MiniGameScores>().position;
        //}
        //foreach (GameObject player in terceros)
        //{
        //    G.positions[player.GetComponent<Player>().numPlayer] = player.GetComponent<MiniGameScores>().position;
        //}
        //foreach (GameObject player in cuartos)
        //{
        //    G.positions[player.GetComponent<Player>().numPlayer] = player.GetComponent<MiniGameScores>().position;
        //}

        for (int i = 0; i < 4; i++)
        {
            players[i].GetComponent<MiniGameScores>().position = i+1;
            G.positions[players[i].GetComponent<Player>().numPlayer] = players[i].GetComponent<MiniGameScores>().position;
        }

        foreach (GameObject player in players)
        {
            Debug.Log("Ganador: Jugador " + player.GetComponent<Player>().numPlayer + ", tiempo " + player.GetComponent<MiniGameScores>().time + ", posicion " + player.GetComponent<MiniGameScores>().position);
        }


        //mensajes en consola para comprobar que funciona, una vez se pueda llamar a la escena podio se pueden eliminar
        foreach (GameObject player in ganadores)
        {
            Debug.Log("Ganador: Jugador " + player.GetComponent<Player>().numPlayer + ", tiempo " + player.GetComponent<MiniGameScores>().time + ", posicion " + player.GetComponent<MiniGameScores>().position);
        }
        foreach (GameObject player in segundos)
        {
            Debug.Log("Segundo: Jugador " + player.GetComponent<Player>().numPlayer + ", tiempo " + player.GetComponent<MiniGameScores>().time + ", posicion " + player.GetComponent<MiniGameScores>().position);
        }
        foreach (GameObject player in terceros)
        {
            Debug.Log("Tercero: Jugador " + player.GetComponent<Player>().numPlayer + ", tiempo " + player.GetComponent<MiniGameScores>().time + ", posicion " + player.GetComponent<MiniGameScores>().position);
        }
        foreach (GameObject player in cuartos)
        {
            Debug.Log("Perdedor: Jugador " + player.GetComponent<Player>().numPlayer + ", tiempo " + player.GetComponent<MiniGameScores>().time + ", posicion " + player.GetComponent<MiniGameScores>().position);
        }

        //cargar siguiente escena
        SceneManager.LoadScene("Podium2");
    }
}
