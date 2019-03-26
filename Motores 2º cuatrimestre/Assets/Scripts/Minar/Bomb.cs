using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Tooltip("Puntos que resta cada bomba al ser recogida")]
    public int points;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);//se destruye la bomba
            collision.gameObject.GetComponent<MiniGameScores>().points += points;//resta puntos al jugador
            //animación bomba al ser recogida
            //animacion jugador al ser golpeado por la bomba, durante la animación no se moverá
        }
    }
}
