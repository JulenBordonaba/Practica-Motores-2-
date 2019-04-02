using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_rompecajas : MonoBehaviour
{

    static public Ui_rompecajas i;



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
        scorep1.text = "" + Hammer.i.score;
        //scorep2.text = "" + Hammer.i.score;
        //scorep3.text = "" + Hammer.i.score;
        //scorep4.text = "" + Hammer.i.score;
        time.text = "" + GM_rompecajas.i.time;
    }
}
