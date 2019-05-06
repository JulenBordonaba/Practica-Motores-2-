using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComprobarMandoTeclado : MonoBehaviour
{
    [Tooltip("Arrastra el event system para el mando")]
    public GameObject eventSystemMando;
    [Tooltip("Arrastra el event system para el teclado")]
    public GameObject eventSystemTeclado;
    // Start is called before the first frame update
    void Start()
    {
        ComprobarMandoOTeclado();
    }

    public void ComprobarMandoOTeclado()
    {
        if (InputManager.MandosConectados > 0)//Si hay mandos activa el event system del mando
        {
            eventSystemTeclado.SetActive(false);
            eventSystemMando.SetActive(true);
        }
        else//Si no hay mandos activa el event system del teclado
        {
            eventSystemTeclado.SetActive(true);
            eventSystemMando.SetActive(false);

        }
    }
}
