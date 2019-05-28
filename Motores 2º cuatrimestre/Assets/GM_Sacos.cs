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

    [Tooltip("Arrastra los gameObject de los jugadores")]
    public List<GameObject> players = new List<GameObject>();//
    List<GameObject> ganadores = new List<GameObject>();//lista a la que se añadirán todos los ganadores
    List<GameObject> segundos = new List<GameObject>();//lista a la que se añadirán todos los jugadores en segunda posicion
    List<GameObject> terceros = new List<GameObject>();//lista a la que se añadirán todos los jugadores en segunda posicion
    List<GameObject> cuartos = new List<GameObject>();//lista a la que se añadirán todos los jugadores en segunda posicion

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

    private int k, j;
    private int check = 0;
    private bool ok = false;

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
        if (ok)
        {
            foreach (GameObject b in players)
            {
                switch (b.GetComponent<PlayerController_Sacos>().direccion)
                {
                    case -1:
                        b.GetComponent<Transform>().Translate(0, -0.1f, 0);
                        break;

                    case 0:
                        b.GetComponent<Transform>().Translate(0, 0, -0.1f);
                        break;

                    case 1:
                        b.GetComponent<Transform>().Translate(0.1f, 0, 0);
                        break;

                    case 2:
                        b.GetComponent<Transform>().Translate(0, 0, 0.1f);
                        break;

                    case 3:
                        b.GetComponent<Transform>().Translate(-0.1f, 0, 0);
                        break;

                    case 4:
                        b.GetComponent<Transform>().Translate(0, 0.1f, 0);
                        break;
                    case 5:
                        b.GetComponent<Transform>().Translate(0, 0.1f, 0);
                        break;
                    case 6:
                        b.GetComponent<Transform>().Translate(0, 0.1f, 0);
                        break;
                    case 7:
                        b.GetComponent<Transform>().Translate(0, 0.1f, 0);
                        break;


                }

            }
        }


        if (intime == false && time > 0)
        {
            intime = true;
            StartCoroutine(Second());
        }

        /*if ((direct[0] >= 0 && direct[1] >= 0 && direct[2] >= 0 && direct[3] >= 0) || time == 0)
        {
            for (j = 0; j == 4; j++)
            {
                for (k = 0; k == 4; k++)
                {
                    if (j != k)
                    {
                        if (casilla[j] == casilla[k]) { direct[j] = direct[j] + 4; }
                    }
                }
            }

            for (j = 0; j == 4; j++) if (direct[j] > 3) casilla[j] = j + 5;

        }*/

        check = 1;
        foreach (GameObject b in players)
        {
            if (b.GetComponent<PlayerController_Sacos>().direccion < 0) check *= 0;
        }
        if (time == 0) check = 1;
        if (check == 1)
        {
            foreach (GameObject b in players)
            {
                b.GetComponent<PlayerController_Sacos>().disabled = true;
                switch (b.GetComponent<PlayerController_Sacos>().playernum) {
                    case 0:
                        switch (b.GetComponent<PlayerController_Sacos>().direccion) { case 1: b.GetComponent<PlayerController_Sacos>().casilla = 4; break; case 2: b.GetComponent<PlayerController_Sacos>().casilla = 0; break; case 3: b.GetComponent<PlayerController_Sacos>().casilla = 1; break; }
                        break;

                    case 1:
                        switch (b.GetComponent<PlayerController_Sacos>().direccion) { case 0: b.GetComponent<PlayerController_Sacos>().casilla = 4; break; case 3: b.GetComponent<PlayerController_Sacos>().casilla = 0; break; case 2: b.GetComponent<PlayerController_Sacos>().casilla = 3; break; }
                        //switch (dir) { case 0: casilla[1] = 4; break; case 3: casilla[1] = 0; break; case 2: casilla[1] = 3; break; }
                        break;

                    case 2:
                        switch (b.GetComponent<PlayerController_Sacos>().direccion) { case 0: b.GetComponent<PlayerController_Sacos>().casilla = 0; break; case 1: b.GetComponent<PlayerController_Sacos>().casilla = 3; break; case 3: b.GetComponent<PlayerController_Sacos>().casilla = 2; break; }
                        // switch (dir) { case 0: casilla[2] = 0; break; case 1: casilla[2] = 3; break; case 3: casilla[2] = 2; break; }
                        break;

                    case 3:
                        switch (b.GetComponent<PlayerController_Sacos>().direccion) { case 0: b.GetComponent<PlayerController_Sacos>().casilla = 1; break; case 1: b.GetComponent<PlayerController_Sacos>().casilla = 0; break; case 2: b.GetComponent<PlayerController_Sacos>().casilla = 2; break; }
                        //switch (dir) { case 0: casilla[3] = 1; break; case 1: casilla[3] = 0; break; case 2: casilla[3] = 2; break; }
                        break;
                }

            }

            foreach (GameObject b in players)
            {
                foreach (GameObject c in players)
                {
                    if (b != c)
                    {
                        if (b.GetComponent<PlayerController_Sacos>().casilla == c.GetComponent<PlayerController_Sacos>().casilla) b.GetComponent<PlayerController_Sacos>().direccion += 4;
                    }
                }

            }
            foreach (GameObject b in players)
            {
                if (b.GetComponent<PlayerController_Sacos>().direccion > 3) b.GetComponent<PlayerController_Sacos>().casilla = b.GetComponent<PlayerController_Sacos>().playernum + 5;
            }

            StartCoroutine(Anim());
            StartCoroutine(Estart());
           
        }
    }

    IEnumerator Second()
    {
        yield return new WaitForSeconds(1f);
        time -= 1;
        intime = false;
    }

    IEnumerator Anim()
    {
        /*ejecutar animaciones segun sun parametro direccion
         * -1 no hara nada
         * 0 salto hacia abajo
         * 1 salto derecha
         * 2 salto arriba
         * 3 salto izquierda
         * 4 choque abajo
         * 5 choque derecha
         * 6 choque arriba
         * 7 choque izquierda*/
        ok = true;
        
        yield return new WaitForSeconds(6f);
          
    }

    IEnumerator Estart()
    {

        yield return new WaitForSeconds(3f);
        foreach (GameObject b in players)
        {
            b.GetComponent<PlayerController_Sacos>().direccion = -1;
            b.GetComponent<PlayerController_Sacos>().casilla = b.GetComponent<PlayerController_Sacos>().playernum + 5;
            b.GetComponent<PlayerController_Sacos>().disabled = false;
        }

        check = 0;
        round++;
        time = roundDuration;
    }

    /*public void Mover(int jugador, int dir)
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


    }*/

}
