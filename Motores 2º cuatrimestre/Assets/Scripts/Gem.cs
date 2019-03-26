﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [Tooltip("Puntos que otorga cada gema al ser recogida")]
    public int points;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            Destroy(gameObject);//se destruye la gema
            other.gameObject.GetComponent<MiniGameScores>().points += points;//suma puntos al jugador
            //animación gema al ser recogida
        }
    }
}
