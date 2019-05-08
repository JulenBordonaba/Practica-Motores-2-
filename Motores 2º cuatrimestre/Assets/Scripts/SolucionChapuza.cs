using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SolucionChapuza : MonoBehaviour
{
    //script chapucero para arreglar un problema en el que dos personas hemos usados variables distintas para controlar lo mismo

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        print("active players: " + G.activePlayers);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    
    void Update()
    {
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        G.activePlayers = GameManagerGlobal.i.numeroJugadores;
        print("active players: " + G.activePlayers);
    }
    

    //private void OnLevelWasLoaded(int level)
    //{

    //    G.activePlayers = GameManagerGlobal.i.numeroJugadores;
    //    print("active players: " + G.activePlayers);
    //}


}
