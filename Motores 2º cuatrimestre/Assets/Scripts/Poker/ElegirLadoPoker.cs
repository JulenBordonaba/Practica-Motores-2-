using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElegirLadoPoker : MonoBehaviour
{

    public Transform[] direcciones;
    public bool Activo = true;
    public bool centrar = false;
    

    private void Update()
    {
        if (Activo)
        {
            if (Input.GetAxis("Horizontal" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) < 0)
            {
                transform.position = direcciones[1].position;
                Activo = false;
            }
            else if (Input.GetAxis("Horizontal" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) > 0)
            {
                transform.position = direcciones[0].position;
                Activo = false;
            }
            else if (Input.GetAxis("Vertical" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) < 0)
            {
                transform.position = direcciones[2].position;
                Activo = false;
            }
            else if (Input.GetAxis("Vertical" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) > 0)
            {
                transform.position = direcciones[3].position;
                Activo = false;
            }
        }

        
        
    }

    public void ResetearPosicion()
    {
        transform.position = direcciones[4].position;

        
    }
}
