using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeCountParacaidas : MonoBehaviour
{
    [Tooltip("Arrastra el objeto que va a hacer de suelo que desaparece tras el temporizador")]
    public GameObject platform;
    [Tooltip("Arrastra la caja de texto que va a mostrar el tiempo")]
    public Text timeText;
    [Tooltip("Establece, en segundos, la cuentra atrás del tiempo")]
    public float time;
    public static TimeCountParacaidas i;//variable para poder hacerse referencia así mismo y acceder desde otras clases

    private int timeNoFloat;//contiene el tiempo sin decimales
    private int minutes;//almacena solo los minutos
    private int seconds;//almacena solo los segundos

    public UnityEvent onTimeEnd = new UnityEvent();

    
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
        if (seconds >= 1)//no muestra el tiempo en negativo. Para al llegar a 0
        {

                timeText.text = seconds.ToString();//mostrar el tiempo con formato digital en la caja de texto
        }
        else
        {
            timeText.text = "";
            //platform. comentado porque daba error
           
            onTimeEnd.Invoke();

        }

    }


}
