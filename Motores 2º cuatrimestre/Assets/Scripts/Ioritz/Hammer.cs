using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{   
    private Rigidbody rb;
    private int stun = 0;
    public GameObject usableObject;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        rb.velocity = Vector3.zero;
        
        if (usableObject && (Input.GetButtonDown("Button1" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode)) && stun == 0)
        {
            usableObject.SendMessage("Martillo", SendMessageOptions.DontRequireReceiver); //Se llama a la funcion martillo que tienen tanto las cajas como los jugadores
        }
        if (stun > 0)
        {
            stun -= 1;
            //Animación de estuneado (pajaritos en la cabeza)
            if (stun == 0)
            {
                GetComponent<PlayerController>().enabled = true;
                transform.localScale = new Vector3(1, 1, 1);
            }

        }
    }

    private void OnTriggerStay(Collider collision)  //Detecta un objeto
    {
        if (collision.tag == "Caja" || collision.tag == "Player")
        {
            usableObject = collision.gameObject;
        }
    }

    private void OnTriggerExit(Collider collision)  //Detecta que ya no halla objeto en frente y deja la bariable nula
    {
        if (collision.tag == "Caja" || collision.tag == "Player")
        {
            usableObject = null;
        }
    }

    public void Martillo()  // Estunea al jugador
    {
        if (stun == 0)
        {
            stun = 90;
            GetComponent<PlayerController>().enabled = true;
            transform.localScale = new Vector3(1, 0.33f,1);
        }
    }

}
