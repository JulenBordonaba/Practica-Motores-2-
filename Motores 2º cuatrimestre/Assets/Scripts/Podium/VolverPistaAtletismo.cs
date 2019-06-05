using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VolverPistaAtletismo : MonoBehaviour
{
    public void Volver()
    {
        if (!GameManagerGlobal.i.FinDeLaCarrera)
        {
            GameManagerGlobal.i.finPodio = true;
            SceneManager.LoadScene("PistaAtletismo");
        }
        else
        {
            SceneManager.LoadScene("Creditos");
        }
    }
}
