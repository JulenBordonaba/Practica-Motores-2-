using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contar_puntos : MonoBehaviour
{
    public int score;
    public Text scoretext;
    public float Tiempo;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
       // scoretext.text = "score: " + score;
        Tiempo -= Time.deltaTime;
        if (Tiempo == 0)
            print("Se acabó");
    }
   
}
