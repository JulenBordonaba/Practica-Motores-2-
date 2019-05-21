using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerDerby : MonoBehaviour
{
    private int llegados = G.activePlayers;
    private int llegados1 = 1;
    public GameObject[] jugadores;

   /* private void Awake()
    {
        for (int i = 0; i <= 3; i++)
        {
            if(jugadores[i].activeInHierarchy == true)
                llegados++;
        }
    }*/

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
