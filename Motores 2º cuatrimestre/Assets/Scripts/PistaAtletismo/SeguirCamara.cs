using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCamara : MonoBehaviour
{
    [Tooltip("Arrastra la cCmara que va a seguir a los jugadores")]
    public Camera camara;
    [Tooltip("Arrastra los gameObject de los jugadores")]
    public List<GameObject> players = new List<GameObject>();//

    // Update is called once per frame
    void Update()
    {
        float derecha = -1000;//variable auxiliar con el valor del jugador que se encuentra más a la derecha en la pantalla
        float izquierda = 1000;//variable auxiliar con el valor del jugador que se encuentra más a la izquierda en la pantalla
        float arriba = 87f;
        float profundidad = -440f;
        Vector3 cameraPosition = camara.transform.position;
        for (int i = 0; i < GameManagerGlobal.i.numeroJugadores; i++)
        {
            if (players[i].transform.position.x <= izquierda) izquierda = players[i].transform.position.x;//si es el jugador con la posición mas a la izquierda se almacena en la variable auxiliar
        }
        for (int i = 0; i < GameManagerGlobal.i.numeroJugadores; i++)
        {
            if (players[i].transform.position.x >= derecha) derecha = players[i].transform.position.x;//si es el jugador con la posición mas a la izquierda se almacena en la variable auxiliar
        }
        float diferencia = (Mathf.Abs(izquierda / 2) - Mathf.Abs(derecha / 2));
        cameraPosition.x = izquierda + diferencia;
        cameraPosition.y = arriba / 5 + Mathf.Abs(diferencia * 0.4f);
        cameraPosition.z = profundidad / 5 - Mathf.Abs(diferencia * 0.6f);
        //Debug.Log(diferencia);
        camara.transform.position = cameraPosition;
    }
}
