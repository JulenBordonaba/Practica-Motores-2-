using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   

public class ajustarTextoASlider : MonoBehaviour
{

    public Slider slider;

    // Update is called once per frame
    void Update()
    {
        int aux;
        aux = (int)slider.value;
        gameObject.GetComponent<Text>().text = aux.ToString();
    }
}
