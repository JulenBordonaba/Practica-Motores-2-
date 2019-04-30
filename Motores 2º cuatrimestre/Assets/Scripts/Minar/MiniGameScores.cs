using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameScores : MonoBehaviour
{
    
    [Tooltip("Puntos que tiene el jugador en el minijuego")]
    public int points;
    [Tooltip("Posición que tiene el jugador en el minijuego")]
    public int position;
    [Tooltip("Tiempo total que ha permanecido el jugador en el juego. Dependiendo del minijuego será usado como una cuenta atrás")]
    public int time;
    [Tooltip("Vuelta de la carrera en la que se encuentra el jugador")]
    public int Lap;
    [Tooltip("Booleana, vedadero si ha llegado a la meta")]
    public bool onGoal;
}
