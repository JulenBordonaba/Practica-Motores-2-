using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controlarvelocidad : MonoBehaviour
{
    private float maxVel;
    private MovimientoCoche coche;
    private float contador;
    public int puntosEstabilidad = 10;
    public GameManagerDerby gameManager;
    
    public Text texto;

    private void Start()
    {
        texto.text = puntosEstabilidad.ToString();
        coche = gameObject.GetComponent<MovimientoCoche>();
        maxVel = coche.vel;
    }

    // Update is called once per frame
    void Update()
    {
       // print("Normal: " + coche.vel);
        
        if (puntosEstabilidad <= 0)
        {
            puntosEstabilidad = 0;
            gameManager.Posicionar(gameObject);
        }
        texto.text = puntosEstabilidad.ToString();
        if (Input.GetAxis("Horizontal" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) != 0)
        {
            coche.vel = maxVel / 2;
            //print("Girando: " + coche.vel);
            contador += Time.deltaTime;
            print("Contador: " + contador);
            if(contador >= 2)
            {

                print("GirandoPoco: " + coche.vel);
                coche.vel = maxVel / 20;
            }
        }
        else if(Input.GetAxis("Horizontal" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) == 0)
        {
            contador = 0;
            coche.vel = maxVel;
        }
        
    }
}
