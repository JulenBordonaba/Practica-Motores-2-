using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirCorredores : MonoBehaviour
{
    //variables para guardar los valores de cada corredor
    private Transform transformPlayer;
    private float weighPlayer;
    private float radiusPlayer;

    public void AsignarTargetsSeguidorCorredores()//por cada jugador en el juego se crea un target para el objetivo que sigue la camara de los corredores
    {
        for (int i = 0; i < GameManagerGlobal.i.numeroJugadores; i++)//recorre todos los corredores que participan
        {
            transformPlayer = GameManagerGlobal.i.jugadores[i].transform;
            weighPlayer = 1;
            radiusPlayer = 0;
            gameObject.GetComponent<CinemachineTargetGroup>().AddMember(transformPlayer, weighPlayer, radiusPlayer);//asigna los valores y añade el objetivo
        }
    }
}
