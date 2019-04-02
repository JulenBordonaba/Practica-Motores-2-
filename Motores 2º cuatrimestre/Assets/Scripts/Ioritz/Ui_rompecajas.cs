using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_rompecajas : MonoBehaviour
{

    static public Ui_rompecajas i;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    
    public Text time;
    public Text scorep1;
    public Text scorep2;
    public Text scorep3;
    public Text scorep4;
    public Text Countdown;



    // Use this for initialization
    void Start()
    {
        i = this;
    }

    // Update is called once per frame
    void Update()
    {
        scorep1.text = "" + player1.GetComponent<MiniGameScores>().points.ToString();
        scorep2.text = "" + player2.GetComponent<MiniGameScores>().points.ToString();
        scorep3.text = "" + player3.GetComponent<MiniGameScores>().points.ToString(); 
        scorep4.text = "" + player4.GetComponent<MiniGameScores>().points.ToString();
        time.text = "" + GM_rompecajas.i.time;
    }
}
