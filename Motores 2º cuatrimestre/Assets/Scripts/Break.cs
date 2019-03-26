using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Breakable" && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(other.gameObject);//se destruye el bloque
            //animación jugador romper cubo
            //animación cubo al ser destruido
        }
    }
}
