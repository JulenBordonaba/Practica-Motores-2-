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

    /*private bool check0 = false;
    private bool check1 = false;
    private bool check2 = false;
    private bool check3 = false;*/

    /*private int dir0 = -1;
    private int dir1 = -1;
    private int dir2 = -1;
    private int dir3 = -1;*/

    /*private int casilla0=5;
    private int casilla1=6;
    private int casilla2=7;
    private int casilla3=8;*/

    
    private Vector4 direct;
    private Vector4 casilla;
    //private Vector4 choque;

    private int k,j;


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

        if ((direct[0] >= 0 && direct[1] >= 0 && direct[2] >= 0 && direct[3] >= 0 )|| time == 0)
        {
            for (j = 0; j == 4; j++)
            {
                for (k = 0; k == 4; k++)
                {
                    if (j != k)
                    {
                        if (casilla[j] == casilla[k]) { direct[j] = direct[j] + 4;  }
                    }
                }
            }

            for (j = 0; j == 4; j++) if(direct[j]>3) casilla[j] = j + 5;

        }
        PlayerController_Sacos.jugadores.
    }

    IEnumerator Second()
    {
        yield return new WaitForSeconds(1f);
        time -= 1;
        intime = false;
    }

    public void Mover(int jugador, int dir)
    {
        switch(jugador)
        {
            case 0:
                //check0 = true;
               direct[0] = dir;
                switch (dir) { case 1: casilla[0] = 4;break; case 2: casilla[0] = 0; break; case 3: casilla[0] = 1; break; }
                break;

            case 1:
                //check1 = true;
                direct[1] = dir;
                switch (dir) { case 0: casilla[1] = 4; break; case 3: casilla[1] = 0; break; case 2: casilla[1] = 3; break; }
                break;

            case 2:
                //check2 = true;
                direct[2] = dir;
                switch (dir) { case 0: casilla[2] = 0; break; case 1: casilla[2] = 3; break; case 3: casilla[2] = 2; break; }
                break;

            case 3:
                //check3 = true;
                direct[3] = dir;
                switch (dir) { case 0: casilla[3] = 1; break; case 1: casilla[3] = 0; break; case 2: casilla[3] = 2; break; }
                break;
        }


    }

}
