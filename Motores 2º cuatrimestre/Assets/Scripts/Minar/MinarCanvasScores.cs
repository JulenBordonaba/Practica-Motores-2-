using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinarCanvasScores : MonoBehaviour
{
    [Tooltip("Jugador al que pertenece el UI")]
    public GameObject player;
    [Tooltip("Texto donde se van a mostrar los puntos que tiene el jugador")]
    public Text pointsText;

    // Update is called once per frame
    void Update()
    {
       pointsText.text = player.GetComponent<MiniGameScores>().points.ToString();//actualiza el UI con los puntos de cada jugador
    }
}
