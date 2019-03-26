using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class G {


    public static Dictionary<int, int> positions = new Dictionary<int, int>
    //dicionario con las posiciones de los jugadores en los minijuegos
    {//la columna de la izquieda es el jugador, la columna de la derecha es la poscición en la que ha quedado en el último minijuego
     // en la columna de la derecha 0 significa que no participa, 1 primera posición, 2 segunda posición, 3 tercera posición 4 cuarta posición
        {0,0 },
        {1,0 },
        {2,0 },
        {3,0 }
    };
    //public static int[] positions = new int[4];

    public static int activePlayers = 4;

    public static float ClampAngle(float angle, float min, float max)
    {


        angle = Mathf.Repeat(angle, 360);
        min = Mathf.Repeat(min, 360);
        max = Mathf.Repeat(max, 360);
        bool inverse = false;
        float tmin = min;
        float tangle = angle;
        if (min > 180)
        {
            inverse = !inverse;
            tmin -= 180;
        }
        if (angle > 180)
        {
            inverse = !inverse;
            tangle -= 180;
        }
        bool result = !inverse ? tangle > tmin : tangle < tmin;
        if (!result)
            angle = min;

        inverse = false;
        tangle = angle;
        float tmax = max;
        if (angle > 180)
        {
            inverse = !inverse;
            tangle -= 180;
        }
        if (max > 180)
        {
            inverse = !inverse;
            tmax -= 180;
        }

        result = !inverse ? tangle < tmax : tangle > tmax;
        if (!result)
            angle = max;
        return angle;
    }
}
