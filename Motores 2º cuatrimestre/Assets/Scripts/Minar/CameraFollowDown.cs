using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowDown : MonoBehaviour
{
    [Tooltip("Camara que va a seguir a los jugadores")]
    public Camera camera;
    [Tooltip("La lista se generará a partir de una variable global para todo el juego que tiene la cantidad de jugadores que estan jugando")]
    public List<GameObject> players = new List<GameObject>();//
    [Tooltip("El margen que deja la camara por enciama de los jugadores. -3 es un buen número.")]
    public float cameraDisntaceWithTarget;

    // Update is called once per frame
    void Update()
    {
        float firstDown=6f;//variable auxiliar con el valor del jugador que se encuentra más abajo en la pantalla
        Vector3 cameraPosition = camera.transform.position;
        foreach (GameObject player in players)//for para recorrer la lista de jugadores
        {
            if (player)
            {
                if (player.transform.position.y <= firstDown) firstDown = player.transform.position.y;//si es el jugador con la posición mas baja se almacena en la variable auxiliar
            }
            
        }
        cameraPosition.y = firstDown - cameraDisntaceWithTarget;
        camera.transform.position = cameraPosition;
    }
}
