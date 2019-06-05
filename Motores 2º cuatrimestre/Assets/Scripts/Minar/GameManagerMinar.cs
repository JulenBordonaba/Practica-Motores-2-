using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMinar : MonoBehaviour
{

    [Tooltip("Arrastra los gameObject de los jugadores")]
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
                contadorJugadoresAcabados++;
        }
        //si el contador es igual al numero de jugadores
        if (contadorJugadoresAcabados == GameManagerGlobal.i.numeroJugadores-1)//puede que haya que cambiar las referencias de players.Capacity por el numero de jugadores del GameManager
        {
            //si no se habia acabado el juego todavía
            if (!finJuego)
                FinDeJuego();//llamar a la función que controla el fin de juego. Ganador, posiciones, llamar al podio...
        }
    }

    private void FinDeJuego()//esta función controla el ganador y las posiciones de los demás, llama a las animaciones de fin de juego y luego pasa a la escena del podio
    {
        GameObject temporal;//varaible temporal para ordenar los jugadores
        int auxGanador=-10000;//variable auxiliar con la mayor puntiacion
        int auxSegundo = -10000;//variable auxiliar con la segunda mayor puntiacion
        int auxTercero = -10000;//variable auxiliar con la tercera mayor puntiacion

        finJuego = true;//se pone a true la variable auxiliar que controla que el juego ha acabado

        //primero ordeno los jugadores que han llegado a la meta de mayor a menor puntuación ignorando aquellos que no han llegado a la meta
        for (int i = 0; i < players.Capacity; i++)
        {
            for (int j = 0; j < players.Capacity -1 ; j++)
            {
                if ((players[j].GetComponent<MiniGameScores>().points < players[j + 1].GetComponent<MiniGameScores>().points))
                { // Ordena el array de mayor a menor
                    temporal = players[j];
                    players[j] = players[j + 1];
                    players[j + 1] = temporal;
                }
            }
        }
        //guardar los puntos de la primera posición
        if(players[0].GetComponent<MiniGameScores>().points!=-10000)
            auxGanador = players[0].GetComponent<MiniGameScores>().points;

        //guardar los puntos de la segunda y tercera posición
        foreach (GameObject player in players)
        {
            if (player.GetComponent<MiniGameScores>().onGoal == true)
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
        }

        //añadir jugadores a las listas de posicion
        foreach (GameObject player in players)
        {   //primera posicion
            if (player.GetComponent<MiniGameScores>().points == auxGanador)
            {
                player.GetComponent<MiniGameScores>().position = 1;//se añade a la primera posicion
                ganadores.Add(player);//se añade a la lista de segundos
            }//segunda posicion
            else if (player.GetComponent<MiniGameScores>().points == auxSegundo)
            {
                player.GetComponent<MiniGameScores>().position = 2;//se añade a la segunda posicion
                segundos.Add(player);//se añade a la lista de segundos
            }//tercera posicion
            else if (player.GetComponent<MiniGameScores>().points == auxTercero)
            {
                player.GetComponent<MiniGameScores>().position = 3;//se añade a la tercera posicion
                terceros.Add(player);//se añade a la lista de terceros
            }
            //ultima posicion
            if (player.GetComponent<Player>().eliminated == true)
            {
                switch (GameManagerGlobal.i.numeroJugadores)//es nombre de esta variable es provisional, cuando se descomente el switch hay que poner la correspondiente
                {
                    case 2://hay 2 jugadores
                        player.GetComponent<MiniGameScores>().position = 2;//se añade a la segunda posicion
                        segundos.Add(player);//se añade a la lista de segundos
                        break;

                    case 3://hay 3 jugadores
                        player.GetComponent<MiniGameScores>().position = 3;//se añade a la tercera posicion
                        terceros.Add(player);//se añade a la lista de terceros
                        break;

                    case 4://hay 4 jugadores
                        player.GetComponent<MiniGameScores>().position = 4;//se añade a la cuarta posicion
                        cuartos.Add(player);//se añade a la lista de cuartos
                        break;

                    default://por si las moscas
                        break;
                }
            }
        }

        //añadir al podio los jugadores
        foreach (GameObject player in ganadores)
        {
            G.positions[player.GetComponent<Player>().numPlayer] = player.GetComponent<MiniGameScores>().position;
        }
        foreach (GameObject player in segundos)
        {
            G.positions[player.GetComponent<Player>().numPlayer] = player.GetComponent<MiniGameScores>().position;
        }
        foreach (GameObject player in terceros)
        {
            G.positions[player.GetComponent<Player>().numPlayer] = player.GetComponent<MiniGameScores>().position;
        }
        foreach (GameObject player in cuartos)
        {
            G.positions[player.GetComponent<Player>().numPlayer] = player.GetComponent<MiniGameScores>().position;
        }
        //cargar siguiente escena
        SceneManager.LoadScene("Podium2");

    }
}
