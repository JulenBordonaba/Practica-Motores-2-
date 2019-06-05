using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameQuit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Quit());//Da unos segundos antes de cerrar el juego, ya que se ha acabado
    }

    IEnumerator Quit()
    {
        yield return new WaitForSeconds(5);//esperar segundos antes de la siguiente activación
        Application.Quit();
    }

}
