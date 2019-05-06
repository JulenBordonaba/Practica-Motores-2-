using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VolverPistaAtletismo : MonoBehaviour
{
    public void Volver()
    {
        GameManagerGlobal.i.finPodio = true;
        SceneManager.LoadScene("PistaAtletismo");
    }
}
