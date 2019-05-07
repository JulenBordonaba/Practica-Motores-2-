using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerLaberinto : MonoBehaviour
{
    public GameObject[] players = new GameObject[4];
    public bool[] llegados = new bool[4];



    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<4;i++)
        {
            llegados[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TimeEnd()
    {
        print("fin tiempo");
        for(int i=0;i<G.activePlayers;i++)
        {
            if(!llegados[i])
            {
                G.positions[i] = G.activePlayers;
            }
        }
        EndGame();
    }

    public void EndGame()
    {
        SceneManager.LoadScene("Podium2");
    }


}
