using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_Sacos : MonoBehaviour
{
    static public GM_Sacos i;
    [Tooltip("Numero de rondas que dura el minijuego")]
    public int rounds;
    [Tooltip("Tiempo que durara cada ronda")]
    public int roundDuration;

    private int round; //Ronda actual
    private int time; //tiempo restante
    private bool intime = false;

    // Start is called before the first frame update
    void Start()
    {
        round = 1;
        i = this;
        time = roundDuration;
    }

    // Update is called once per frame
    void Update()
    {

        if (intime == false && time > 0)
        {

            intime = true;
            StartCoroutine(Second());
        }

    }

    IEnumerator Second()
    {
        yield return new WaitForSeconds(1f);
        time -= 1;
        intime = false;
    }

}
