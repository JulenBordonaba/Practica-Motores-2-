using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{

    //static public Hammer i;

    //private Vector3 direction;
    private Rigidbody rb;
    //private Vector3 rotation;
    
    //public float Vel;
    //public float RotVel;
    public int score;
    public int stun = 0;
    //public int playernum;
    //public int stuned = 1;


    public GameObject usableObject;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //i = this;
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = Vector3.zero;
        /* if (stun == 0)
         {
             transform.Rotate(rotation * RotVel);
             transform.Translate(direction * Vel);
             //stuned = 1;

         }*/

        if (usableObject && (Input.GetButtonDown("Button1" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode)) && stun == 0)
        {
                        usableObject.SendMessage("Martillo", SendMessageOptions.DontRequireReceiver);
        }
        if (stun > 0)
        {
            stun -= 1;
            //GetComponent<PlayerControler>.setActive = false;
            //transform.localscale
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Caja" || collision.tag == "Player")
        {
            usableObject = collision.gameObject;
        }


    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Caja" || collision.tag == "Player")
        {
            usableObject = null;
        }

    }

    public void Take(int num)
    {
        score += num;
    }

    public void Martillo()
    {
        if (stun == 0)
        {
            stun = 60;
            //GetComponent<PlayerControler>.setActive = false;
        }


    }

}
