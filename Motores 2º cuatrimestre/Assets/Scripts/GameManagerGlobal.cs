using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerGlobal : MonoBehaviour
{
    public int numeroJugadores;
    [Tooltip("Arrastra los gameObject de los jugadores")]
    public List<GameObject> jugadores = new List<GameObject>();
    public static GameManagerGlobal i;
    public int elegirRazasJugadorActual;
    public GameObject inputMando;
    public GameObject inputTeclado;


    // Start is called before the first frame update
    void Start()
    {
        i = this;

        ComprobarMandoOTeclado();
    }

    // Update is called once per frame
    void Update()
    {


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
