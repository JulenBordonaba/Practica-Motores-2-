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
        
        if (puntosEstabilidad <= 0)
        {
            puntosEstabilidad = 0;
            gameObject.SetActive(false);
        }
        texto.text = puntosEstabilidad.ToString();
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            coche.vel = maxVel / 2;
            contador += Time.deltaTime;
            if(contador >= 2)
            {
                
                coche.vel = maxVel / 20;
            }
        }
        else if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            contador = 0;
            coche.vel = maxVel;
        }
        
    }
}
