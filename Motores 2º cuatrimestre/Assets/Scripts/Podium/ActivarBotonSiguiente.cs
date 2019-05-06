using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivarBotonSiguiente : MonoBehaviour
{
    [Tooltip("Arrastra el boton de siguiente/play/continuar")]
    public Button siguiente;
    [Tooltip("Segundos que dura la animación antes de activar el boton")]
    public float seconds;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ActivarBoton());
    }

    IEnumerator ActivarBoton()
    {
        yield return new WaitForSeconds(seconds);//esperar segundos antes de la siguiente activación
        siguiente.gameObject.SetActive(true);
        siguiente.Select();
    }
}
