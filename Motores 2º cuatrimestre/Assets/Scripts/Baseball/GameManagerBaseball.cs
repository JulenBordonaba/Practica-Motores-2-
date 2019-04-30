using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerBaseball : MonoBehaviour
{
    public Text timeText;
    public Text[] marcadoresText = new Text[4];
    public Marcador[] marcadores = new Marcador[4];
    public GameObject[] players = new GameObject[4];
    public int numPlayers;

    public float time;

    // Start is called before the first frame update
    void Start()
    {
        G.activePlayers = numPlayers;
        for (int i = 0; i < 4; i++)
        {
            marcadoresText[i].gameObject.SetActive(i < G.activePlayers);
            marcadores[i].gameObject.SetActive(i < G.activePlayers);
            players[i].SetActive(i < G.activePlayers);
        }
        timeText.text = Mathf.FloorToInt(time).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        timeText.text = Mathf.FloorToInt(time).ToString();

        foreach (Marcador m in marcadores)
        {
            if (m.gameObject.activeInHierarchy)
            {
                marcadoresText[m.jugador].text = m.puntos.ToString();
            }

        }

        if (time <= 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        //int[] posiciones = new int[G.activePlayers];
        //for(int i=0;i<posiciones.Length;i++)
        //{
        //    posiciones[i] = i;
        //}
        //for (int j = 0; j < posiciones.Length; j++)
        //{
        //    for (int i = 0; i < posiciones.Length; i++)
        //    {
        //        if (marcadores[i].puntos > marcadores[i + 1].puntos)
        //        {
        //            int aux = marcadores[i].jugador;
        //            marcadores[i].jugador = marcadores[i + 1].jugador;
        //            marcadores[i + 1].jugador = aux;
        //        }
        //    }
        //}

        //int[] playerPosition = new int[G.activePlayers]; //la posición dentro del array representa el numJugador y el valor la posición en la que ha quedado

        //for (int i = 0 ; i < playerPosition.Length; i++)
        //{
        //    playerPosition[i] = i+1;
        //}

        Dictionary<int, int> posiciones = new Dictionary<int, int>
        {
            {0,1 },
            {1,2 },
            {2,3 },
            {3,4 }
        };

        for (int i = 0; i < posiciones.Count; i++)
        {
            posiciones[i] = i+1;
        }

        for (int i = 0; i < posiciones.Count - 1; i++)
        {
            for (int j = 0; j < posiciones.Count; j++)
            {
                if (i != j)
                {
                    if (marcadores[i].puntos > marcadores[j].puntos)
                    {
                        if (posiciones[i] > posiciones[j])
                        {

                            posiciones[i] = posiciones[j];
                            for (int k = 0; k < posiciones.Count; k++)
                            {
                                if (posiciones[k] >= posiciones[i] && k != i)
                                {
                                    posiciones[k] += 1;
                                }
                            }

                        }
                        else if (posiciones[i] == posiciones[j])
                        {
                            for (int k = 0; k < posiciones.Count; k++)
                            {
                                if (posiciones[k] >= posiciones[j] && k != i)
                                {
                                    posiciones[k] += 1;
                                }
                            }
                        }
                    }
                    else if (marcadores[i].puntos == marcadores[j].puntos)
                    {
                        if(posiciones[i]<posiciones[j])
                        {
                            posiciones[j] = posiciones[i];
                        }
                        else if(posiciones[i] > posiciones[j])
                        {
                            posiciones[i] = posiciones[j];
                        }
                        //for (int k = 0; k < posiciones.Count; k++)
                        //{
                        //    if (posiciones[k] >= posiciones[j] && k != i && k != j)
                        //    {
                        //        posiciones[k] -= 1;
                        //    }
                        //}
                    }
                }
            }

        }


        int comprobados = 0;
        for(int i=1;i<posiciones.Count;i++)
        {
            if (comprobados >= posiciones.Count) break;
            bool hayPosicion = false;
            for(int j=0;j<posiciones.Count;j++)
            {
                if(posiciones[j]==i)
                {
                    comprobados += 1;
                    hayPosicion = true;
                }
            }
            if(!hayPosicion)
            {
                for (int j = 0; j < posiciones.Count; j++)
                {
                    if(posiciones[j]>i)
                    {
                        posiciones[j] -= 1;
                    }
                }
            }
        }


        G.positions = posiciones;


        for (int i = 0; i < 4; i++)
        {
            if (i >= G.activePlayers)
            {
                G.positions[i] = 4;
            }
        }





        SceneManager.LoadScene("Podium2");

    }

}
