using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCount : MonoBehaviour
{
    [Tooltip("Arrastra la caja de texto que va a mostrar el tiempo")]
    public Text timeText;
    [Tooltip("Establece, en segundos, la cuentra atrás del tiempo")]
    public float time;
    public static TimeCount i;//variable para poder hacerse referencia así mismo y acceder desde otras clases

    private int timeNoFloat;//contiene el tiempo sin decimales
    private int minutes;//almacena solo los minutos
    private int seconds;//almacena solo los segundos

    // Start is called before the first frame update
    void Start()
    {
        i = this;//this soy yo
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;//va restando el tiempo que transcurre
        timeNoFloat = (int)time;//guardo el valor sin decimales
        minutes = timeNoFloat / 60;//guardo solo los minutos
        seconds = timeNoFloat - (minutes * 60);//guardo solo los segundos
        if(seconds<10)//si hay menos de 10 segundos añade un 0. Para que el tiempo se vea en este formato 0:00
            timeText.text = minutes.ToString() + ":0" + seconds.ToString();//mostrar el tiempo con formato digital en la caja de texto
        else
            timeText.text = minutes.ToString() + ":" + seconds.ToString();//mostrar el tiempo con formato digital en la caja de texto
    }
}
