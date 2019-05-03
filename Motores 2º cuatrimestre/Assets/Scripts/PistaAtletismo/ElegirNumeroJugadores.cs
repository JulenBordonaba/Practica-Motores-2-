using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElegirNumeroJugadores : MonoBehaviour
{
    [Tooltip("Arrastra los botones con el numero para elegir jugadores")]
    public List<GameObject> numeros = new List<GameObject>();
    public GameObject canvasNumeroJugadores;//arrastra el canvas con los numeros para elegir el numero de jugadores

    public void elegirJugadores(Text txtNumero)
    {
        int aux = 0;
        GameManagerGlobal.i.numeroJugadores = int.Parse(txtNumero.text);
        aux = int.Parse(txtNumero.text);

        for (int i = 0; i < 4; i++)
        {
            numeros[i].GetComponent<Button>().interactable = false;
            numeros[i].SetActive(false);
        }

        for (int i = 0; i < aux; i++)
        {
            numeros[i].SetActive(true);
            canvasNumeroJugadores.GetComponent<Animator>().Play("desplazarNumerosElegirJugadores");//reproducir el clip por defecto
            StartCoroutine(ActivarElegirJugadores());
        }
    }

    IEnumerator ActivarElegirJugadores()
    {
        yield return new WaitForSeconds(1.583f);//esperar segundos antes de la siguiente activación
        GameManagerGlobal.i.elegirRazasJugadorActual = 1;
    }

    public void VolverElegirNumeroJugadores()
    {
        GameManagerGlobal.i.numeroJugadores = 0;
        GameManagerGlobal.i.elegirRazasJugadorActual = 0;
        GameManagerGlobal.i.jugadores[0].GetComponent<Player>().racePlayer = 0;
        canvasNumeroJugadores.GetComponent<Animator>().Play("desplazarNumerosElegirJugadoresInvertido");//reproducir el clip por defecto
        StartCoroutine(VolverActivarElegirJugadores());
    }

    IEnumerator VolverActivarElegirJugadores()
    {
        yield return new WaitForSeconds(1.583f);//esperar segundos antes de la siguiente activación
        numeros[0].SetActive(false);
        numeros[1].SetActive(true);
        numeros[2].SetActive(true);
        numeros[3].SetActive(true);
        numeros[1].GetComponent<Button>().Select();
    }
}
