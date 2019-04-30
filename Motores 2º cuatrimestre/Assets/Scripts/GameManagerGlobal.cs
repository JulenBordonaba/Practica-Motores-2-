using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerGlobal : MonoBehaviour
{
    public int numeroJugadores;
    [Tooltip("Arrastra los gameObject de los jugadores")]
    public List<GameObject> jugadores = new List<GameObject>();
    public static GameManagerGlobal i;


    // Start is called before the first frame update
    void Start()
    {
        i = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
