using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerAtletismo : MonoBehaviour
{
    [Header("Corredores")]
    [Tooltip("Arrastra los gameObject de los jugadores")]
    public List<GameObject> corredores = new List<GameObject>();
    [Header("Camaras")]
    [Tooltip("Arrastra la camara que sigue a los jugadores")]
    public GameObject camaraSeguir;
    public GameObject camaraPantalla;
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

    [Header("Listas de posiciones")]
    List<GameObject> ganadores = new List<GameObject>();//lista a la que se añadirán todos los ganadores
    List<GameObject> segundos = new List<GameObject>();//lista a la que se añadirán todos los jugadores en segunda posicion
    List<GameObject> terceros = new List<GameObject>();//lista a la que se añadirán todos los jugadores en segunda posicion
    List<GameObject> cuartos = new List<GameObject>();//lista a la que se añadirán todos los jugadores en segunda posicion

    [Header("Fin Juego")]
    [Tooltip("Booleana para controlar el fin del juego. No tocar, es mejor dejarla en false")]
    public bool finJuego;//booleana auxiliar para controlar que el juego ya ha acabado y no llamar constantemente a la función finDeJuego

    private bool llegaAMeta = false;
    private int jugadoresFinalizados = 0;

    private void Update()
    {
        if (GameManagerGlobal.i.finPodio)//cuando se vuelve desde la escena podio
        {
            canvasNumeroJugadores.SetActive(false);//desactivar los canvas no necesarios
            canvasRazas.SetActive(false);
            camaraPantalla.SetActive(false);//activar la camara que corresponde
            camaraSeguir.SetActive(true);//activar la camara que corresponde
            GameManagerGlobal.i.finPodio = false;
            GameManagerGlobal.i.siguienteMinijuego++;//aumentamos el contador para el siguiente minijuego
            if(GameManagerGlobal.i.siguienteMinijuego >= GameManagerGlobal.i.minijuegos.Count)//si se han hecho todos repetimos el ciclo
                GameManagerGlobal.i.siguienteMinijuego = 0;
            StartCoroutine(IEMoverCorredores());//mover a los jugadores
        }

        int contadorJugadoresAcabados = 0;//un contador que suma jugadores eliminados y/o en meta
        foreach (GameObject player in corredores)//bucle para recorrer todos los jugadores
        {
            //si el jugador ha llegado a meta o está eliminado se suman al contador
            if (player.GetComponent<MiniGameScores>().onGoal == true)
            {
                contadorJugadoresAcabados++;//se añade uno al contador para controlar los jugadores en meta para ver si acaba el juego
                llegaAMeta = true;//variable para controlar si un jugador a llegado a meta
            }
        }

        if (llegaAMeta)//si un jugador ha llegado a meta se guarda su posicion en la carrera
        {
            llegaAMeta = false;
            jugadoresFinalizados++;//se añade uno al contador de los jugadores en meta para ir añadiendolos a ganador, segundo...
            AnadirGanadores();//función que añade a cada jugador a su posicion, en la pista de atletismo, según llegan al final   
        }

        //si el contador es igual al numero de jugadores
        if (contadorJugadoresAcabados == GameManagerGlobal.i.numeroJugadores - 1)//puede que haya que cambiar las referencias de players.Capacity por el numero de jugadores del GameManager
        {
            //si no se habia acabado el juego todavía
            if (!finJuego)
                FinDeJuego();//llamar a la función que controla el fin de juego. Ganador, posiciones, llamar al podio...
        }
    }

    private void AnadirGanadores()
    {
        foreach (GameObject player in corredores)//bucle para recorrer todos los jugadores
        {
            if (player.GetComponent<MiniGameScores>().onGoal == true)
            {
                switch (jugadoresFinalizados)//según cuantos corredores vayan llegando a meta se añade su posicion
                {
                    case 1:
                        player.GetComponent<MiniGameScores>().position = 1;//se añade a la primera posicion
                        ganadores.Add(player);//se añade a la lista de segundos
                        break;

                    case 2:
                        player.GetComponent<MiniGameScores>().position = 2;//se añade a la primera posicion
                        segundos.Add(player);//se añade a la lista de segundos
                        break;

                    case 3:
                        player.GetComponent<MiniGameScores>().position = 3;//se añade a la primera posicion
                        terceros.Add(player);//se añade a la lista de segundos
                        break;

                    case 4:
                        player.GetComponent<MiniGameScores>().position = 4;//se añade a la primera posicion
                        cuartos.Add(player);//se añade a la lista de segundos
                        break;


                    default:
                        break;
                }
            }
        }
    }

    private void FinDeJuego()
    {
        finJuego = true;
        //añadir al podio los jugadores
        foreach (GameObject player in ganadores)
        {
            G.positions[player.GetComponent<Player>().numPlayer] = player.GetComponent<MiniGameScores>().position;
        }
        foreach (GameObject player in segundos)
        {
            G.positions[player.GetComponent<Player>().numPlayer] = player.GetComponent<MiniGameScores>().position;
        }
        foreach (GameObject player in terceros)
        {
            G.positions[player.GetComponent<Player>().numPlayer] = player.GetComponent<MiniGameScores>().position;
        }
        foreach (GameObject player in cuartos)
        {
            G.positions[player.GetComponent<Player>().numPlayer] = player.GetComponent<MiniGameScores>().position;
        }

        for(int i=0; i<4; i++)
        {
            Debug.Log("jugador : " + i + ", posicion: " + corredores[i].GetComponent<MiniGameScores>().position);
        }

        //cargar siguiente escena
        SceneManager.LoadScene("Podium2");
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
            if (!corredor.GetComponent<MiniGameScores>().onGoal)
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
            else
                StartCoroutine(IEPararCorredor(0f, corredor));
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
