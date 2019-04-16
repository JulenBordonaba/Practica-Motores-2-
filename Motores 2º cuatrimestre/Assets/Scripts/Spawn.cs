using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Raza
{
    chino, mexicano
}

public class Spawn : MonoBehaviour
{
    public GameObject playerPrefab;


    public Raza[] raza = new Raza[4];
    public GameObject[] spawns = new GameObject[4];
    public float rotY = 0;
    private void Awake()
    {
        for(int i=0;i<G.activePlayers;i++)
        {
            Instantiate(playerPrefab, spawns[i].transform.position, Quaternion.Euler(0,rotY,0));
        }
    }
}
