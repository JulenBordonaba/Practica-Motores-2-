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
        switch (int.Parse(txtNumero.text))
        {
            case 2:
                GameManagerGlobal.i.numeroJugadores = 2;
                aux = 2;
                break;

            case 3:
                GameManagerGlobal.i.numeroJugadores = 3;
                aux = 3;
                break;

            case 4:
                GameManagerGlobal.i.numeroJugadores = 4;
                aux = 4;
                break;

            default:
                break;
        }

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
}
