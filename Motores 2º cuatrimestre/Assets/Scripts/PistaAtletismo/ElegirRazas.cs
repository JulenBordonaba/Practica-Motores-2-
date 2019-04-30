using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElegirRazas : MonoBehaviour
{
    [Tooltip("Arrastra los botones con todas las razas del jugador 1")]
    public List<GameObject> razas1 = new List<GameObject>();
    [Tooltip("Arrastra los botones con todas las razas del jugador 2")]
    public List<GameObject> razas2 = new List<GameObject>();
    [Tooltip("Arrastra los botones con todas las razas del jugador 3")]
    public List<GameObject> razas3 = new List<GameObject>();
    [Tooltip("Arrastra los botones con todas las razas del jugador 4")]
    public List<GameObject> razas4 = new List<GameObject>();
    public GameObject elegirRazas;//arrastra el objeto con las animaciones de las razas

    private bool auxActivo;
    // Update is called once per frame
    void Update()
    {
        if (!auxActivo)
        {
            for (int i = 0; i < 6; i++)
            {
                razas1[i].SetActive(false);
                razas2[i].SetActive(false);
                razas3[i].SetActive(false);
                razas4[i].SetActive(false);
            }


            switch (GameManagerGlobal.i.elegirRazasJugadorActual)
            {
                case 1:
                    for (int i = 0; i < 6; i++)
                    {
                        razas1[i].SetActive(true);
                    }
                    auxActivo = true;
                    break;

                case 2:
                    for (int i = 0; i < 6; i++)
                    {
                        razas2[i].SetActive(true);
                    }
                    auxActivo = true;
                    break;

                case 3:
                    for (int i = 0; i < 6; i++)
                    {
                        razas3[i].SetActive(true);
                    }
                    auxActivo = true;
                    break;

                case 4:
                    for (int i = 0; i < 6; i++)
                    {
                        razas4[i].SetActive(true);
                    }
                    auxActivo = true;
                    break;

                default:
                    auxActivo = false;
                    break;
            }
        }
    }

    public void elegirJugadores(Text txtValue)
    {
        int aux = 0;
        switch (int.Parse(txtValue.text))
        {
            case 1:

                break;

            case 2:

                break;

            case 3:

                break;

            case 4:

                break;

            case 5:

                break;

            case 6:

                break;

            default:
                break;
        }

        for (int i = 0; i < 6; i++)
        {
            //razas1[i].GetComponent<Button>().interactable = false;
            //razas1[i].SetActive(false);
        }

        //for (int i = 0; i < aux; i++)
        //{
        //    razas[i].SetActive(true);
        //    //elegirRazas.GetComponent<Animator>().Play("desplazarNumerosElegirJugadores");//reproducir el clip por defecto
        //}
    }
}
