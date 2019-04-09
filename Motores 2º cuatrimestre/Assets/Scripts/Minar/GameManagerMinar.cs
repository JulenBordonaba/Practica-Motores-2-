using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMinar : MonoBehaviour
{

    [Tooltip("La lista se generará a partir de una variable global para todo el juego que tiene la cantidad de jugadores que estan jugando")]
    public List<GameObject> players = new List<GameObject>();//
    List<GameObject> ganadores = new List<GameObject>();//
    List<GameObject> segundos = new List<GameObject>();//
    List<GameObject> terceros = new List<GameObject>();//
    List<GameObject> cuartos = new List<GameObject>();//
    public bool finJuego;
    // Update is called once per frame
    void Update()
    {
        int contadorJugadoresAcabados=0;//un contador que suma jugadores eliminados y en meta
        foreach (GameObject player in players)
        {
            if(player.GetComponent<MiniGameScores>().onGoal == true || player.GetComponent<Player>().eliminated == true)
            {
                contadorJugadoresAcabados++;
            }
        }
        if (contadorJugadoresAcabados == players.Capacity)
        {
            if (!finJuego)
            {
                finDeJuego();
            }
                
        }
    }

    private void finDeJuego()
    {
        finJuego = true;
        int auxGanador=0;
        int auxSegundo = 0;
        int auxTercero = 0;
        //guardar los puntos de la primera posición
        if ((players[0].GetComponent<MiniGameScores>().onGoal==true) && players[0].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points && players[0].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points && players[0].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
        {
            auxGanador = players[0].GetComponent<MiniGameScores>().points;
        }
        if ((players[1].GetComponent<MiniGameScores>().onGoal == true) && players[1].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points && players[1].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points && players[1].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
        {
            auxGanador = players[1].GetComponent<MiniGameScores>().points;
        }
        if ((players[2].GetComponent<MiniGameScores>().onGoal == true) && players[2].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points && players[2].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points && players[2].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
        {
            auxGanador = players[2].GetComponent<MiniGameScores>().points;
        }
        if ((players[3].GetComponent<MiniGameScores>().onGoal == true) && players[3].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points && players[3].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points && players[3].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points)
        {
            auxGanador = players[3].GetComponent<MiniGameScores>().points;
        }
        Debug.Log(auxGanador + "auxGanador");
        //guardar los puntos de la segunda posición
        if ((players[0].GetComponent<MiniGameScores>().points < auxGanador) && (players[0].GetComponent<MiniGameScores>().onGoal == true) && players[0].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points && players[0].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points && players[0].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
        {
            auxSegundo = players[0].GetComponent<MiniGameScores>().points;
        }
        if ((players[1].GetComponent<MiniGameScores>().points < auxGanador) && (players[1].GetComponent<MiniGameScores>().onGoal == true) && players[1].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points && players[1].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points && players[1].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
        {
            auxSegundo = players[1].GetComponent<MiniGameScores>().points;
        }
        if ((players[2].GetComponent<MiniGameScores>().points < auxGanador) && (players[2].GetComponent<MiniGameScores>().onGoal == true) && players[2].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points && players[2].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points && players[2].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
        {
            auxSegundo = players[2].GetComponent<MiniGameScores>().points;
        }
        if ((players[3].GetComponent<MiniGameScores>().points < auxGanador) && (players[3].GetComponent<MiniGameScores>().onGoal == true) && players[3].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points && players[3].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points && players[3].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points)
        {
            auxSegundo = players[3].GetComponent<MiniGameScores>().points;
        }
        Debug.Log(auxSegundo + "auxSegundo");
        //guardar los puntos de la tercera posicion
        if ((players[0].GetComponent<MiniGameScores>().points < auxSegundo) && (players[0].GetComponent<MiniGameScores>().onGoal == true) && players[0].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points && players[0].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points && players[0].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
        {
            auxTercero = players[0].GetComponent<MiniGameScores>().points;
        }
        if ((players[1].GetComponent<MiniGameScores>().points < auxSegundo) && (players[1].GetComponent<MiniGameScores>().onGoal == true) && players[1].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points && players[1].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points && players[1].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
        {
            auxTercero = players[1].GetComponent<MiniGameScores>().points;
        }
        if ((players[2].GetComponent<MiniGameScores>().points < auxSegundo) && (players[2].GetComponent<MiniGameScores>().onGoal == true) && players[2].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points && players[2].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points && players[2].GetComponent<MiniGameScores>().points >= players[3].GetComponent<MiniGameScores>().points)
        {
            auxTercero = players[2].GetComponent<MiniGameScores>().points;
        }
        if ((players[3].GetComponent<MiniGameScores>().points < auxSegundo) && (players[3].GetComponent<MiniGameScores>().onGoal == true) && players[3].GetComponent<MiniGameScores>().points >= players[0].GetComponent<MiniGameScores>().points && players[3].GetComponent<MiniGameScores>().points >= players[1].GetComponent<MiniGameScores>().points && players[3].GetComponent<MiniGameScores>().points >= players[2].GetComponent<MiniGameScores>().points)
        {
            auxTercero = players[3].GetComponent<MiniGameScores>().points;
        }
        Debug.Log(auxTercero + "auxTercero");




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
