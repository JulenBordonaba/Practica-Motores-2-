using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerGlobal : MonoBehaviour
{
    [Header("Jugadores")]
    [Tooltip("Variable de control para saber cuantos jugadores hay en la partida. No hay que asignarle ningún valor. Mejor dejarla a 0")]
    public int numeroJugadores;
    [Tooltip("Arrastra los gameObject de los jugadores")]
    public List<GameObject> jugadores = new List<GameObject>();
    public static GameManagerGlobal i;
    [Tooltip("Variable de control para saber quien tiene que elegir raza. No hay que asignarle ningún valor. Mejor dejarla a 0")]
    public int elegirRazasJugadorActual;
    [Header("Minijuegos")]
    [Tooltip("Escribe los nombres de los minijuegos a los que se puede jugar. Los nombres deben ser iguales a los de las escenas")]
    public List<string> minijuegos = new List<string>();
    [Tooltip("Variable de control para saber el siguiente minijuego que se va a jugar. No hay que asignarle ningún valor. Mejor dejarla a 0")]
    public int siguienteMinijuego;
    [Tooltip("Variable de control para saber que han vuelto de un minijuego. No hay que asignarle ningún valor. Mejor dejarla a false")]
    public bool finPodio;

    [Header("Objetos que no se destruyen")]
    [Tooltip("Arrastra el GameObject del Game Manager PistaAtletismo para que no se destruya")]
    public GameObject gameManagerAtletismo;
    [Tooltip("Arrastra el GameObject del Canvas elegir Numero Jugadores para que no se destruya")]
    public GameObject canvasNumeroJugadores;
    [Tooltip("Arrastra el GameObject del Canvas elegir Raza para que no se destruya")]
    public GameObject canvasRaza;
    [Tooltip("Arrastra el GameObject del Canvas elegir Minijuego para que no se destruya")]
    public GameObject canvasMinijuegos;
    [Tooltip("Arrastra el GameObject del Event System Teclado para que no se destruya")]
    public GameObject eventSystem;
    [Tooltip("Arrastra el GameObject del InputManager para que no se destruya")]
    public GameObject inputManager;
    [Tooltip("Arrastra el GameObject de las camaras para que no se destruya")]
    public GameObject camaras;

    private void Awake()
    {
        if (i == null)//crea una serie de objetos que no deben destruirse al cambiar de escena, así al volver a esta se mantienen los datos
        {
            i = this;
            DontDestroyOnLoad(gameObject);
            foreach (GameObject jugador in jugadores)
            {
                DontDestroyOnLoad(jugador);
            }
            DontDestroyOnLoad(gameManagerAtletismo);
            DontDestroyOnLoad(canvasNumeroJugadores);
            DontDestroyOnLoad(canvasRaza);
            DontDestroyOnLoad(canvasMinijuegos);
            DontDestroyOnLoad(eventSystem);
            DontDestroyOnLoad(inputManager);
            DontDestroyOnLoad(camaras);

        }
        else//si por algun casual hay duplicados los elimina
        {
            Destroy(gameObject);
            foreach (GameObject jugador in jugadores)
            {
                Destroy(jugador);
            }
            Destroy(gameManagerAtletismo);
            Destroy(canvasNumeroJugadores);
            Destroy(canvasRaza);
            Destroy(canvasMinijuegos);
            Destroy(eventSystem);
            Destroy(inputManager);
            Destroy(camaras);
        }

        BarajarMinijuegos();
    }

    private void BarajarMinijuegos()//baraja los minijuegos al azar para que no toque dos veces el mismo
    {
        int last = minijuegos.Count;
        
        for (int i = 0; i < last; i++)
        {
            Swap(i, i + Random.Range(0,last-1));
        }
    }

    private void Swap(int a, int b)//intercambia posiciones
    {
        string temp = minijuegos[a];
        minijuegos[a] = minijuegos[b];
        minijuegos[b] = temp;
    }
}
