using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Disparos
{
    public class GameManager : MonoBehaviour
    {
        public Player[] jugadores;
        public int eliminatedPlayers = 0;

        // Start is called before the first frame update
        void Start()
        {
            jugadores = new Player[G.activePlayers];
            List<GameObject> players = new List<GameObject>(GameObject.FindGameObjectsWithTag("Player"));

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].GetComponent<Player>())
                {
                    if (players[i].GetComponent<Player>().numPlayer < G.activePlayers)
                    {
                        jugadores[players[i].GetComponent<Player>().numPlayer] = players[i].GetComponent<Player>();
                    }
                }
            }
            eliminatedPlayers = 0;
        }

    }
}



