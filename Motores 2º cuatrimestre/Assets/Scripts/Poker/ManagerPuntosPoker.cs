using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerPuntosPoker : MonoBehaviour
{

    public int puntos;
    public Text puntosText;

    public void Update()
    {
        puntosText.text = puntos.ToString();
    }

}
