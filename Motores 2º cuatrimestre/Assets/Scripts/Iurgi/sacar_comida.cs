using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sacar_comida : MonoBehaviour
{
    //public GameObject comida1, comida2, comida3, comida4;//todos los tipos de comida del juego
    public GameObject[] comidas;
    public bool platoVacio;
    //int spawnComida;
    float siguienteSpawn;//tiempo para que salga la comida después de estar el plato vacio

    // Use this for initialization
    void Start()
    {

        PonerComida();

        //GameObject go=gameObject;
        //spawnComida = Random.Range(1, 5);
        //platoVacio = false;
        //switch(spawnComida)//comida random en los platos
        //{
        //    case 1:
        //        go=Instantiate(comida1,transform.position,Quaternion.identity);
        //        break;

        //    case 2:
        //        go=Instantiate(comida2,transform.position, Quaternion.identity);
        //        break;
        //    case 3:
        //        go=Instantiate(comida3,transform.position, Quaternion.identity);
        //        break;
        //    case 4:
        //       go= Instantiate(comida4, transform.position, Quaternion.identity);
        //        break;


        //}
        //go.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject go = gameObject;
        if (platoVacio == true)
        {
            siguienteSpawn = 3f;
            PonerComida();
            //spawnComida = Random.Range(1, 5);
            //switch (spawnComida)
            //{
            //    case 1:
            //        go = Instantiate(comida1, transform.position, Quaternion.identity);

            //        break;
            //    case 2:
            //        go = Instantiate(comida2, transform.position, Quaternion.identity);
            //        break;
            //    case 3:
            //        go = Instantiate(comida3, transform.position, Quaternion.identity);
            //        break;
            //    case 4:
            //        go = Instantiate(comida4, transform.position, Quaternion.identity);
            //        break;


            //}
            //go.transform.parent = transform;

        }
    }

    public void PonerComida()
    {
        GameObject go = Instantiate(comidas[Random.Range(0, comidas.Length)], transform.position, Quaternion.identity);
        go.transform.parent = transform;
        platoVacio = false;
    }
}

