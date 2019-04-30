using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        G.activePlayers = 1;
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
        time -= Time.deltaTime;
        timeText.text = Mathf.FloorToInt(time).ToString();

        foreach(Marcador m in marcadores)
        {
            if(m.gameObject.activeInHierarchy)
            {
                marcadoresText[m.jugador].text = m.puntos.ToString();
            }
            
        }

        if(time<=0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        int[] posiciones = new int[G.activePlayers];
        for(int i=0;i<posiciones.Length;i++)
        {
            posiciones[i] = i;
        }
        for (int j = 0; j < posiciones.Length; j++)
        {
            for (int i = 0; i < posiciones.Length - 1; i++)
            {
                if (marcadores[i].puntos < marcadores[i + 1].puntos)
                {
                    int aux = marcadores[i].jugador;
                    marcadores[i].jugador = marcadores[i + 1].jugador;
                    marcadores[i + 1].jugador = aux;
                }
            }
        }

        for(int i=0;i<4;i++)
        {
            if(i<G.activePlayers)
            {
                G.positions[posiciones[i]] = i;
            }
            else
            {
                G.positions[i] = 4;
            }
        }
        
    }

}
