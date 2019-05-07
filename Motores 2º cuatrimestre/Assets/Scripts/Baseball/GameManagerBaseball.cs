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

    public float time;

    // Start is called before the first frame update
    void Start()
    {
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

        int[] playerPosition = new int[G.activePlayers]; //la posición dentro del array representa el numJugador y el valor la posición en la que ha quedado

        for (int i = 0 ; i < playerPosition.Length; i++)
        {
            playerPosition[i] = i+1;
        }

        for (int i = 0; i < playerPosition.Length-1; i++)
        {
            for (int j = 0; j < playerPosition.Length; j++)
            {
                if(i!=j)
                {
                    if (marcadores[i].puntos > marcadores[j].puntos)
                    {
                        if (playerPosition[i] > playerPosition[j])
                        {

                            playerPosition[i] = playerPosition[j];
                            for (int k = 0; k < playerPosition.Length;k++)
                            {
                                if (playerPosition[k]<=playerPosition[j] && k!=i)
                                {
                                    playerPosition[k] += 1;
                                }
                            }
                            
                        }
                        else if(playerPosition[i] == playerPosition[j])
                        {
                            for (int k = 0; k < playerPosition.Length; k++)
                            {
                                if (playerPosition[k] >= playerPosition[j] && k != i)
                                {
                                    playerPosition[k] += 1;
                                }
                            }
                        }
                    }
                    else if (marcadores[i].puntos == marcadores[j].puntos)
                    {
                        if(playerPosition[i]>playerPosition[j])
                        {

                            playerPosition[i] = playerPosition[j];
                        }
                        else if(playerPosition[i] < playerPosition[j])
                        {

                            playerPosition[j] = playerPosition[i];
                        }
                        //for (int k = 0; k < playerPosition.Length; k++)
                        //{
                        //    if (playerPosition[k] >= playerPosition[j] && k != i && k != j)
                        //    {
                        //        playerPosition[k] -= 1;
                        //    }
                        //}
                    }
                }
            }

        }

        for(int i=0;i<4;i++)
        {
            bool hayPosicion = false;
            
            for(int j=0;j<playerPosition.Length;j++)
            {
                if(playerPosition[j]==i+1)
                {
                    hayPosicion = true;
                }
            }

            if(!hayPosicion)
            {
                for (int j = 0; j < playerPosition.Length; j++)
                {
                    if (playerPosition[j] > i + 1)
                    {
                        playerPosition[j] -= 1;
                    }
                }
            }
        }


        for (int i = 0; i < 4; i++)
        {
            if (i >= G.activePlayers)
            {
                G.positions[i] = 4;
            }
            else
            {
                G.positions[i] = playerPosition[i];
            }
        }





        SceneManager.LoadScene("Podium2");

    }

}
