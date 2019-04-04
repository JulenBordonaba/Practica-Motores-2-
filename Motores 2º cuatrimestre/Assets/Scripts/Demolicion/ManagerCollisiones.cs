using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerCollisiones : MonoBehaviour
{
    [HideInInspector]
    public string nombreCollider;

    public Transform jugador;

    private void Awake()
    {
        jugador = gameObject.transform.parent.parent;
        nombreCollider = this.name;
        Debug.Log(nombreCollider);
        Debug.Log(jugador.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ColliderDelante")
        {
            if(nombreCollider == "ColliderDelante")
            {
                other.gameObject.GetComponent<ManagerCollisiones>().jugador.GetComponent<Controlarvelocidad>().puntosEstabilidad -= 2;


            }
            else if (nombreCollider == "ColliderAtras")
            {
                //other.gameObject.GetComponent<ManagerCollisiones>().
            }
            else if (nombreCollider == "ColliderLados")
            {
                other.gameObject.GetComponent<ManagerCollisiones>().jugador.GetComponent<Controlarvelocidad>().puntosEstabilidad -= 2;
            }
        }
        else if (other.gameObject.name == "ColliderAtras")
        {
            if (nombreCollider == "ColliderDelante")
            {
                other.gameObject.GetComponent<ManagerCollisiones>().jugador.GetComponent<Controlarvelocidad>().puntosEstabilidad -= 2;

            }
            else if (nombreCollider == "ColliderAtras")
            {
                other.gameObject.GetComponent<ManagerCollisiones>().jugador.GetComponent<Controlarvelocidad>().puntosEstabilidad -= 2;
            }
            else if (nombreCollider == "ColliderLados")
            {
                other.gameObject.GetComponent<ManagerCollisiones>().jugador.GetComponent<Controlarvelocidad>().puntosEstabilidad -= 2;
            }
        }
        else if (other.gameObject.name == "ColliderLados")
        {
            if (nombreCollider == "ColliderDelante")
            {
                other.gameObject.GetComponent<ManagerCollisiones>().jugador.GetComponent<Controlarvelocidad>().puntosEstabilidad -= 2;

            }
            else if (nombreCollider == "ColliderAtras")
            {
                other.gameObject.GetComponent<ManagerCollisiones>().jugador.GetComponent<Controlarvelocidad>().puntosEstabilidad -= 2;
            }
            else if (nombreCollider == "ColliderLados")
            {
                other.gameObject.GetComponent<ManagerCollisiones>().jugador.GetComponent<Controlarvelocidad>().puntosEstabilidad -= 2;
            }
        }

    }

}
