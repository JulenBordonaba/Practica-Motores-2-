using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_rompecajas : MonoBehaviour
{

    static public GM_rompecajas i;
    [Tooltip("Tiempo que durara el minijuego")]
    public int time;

    private bool intime = false;


    // Use this for initialization
    void Start()
    {
        i = this;
    }

    void Update()
    {
        if (intime == false && time > 0)
        {

            intime = true;
            StartCoroutine(Second());
        }
    }
    //Probablemente la manera mas cutre de hacer un contador de segundos
    IEnumerator Second()
    {
        yield return new WaitForSeconds(1f);
        time -= 1;
        intime = false;
    }
}
