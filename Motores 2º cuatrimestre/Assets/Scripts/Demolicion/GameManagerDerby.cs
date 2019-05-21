using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerDerby : MonoBehaviour
{
    private int llegados = GameManagerGlobal.i.numeroJugadores;
    private int llegados1 = 1;
    public GameObject[] jugadores;

   

    public void Posicionar(GameObject other)
    {
        G.positions[other.gameObject.GetComponent<Player>().numPlayer] = llegados;
        llegados -= 1;  llegados1 += 1;
        other.SetActive(false);

        if (llegados1 >= G.activePlayers )
        {

            for (int i = 0; i <= 3; i++)
            {
                if (jugadores[i].activeInHierarchy == true)
                    G.positions[jugadores[i].GetComponent<Player>().numPlayer] = 1;
            }
            SceneManager.LoadScene("Podium2");
        }
    }
}
