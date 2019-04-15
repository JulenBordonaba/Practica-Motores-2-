using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMinar : MonoBehaviour
{

    [Tooltip("La lista se generará a partir de una variable global para todo el juego que tiene la cantidad de jugadores que estan jugando")]
    public List<GameObject> players = new List<GameObject>();//
    List<GameObject> ganadores = new List<GameObject>();//lista a la que se añadirán todos los ganadores
    List<GameObject> segundos = new List<GameObject>();//lista a la que se añadirán todos los jugadores en segunda posicion
    List<GameObject> terceros = new List<GameObject>();//lista a la que se añadirán todos los jugadores en segunda posicion
    List<GameObject> cuartos = new List<GameObject>();//lista a la que se añadirán todos los jugadores en segunda posicion
    //ser eliminado te manda automáticamente a la última posición
    public bool finJuego;//booleana auxiliar para controlar que el juego ya ha acabado y no llamar constantemente a la función finDeJuego

    void Update()
    {
        int contadorJugadoresAcabados=0;//un contador que suma jugadores eliminados y/o en meta
        foreach (GameObject player in players)//bucle para recorrer todos los jugadores
        {  
            //si el jugador ha llegado a meta o está eliminado se suman al contador
            if(player.GetComponent<MiniGameScores>().onGoal == true || player.GetComponent<Player>().eliminated == true)
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

    private void finDeJuego()//esta función controla el ganador y las posiciones de los demás, llama a las animaciones de fin de juego y luego pasa a la escena del podio
    {
        finJuego = true;//se pone a true la variable auxiliar que controla que el juego ha acabado
        GameObject temporal;
        int auxGanador=-10000;//variable auxiliar con la mayor puntiacion
        int auxSegundo = -10000;//variable auxiliar con la segunda mayor puntiacion
        int auxTercero = -10000;//variable auxiliar con la tercera mayor puntiacion


        //primero ordeno los jugadores que han llegado a la meta de mayor a menor puntuación
        for (int i = 0; i < players.Capacity; i++)
        {
            for (int j = 0; j < players.Capacity -1 ; j++)
            {
                if ((players[j].GetComponent<MiniGameScores>().onGoal == true) && (players[j + 1].GetComponent<MiniGameScores>().onGoal == true) && (players[j].GetComponent<MiniGameScores>().points < players[j + 1].GetComponent<MiniGameScores>().points))
                { // Ordena el array de mayor a menor
                    temporal = players[j];
                    players[j] = players[j + 1];
                    players[j + 1] = temporal;
                }
            }
        }
        //guardar los puntos de la primera posición
        //if (players[0].GetComponent<MiniGameScores>().onGoal == true)
            auxGanador = players[0].GetComponent<MiniGameScores>().points;
        Debug.Log(auxGanador + "auxGanador");

        //guardar los puntos de la segunda y tercera posición
        foreach (GameObject player in players)
        {
            //segunda posicion
            if (player.GetComponent<MiniGameScores>().points < auxGanador && player.GetComponent<MiniGameScores>().points > auxSegundo)
            {
                auxSegundo = player.GetComponent<MiniGameScores>().points;
            }

            //tercera posicion
            else if (player.GetComponent<MiniGameScores>().points < auxSegundo && player.GetComponent<MiniGameScores>().points > auxTercero)
            {
                auxTercero = player.GetComponent<MiniGameScores>().points;
            }
        }
        Debug.Log(auxSegundo + "auxSegundo");
        Debug.Log(auxTercero + "auxTercero");

        foreach (GameObject player in players)
        {
            Debug.Log(player.GetComponent<MiniGameScores>().points + "puntos jugador " + player.GetComponent<Player>().numPlayer + " en meta " + player.GetComponent<MiniGameScores>().onGoal);
        }


        //hay que añadir cada jugador a la lista correspondiente

        //añadir jugadores a las listas de posicion
        foreach (GameObject player in players)
        {
            if (player.GetComponent<MiniGameScores>().points == auxGanador)
            {
                player.GetComponent<MiniGameScores>().position = 1;
                ganadores.Add(player);
            }
            else if (player.GetComponent<MiniGameScores>().points == auxSegundo)
            {
                player.GetComponent<MiniGameScores>().position = 2;
                segundos.Add(player);
            }
            else if (player.GetComponent<MiniGameScores>().points == auxTercero)
            {
                player.GetComponent<MiniGameScores>().position = 3;
                terceros.Add(player);
            }

            if (player.GetComponent<Player>().eliminated == true)
            {
                player.GetComponent<MiniGameScores>().position = 4;
                cuartos.Add(player);
            }

        }

        foreach (GameObject player in ganadores)
        {
            Debug.Log("Ganador: Jugador " + player.GetComponent<Player>().numPlayer + ", puntos " + player.GetComponent<MiniGameScores>().points + ", posicion " + player.GetComponent<MiniGameScores>().position);
        }
        foreach (GameObject player in segundos)
        {
            Debug.Log("Segundo: Jugador " + player.GetComponent<Player>().numPlayer + ", puntos " + player.GetComponent<MiniGameScores>().points + ", posicion " + player.GetComponent<MiniGameScores>().position);
        }
        foreach (GameObject player in terceros)
        {
            Debug.Log("Tercero: Jugador " + player.GetComponent<Player>().numPlayer + ", puntos " + player.GetComponent<MiniGameScores>().points + ", posicion " + player.GetComponent<MiniGameScores>().position);
        }
        foreach (GameObject player in cuartos)
        {
            Debug.Log("Perdedor: Jugador " + player.GetComponent<Player>().numPlayer + ", puntos " + player.GetComponent<MiniGameScores>().points + ", posicion " + player.GetComponent<MiniGameScores>().position);
        }
    }
}
