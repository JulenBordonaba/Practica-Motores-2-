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
    [Header("Inputs mando y teclado")]
    [Tooltip("Arrastra el event system para el mando")]
    public GameObject inputMando;
    [Tooltip("Arrastra el event system para el teclado")]
    public GameObject inputTeclado;


    // Start is called before the first frame update
    void Start()
    {
        i = this;

        ComprobarMandoOTeclado();
        BarajarMinijuegos();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void BarajarMinijuegos()//baraja los minijuegos al azar para que no toque dos veces el mismo
    {
        int last = minijuegos.Count;
        
        for (int i = 0; i < last; i++)
        {
            swap(i, i + Random.Range(0,last-1));
        }
    }

    private void swap(int a, int b)//intercambia posiciones
    {
        string temp = minijuegos[a];
        minijuegos[a] = minijuegos[b];
        minijuegos[b] = temp;
    }


    public void ComprobarMandoOTeclado()
    {
        if (InputManager.MandosConectados > 0)
        {
            inputTeclado.SetActive(false);
            inputMando.SetActive(true);
        }
        else
        {
            inputTeclado.SetActive(true);
            inputMando.SetActive(false);

        }
    }
}
