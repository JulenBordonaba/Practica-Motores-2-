using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_rompecajas : MonoBehaviour
{

    static public GM_rompecajas i;

    public int time;

    private bool intime = false;


    // Use this for initialization
    void Start()
    {
        i = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (intime == false && time > 0)
        {

            intime = true;
            StartCoroutine(Second());
        }
    }

    IEnumerator Second()
    {
        yield return new WaitForSeconds(1f);
        time -= 1;
        intime = false;
    }
}
