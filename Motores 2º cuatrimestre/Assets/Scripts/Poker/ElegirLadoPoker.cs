using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElegirLadoPoker : MonoBehaviour
{

    public Transform[] direcciones;

    private void Awake()
    {
        transform.position = direcciones[4].position;
    }

    private void Update()
    {
        if(Input.GetAxis("Horizontal" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) < 0)
        {
            transform.position = direcciones[1].position;
        }
        else if(Input.GetAxis("Horizontal" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) > 0)
        {
            transform.position = direcciones[0].position;
        }
        else if (Input.GetAxis("Vertical" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) < 0)
        {
            transform.position = direcciones[2].position;
        }
        else if (Input.GetAxis("Vertical" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) > 0)
        {
            transform.position = direcciones[3].position;
        }
    }

    public void ResetearPosicion()
    {
        transform.position = direcciones[4].position;
    }
}
