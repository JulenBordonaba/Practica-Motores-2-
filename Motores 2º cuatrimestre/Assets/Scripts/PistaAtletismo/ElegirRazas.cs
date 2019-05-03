using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElegirRazas : MonoBehaviour
{
    [Tooltip("Arrastra los botones con todas las razas del jugador 1")]
    public List<GameObject> razas1 = new List<GameObject>();
    [Tooltip("Arrastra los botones con todas las razas del jugador 2")]
    public List<GameObject> razas2 = new List<GameObject>();
    [Tooltip("Arrastra los botones con todas las razas del jugador 3")]
    public List<GameObject> razas3 = new List<GameObject>();
    [Tooltip("Arrastra los botones con todas las razas del jugador 4")]
    public List<GameObject> razas4 = new List<GameObject>();
    [Tooltip("Arrastra el objeto con las animaciones de las razas")]
    public GameObject elegirRazas;
    [Tooltip("Arrastra el boton de play, el que inicia la selección de minijuego")]
    public GameObject btPlayElegirMinijuego;

    private bool onFocus;
    private bool minijuego;

    private void Start()
    {
        onFocus = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (onFocus)
        {
            OcultarRazas();
            switch (GameManagerGlobal.i.elegirRazasJugadorActual)
            {
                case 1:
                    for (int i = 0; i < 6; i++)
                    {
                        razas1[i].SetActive(true);
                    }
                    razas1[0].GetComponent<Button>().Select();
                    onFocus = false;
                    break;

                case 2:
                    for (int i = 0; i < 6; i++)
                    {
                        razas2[i].SetActive(true);
                    }
                    razas2[0].GetComponent<Button>().Select();
                    onFocus = false;
                    break;

                case 3:
                    for (int i = 0; i < 6; i++)
                    {
                        razas3[i].SetActive(true);
                    }
                    razas3[0].GetComponent<Button>().Select();
                    onFocus = false;
                    break;

                case 4:
                    for (int i = 0; i < 6; i++)
                    {
                        razas4[i].SetActive(true);
                    }
                    razas4[0].GetComponent<Button>().Select();
                    onFocus = false;
                    break;

                default:
                    break;
            }
        }

        if (GameManagerGlobal.i.elegirRazasJugadorActual == 5 && minijuego)
        {
            minijuego = false;
            OcultarRazas();
            StartCoroutine(ActivarElegirMinijuego());
        }
    }

    public void ElegirRazaJugador (Text txtValue)
    {
        onFocus = false;
        OcultarRazas();
        switch (GameManagerGlobal.i.elegirRazasJugadorActual)
        {
            case 1:
                GameManagerGlobal.i.jugadores[0].GetComponent<Player>().racePlayer = int.Parse(txtValue.text);
                razas1[int.Parse(txtValue.text) - 1].SetActive(true);
                //elegirRazas.GetComponent<Animator>().Play("desplazarNumerosElegirJugadores");//reproducir el clip por defecto
                StartCoroutine(ActivarElegirRaza(2));
                break;

            case 2:
                GameManagerGlobal.i.jugadores[1].GetComponent<Player>().racePlayer = int.Parse(txtValue.text);
                razas2[int.Parse(txtValue.text) - 1].SetActive(true);
                //elegirRazas.GetComponent<Animator>().Play("desplazarNumerosElegirJugadores");//reproducir el clip por defecto
                if (GameManagerGlobal.i.numeroJugadores==2)
                    StartCoroutine(ActivarElegirRaza(5));//5 significa que pasa a elegir el minijuego
                else
                    StartCoroutine(ActivarElegirRaza(3));
                break;

            case 3:
                GameManagerGlobal.i.jugadores[2].GetComponent<Player>().racePlayer = int.Parse(txtValue.text);
                razas3[int.Parse(txtValue.text) - 1].SetActive(true);
                //elegirRazas.GetComponent<Animator>().Play("desplazarNumerosElegirJugadores");//reproducir el clip por defecto
                if (GameManagerGlobal.i.numeroJugadores == 3)
                    StartCoroutine(ActivarElegirRaza(5));//5 significa que pasa a elegir el minijuego
                else
                    StartCoroutine(ActivarElegirRaza(4));
                break;

            case 4:
                GameManagerGlobal.i.jugadores[3].GetComponent<Player>().racePlayer = int.Parse(txtValue.text);
                razas4[int.Parse(txtValue.text) - 1].SetActive(true);
                //elegirRazas.GetComponent<Animator>().Play("desplazarNumerosElegirJugadores");//reproducir el clip por defecto
                StartCoroutine(ActivarElegirRaza(5));//5 significa que pasa a elegir el minijuego
                break;

            default:
                break;
        }
    }

    IEnumerator ActivarElegirRaza(int num)
    {
        yield return new WaitForSeconds(1.583f);//esperar segundos antes de la siguiente activación
        GameManagerGlobal.i.jugadores[GameManagerGlobal.i.elegirRazasJugadorActual-1].SetActive(true);
        GameManagerGlobal.i.elegirRazasJugadorActual = num;
        if (num == 5)
        {
            btPlayElegirMinijuego.SetActive(true);
           btPlayElegirMinijuego.GetComponent<Button>().Select();
            minijuego = true;
        }
        onFocus = true;
    }

    IEnumerator ActivarElegirMinijuego()
    {
        yield return new WaitForSeconds(1.583f);//esperar segundos antes de la siguiente activación
        //for (int i = 0; i < GameManagerGlobal.i.numeroJugadores; i++)
        //{
        //    GameManagerGlobal.i.jugadores[i].SetActive(true);
        //}
    }

    public void OnFocusTrue()
    {
        onFocus = true;
    }

    public void OcultarRazas()
    {
        for (int i = 0; i < 6; i++)
        {
            razas1[i].SetActive(false);
            razas2[i].SetActive(false);
            razas3[i].SetActive(false);
            razas4[i].SetActive(false);
        }
    }

    public void VolverElegirRaza(GameObject jugador)
    {
        GameManagerGlobal.i.elegirRazasJugadorActual = GameManagerGlobal.i.elegirRazasJugadorActual-1;
        jugador.GetComponent<Player>().racePlayer = 0;
        //elegirRazas.GetComponent<Animator>().Play("desplazarNumerosElegirJugadoresInvertido");//reproducir el clip por defecto
        StartCoroutine(VolverElegirRazaIE());
    }

    IEnumerator VolverElegirRazaIE()
    {
        yield return new WaitForSeconds(1.583f);//esperar segundos antes de la siguiente activación
        OnFocusTrue();
    }
}
