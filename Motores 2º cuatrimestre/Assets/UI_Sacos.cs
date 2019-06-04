using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Sacos : MonoBehaviour
{
    static public UI_Sacos i;
    [Tooltip("Arrastrar object del Jugador 1")]
    public GameObject player1;
    [Tooltip("Arrastrar object del Jugador 2")]
    public GameObject player2;
    [Tooltip("Arrastrar object del Jugador 3")]
    public GameObject player3;
    [Tooltip("Arrastrar object del Jugador 4")]
    public GameObject player4;

    [Tooltip("Arrastrar text del texto")]
    public Text time;
    [Tooltip("Arrastrar text de los puntos del jugador 1")]
    public Text scorep1;
    [Tooltip("Arrastrar text de los puntos del jugador 2")]
    public Text scorep2;
    [Tooltip("Arrastrar text de los puntos del jugador 3")]
    public Text scorep3;
    [Tooltip("Arrastrar text de los puntos del jugador 4")]
    public Text scorep4;

    // Start is called before the first frame update
    void Start()
    {
        i = this;

    }

    // Update is called once per frame
    void Update()
    {
        scorep1.text = "" + player1.GetComponent<MiniGameScores>().points.ToString();//Se actualizan los puntos y el tiempo
        scorep2.text = "" + player2.GetComponent<MiniGameScores>().points.ToString();
        scorep3.text = "" + GM_Sacos.i.round;
        scorep4.text = "" + GM_Sacos.i.check;
        time.text = "" + GM_Sacos.i.time;
    }
}
