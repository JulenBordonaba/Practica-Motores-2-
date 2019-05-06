using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerAtletismo : MonoBehaviour
{
    [Header("Corredores")]
    [Tooltip("Arrastra los gameObject de los jugadores")]
    public List<GameObject> corredores = new List<GameObject>();
    [Header("Camaras")]
    [Tooltip("Arrastra la camara que sigue a los jugadores")]
    public GameObject camara;
    [Header("Animacion")]
    [Tooltip("Segundos que dura la animación antes de activar el boton")]
    public float seconds;
    [Tooltip("Velocidad a la que se van a mover y por tanto la distancia que recorren. 5 es un buen número")]
    public float velocidad;
    [Header("Canvas")]
    [Tooltip("Arrastra el canvas de elegir numero de jugadores")]
    public GameObject canvasNumeroJugadores;
    [Tooltip("Arrastra el canvas de elegir razas")]
    public GameObject canvasRazas;
    [Tooltip("Arrastra el canvas de elegir minijuego")]
    public GameObject canvasElegirMinijuego;
    [Header("Boton continuar")]
    [Tooltip("Arrastra el boton de continuar")]
    public Button btNextMinigame;

    private void Update()
    {
        if (GameManagerGlobal.i.finPodio)
        {
            canvasNumeroJugadores.SetActive(false);
            canvasRazas.SetActive(false);
            camara.SetActive(true);
            GameManagerGlobal.i.finPodio = false;
            GameManagerGlobal.i.siguienteMinijuego++;
            if(GameManagerGlobal.i.siguienteMinijuego >= GameManagerGlobal.i.minijuegos.Count)
                GameManagerGlobal.i.siguienteMinijuego = 0;
            StartCoroutine(IEMoverCorredores());
        }
    }

    IEnumerator IEMoverCorredores()
    {
        yield return new WaitForSeconds(seconds);//esperar segundos antes de la siguiente activación
        MoverCorredores();
    }

    private void MoverCorredores()
    {
        foreach (GameObject corredor in corredores)
        {
            corredor.GetComponent<Rigidbody>().velocity += new Vector3(velocidad, 0, 0);
            switch (G.positions[corredor.GetComponent<Player>().numPlayer])
            {
                case 1:
                    StartCoroutine(IEPararCorredor(4f,corredor));
                    break;

                case 2:
                    StartCoroutine(IEPararCorredor(3f, corredor));
                    break;

                case 3:
                    StartCoroutine(IEPararCorredor(2f, corredor));
                    break;

                case 4:
                    StartCoroutine(IEPararCorredor(1f, corredor));
                    break;

                default:
                    break;
            }
        }
        LimpiarPosiciones();
        StartCoroutine(IEMinijuego());
    }

    IEnumerator IEPararCorredor(float secs, GameObject corredor)
    {
        yield return new WaitForSeconds(secs);//esperar segundos antes de la siguiente activación
        PararCorredor(corredor);
    }

    private void PararCorredor(GameObject corredor)
    {
        corredor.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    }

    IEnumerator IEMinijuego()
    {
        yield return new WaitForSeconds(5f);//esperar segundos antes de la siguiente activación
        btNextMinigame.gameObject.SetActive(true);
        btNextMinigame.Select();
    }

    private void LimpiarPosiciones()
    {
        for (int i = 0; i < 4; i++)
            G.positions[i] = 0;
    }
}
