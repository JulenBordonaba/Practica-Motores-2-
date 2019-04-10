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
        int auxGanador=0;//variable auxiliar con la mayor puntiacion
        int auxSegundo = 0;//variable auxiliar con la segunda mayor puntiacion
        int auxTercero = 0;//variable auxiliar con la tercera mayor puntiacion
       
        
        //guardar los puntos de la primera posición
        if ((players[0].GetComponent<MiniGameScores>().onGoal==true) && players[0].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points && players[0].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points && players[0].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
        {//si es el jugador 1
            auxGanador = players[0].GetComponent<MiniGameScores>().points;
        }
        if ((players[1].GetComponent<MiniGameScores>().onGoal == true) && players[1].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points && players[1].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points && players[1].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
        {//si es el jugador 2
            auxGanador = players[1].GetComponent<MiniGameScores>().points;
        }
        if ((players[2].GetComponent<MiniGameScores>().onGoal == true) && players[2].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points && players[2].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points && players[2].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
        {//si es el jugador 3
            auxGanador = players[2].GetComponent<MiniGameScores>().points;
        }
        if ((players[3].GetComponent<MiniGameScores>().onGoal == true) && players[3].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points && players[3].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points && players[3].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points)
        {//si es el jugador 4
            auxGanador = players[3].GetComponent<MiniGameScores>().points;
        }
        Debug.Log(auxGanador + "auxGanador");
       
        
        
        //guardar los puntos de la segunda posición
        bool segundoBool = false; // variable auxiliar para ir controlando si cumple los requisitos para ser la seunda mejor puntuación o no
        if (players[0].GetComponent<MiniGameScores>().points < auxGanador && (players[0].GetComponent<MiniGameScores>().onGoal == true) && (players[0].GetComponent<MiniGameScores>().points < auxSegundo))
        {//si es el jugador 1
            if (players[1].GetComponent<MiniGameScores>().points < auxGanador)
            {
                if (players[0].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points)
                {
                    segundoBool = true;
                }
                else
                {
                    segundoBool = false;
                }
            }

            if (players[2].GetComponent<MiniGameScores>().points < auxGanador)
            {
                if (players[0].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points)
                {
                    segundoBool = true;
                }
                else
                {
                    segundoBool = false;
                }
            }

            if (players[3].GetComponent<MiniGameScores>().points < auxGanador)
            {
                if (players[0].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
                {
                    segundoBool = true;
                }
                else
                {
                    segundoBool = false;
                }
            }

            if (segundoBool)
            {//es la segunda mejor posición
                auxSegundo = players[0].GetComponent<MiniGameScores>().points;
            }
        }
        if (players[1].GetComponent<MiniGameScores>().points < auxGanador && (players[1].GetComponent<MiniGameScores>().onGoal == true) && (players[1].GetComponent<MiniGameScores>().points < auxSegundo))
        {//si es el jugador 2
            if (players[0].GetComponent<MiniGameScores>().points < auxGanador)
            {
                if (players[1].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points)
                {
                    segundoBool = true;
                }
                else
                {
                    segundoBool = false;
                }
            }

            if (players[2].GetComponent<MiniGameScores>().points < auxGanador)
            {
                if (players[1].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points)
                {
                    segundoBool = true;
                }
                else
                {
                    segundoBool = false;
                }
            }

            if (players[3].GetComponent<MiniGameScores>().points < auxGanador)
            {
                if (players[1].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
                {
                    segundoBool = true;
                }
                else
                {
                    segundoBool = false;
                }
            }

            if (segundoBool)
            {//es la segunda mejor posición
                auxSegundo = players[1].GetComponent<MiniGameScores>().points;
            }
        }
        if (players[2].GetComponent<MiniGameScores>().points < auxGanador && (players[2].GetComponent<MiniGameScores>().onGoal == true) && (players[2].GetComponent<MiniGameScores>().points < auxSegundo))
        {//si es el jugador 3
            if (players[0].GetComponent<MiniGameScores>().points < auxGanador)
            {
                if (players[2].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points)
                {
                    segundoBool = true;
                }
                else
                {
                    segundoBool = false;
                }
            }

            if (players[1].GetComponent<MiniGameScores>().points < auxGanador)
            {
                if (players[2].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points)
                {
                    segundoBool = true;
                }
                else
                {
                    segundoBool = false;
                }
            }

            if (players[3].GetComponent<MiniGameScores>().points < auxGanador)
            {
                if (players[2].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
                {
                    segundoBool = true;
                }
                else
                {
                    segundoBool = false;
                }
            }

            if (segundoBool)
            {//es la segunda mejor posición
                auxSegundo = players[2].GetComponent<MiniGameScores>().points;
            }
        }
        if (players[3].GetComponent<MiniGameScores>().points < auxGanador && (players[3].GetComponent<MiniGameScores>().onGoal == true) && (players[3].GetComponent<MiniGameScores>().points < auxSegundo))
        {//si es el jugador 4
            if (players[0].GetComponent<MiniGameScores>().points < auxGanador)
            {
                if (players[3].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points)
                {
                    segundoBool = true;
                }
                else
                {
                    segundoBool = false;
                }
            }

            if (players[1].GetComponent<MiniGameScores>().points < auxGanador)
            {
                if (players[3].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points)
                {
                    segundoBool = true;
                }
                else
                {
                    segundoBool = false;
                }
            }

            if (players[2].GetComponent<MiniGameScores>().points < auxGanador)
            {
                if (players[3].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points)
                {
                    segundoBool = true;
                }
                else
                {
                    segundoBool = false;
                }
            }

            if (segundoBool)
            {//es la segunda mejor posición
                auxSegundo = players[3].GetComponent<MiniGameScores>().points;
            }
        }
        Debug.Log(auxSegundo + "auxSegundo");



        //guardar los puntos de la tercera posicion
        bool terceroBool = false; // variable auxiliar para ir controlando si cumple los requisitos para ser la tercera mejor puntuación o no
        if (players[0].GetComponent<MiniGameScores>().points < auxSegundo && (players[0].GetComponent<MiniGameScores>().onGoal == true) && (players[0].GetComponent<MiniGameScores>().points < auxTercero))
        {//si es el jugador 1
            if (players[1].GetComponent<MiniGameScores>().points < auxSegundo)
            {
                if (players[0].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points)
                {
                    terceroBool = true;
                }
                else
                {
                    terceroBool = false;
                }
            }

            if (players[2].GetComponent<MiniGameScores>().points < auxSegundo)
            {
                if (players[0].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points)
                {
                    terceroBool = true;
                }
                else
                {
                    terceroBool = false;
                }
            }

            if (players[3].GetComponent<MiniGameScores>().points < auxSegundo)
            {
                if (players[0].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
                {
                    terceroBool = true;
                }
                else
                {
                    terceroBool = false;
                }
            }

            if (terceroBool)
            {//es la segunda mejor posición
                auxTercero = players[0].GetComponent<MiniGameScores>().points;
            }
        }
        if (players[1].GetComponent<MiniGameScores>().points < auxSegundo && (players[1].GetComponent<MiniGameScores>().onGoal == true) && (players[1].GetComponent<MiniGameScores>().points < auxTercero))
        {//si es el jugador 2
            if (players[0].GetComponent<MiniGameScores>().points < auxSegundo)
            {
                if (players[1].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points)
                {
                    terceroBool = true;
                }
                else
                {
                    terceroBool = false;
                }
            }

            if (players[2].GetComponent<MiniGameScores>().points < auxSegundo)
            {
                if (players[1].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points)
                {
                    terceroBool = true;
                }
                else
                {
                    terceroBool = false;
                }
            }

            if (players[3].GetComponent<MiniGameScores>().points < auxSegundo)
            {
                if (players[1].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
                {
                    terceroBool = true;
                }
                else
                {
                    terceroBool = false;
                }
            }

            if (terceroBool)
            {//es la segunda mejor posición
                auxTercero = players[1].GetComponent<MiniGameScores>().points;
            }
        }
        if (players[2].GetComponent<MiniGameScores>().points < auxSegundo && (players[2].GetComponent<MiniGameScores>().onGoal == true) && (players[2].GetComponent<MiniGameScores>().points < auxTercero))
        {//si es el jugador 3
            if (players[0].GetComponent<MiniGameScores>().points < auxSegundo)
            {
                if (players[2].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points)
                {
                    terceroBool = true;
                }
                else
                {
                    terceroBool = false;
                }
            }

            if (players[1].GetComponent<MiniGameScores>().points < auxSegundo)
            {
                if (players[2].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points)
                {
                    terceroBool = true;
                }
                else
                {
                    terceroBool = false;
                }
            }

            if (players[3].GetComponent<MiniGameScores>().points < auxSegundo)
            {
                if (players[2].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
                {
                    terceroBool = true;
                }
                else
                {
                    terceroBool = false;
                }
            }

            if (terceroBool)
            {//es la segunda mejor posición
                auxTercero = players[2].GetComponent<MiniGameScores>().points;
            }
        }
        if (players[3].GetComponent<MiniGameScores>().points < auxSegundo && (players[3].GetComponent<MiniGameScores>().onGoal == true) && (players[3].GetComponent<MiniGameScores>().points < auxTercero))
        {//si es el jugador 4
            if (players[0].GetComponent<MiniGameScores>().points < auxSegundo)
            {
                if (players[3].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points)
                {
                    terceroBool = true;
                }
                else
                {
                    terceroBool = false;
                }
            }

            if (players[1].GetComponent<MiniGameScores>().points < auxSegundo)
            {
                if (players[3].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points)
                {
                    terceroBool = true;
                }
                else
                {
                    terceroBool = false;
                }
            }

            if (players[2].GetComponent<MiniGameScores>().points < auxSegundo)
            {
                if (players[3].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points)
                {
                    terceroBool = true;
                }
                else
                {
                    terceroBool = false;
                }
            }

            if (terceroBool)
            {//es la segunda mejor posición
                auxTercero = players[3].GetComponent<MiniGameScores>().points;
            }
        }
        Debug.Log(auxTercero + "auxTercero");



        //añadir jugadores a las listas de posicion
        foreach (GameObject player in players)
        {


            if (ganadores.Capacity==0 && player.GetComponent<MiniGameScores>().onGoal == true)
            {
                ganadores.Add(player);
                Debug.Log("añadido ganador2");
               
            }
            else
            {
                foreach (GameObject ganador in ganadores)
                {
                    Debug.Log(ganador.GetComponent<MiniGameScores>().points + "puntos ganador");
                    Debug.Log(player.GetComponent<MiniGameScores>().points + "puntos jugador");
                    if (ganador)
                    {
                        if (player.GetComponent<MiniGameScores>().onGoal == true && (player.GetComponent<MiniGameScores>().points >= ganador.GetComponent<MiniGameScores>().points))
                        {
                            ganadores.Add(player);
                            Debug.Log("añadido ganador");
                            break;
                        }
                    }
                }
            }
            if (player.GetComponent<Player>().eliminated == true)
            {
                player.GetComponent<MiniGameScores>().position = 4;
                cuartos.Add(player);
                Debug.Log("añadido cuarto");
            }



                //if (player.GetComponent<Player>().eliminated == true)
                //{
                //    if (segundos[0])
                //    {
                //        if (player.GetComponent<Player>().puntos == segundos[0].GetComponent<Player>().puntos)
                //        {
                //            segundos.Add(player);
                //            break;
                //        }
                //    }
                //    else
                //    {

                //    }

                //    if (terceros[0])
                //    {
                //        if (player.GetComponent<Player>().puntos == terceros[0].GetComponent<Player>().puntos)
                //        {
                //            terceros.Add(player);
                //            break;
                //        }
                //    }

                //    if (cuartos[0])
                //    {
                //        if (player.GetComponent<Player>().puntos == cuartos[0].GetComponent<Player>().puntos)
                //        {
                //            cuartos.Add(player);
                //            break;
                //        }
                //    }
                //}




            }
    }
}
