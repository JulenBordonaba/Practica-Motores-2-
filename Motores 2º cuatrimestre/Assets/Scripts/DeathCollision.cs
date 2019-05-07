using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollision : MonoBehaviour {

    private Rigidbody rb;
    public GameObject cuartoOscuro;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death" && gameObject.tag == "Player")
        {
            //esta función originalmente destruia el jugador, pero al hacerlo perdemos puntos y otra información
            //ahora lo manda a un "cuartoOscuro" donde ya no molesta pero no es destruido
            //primero se pone en kinematic
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //después se manda al cuarto oscuro para que no interactue con el escenario
            if (cuartoOscuro)
            {
                gameObject.transform.position = cuartoOscuro.transform.position;
            }
            //se "elimina"
            gameObject.GetComponent<Player>().eliminated = true;
            //se guarda el tiempo si corresponde
            if(TimeCount.i)
                gameObject.GetComponent<MiniGameScores>().time = TimeCount.i.time;
            //y se le quitan todos los puntos
            gameObject.GetComponent<MiniGameScores>().points = -1000;
            //Destroy(gameObject);
        }
        else if (other.tag == "Death")
        {
            //si no es un jugador se destruye
            Destroy(gameObject);
        }
    }
}
