using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPoker : MonoBehaviour
{
    public int rondas = 1;
    public int cartaABuscar = 0;

    public GameObject[] jugadores;

    public GameObject[] posiciones;

    public PuntosSeleccionLado[] seleccionLados;

    public int[] posicion;
    public int[] carta;
    public int[] color;

    public int seleccionados;

    private string estado = "Rondas";
    private float contador = 0;

    public bool imagenesPuestas = false;

    private void Awake()
    {
        cartaABuscar = Random.Range(0, 3);
        Debug.Log(cartaABuscar);
    }

    void Update()
    {
        switch (estado)
        {
            case "Rondas":

               switch (rondas)
                {
                    case 1:
                        print("ronda1");
                        posicion[0] = RandomNumber(1, posicion,false);
                        for (int i = 0; i <= 3; i++)
                        {
                            carta[0] = RandomNumber(1, carta, true);
                            if (i == posicion[0])
                                posiciones[posicion[0]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[0], 0, true, true);
                            else
                                posiciones[i].GetComponent<PuntosSeleccionLado>().ActivarImagen(4, 1, false, false);
                        }
                        estado = "Elegir Lados";
                        break;

                    case 2:
                        print("ronda2");
                        for (int i = 0; i <= 3; i++)
                            jugadores[i].GetComponent<ElegirLadoPoker>().centrar = false;

                        posicion[0] = RandomNumber(1, posicion,false);
                        posicion[1] = RandomNumber(2, posicion,false);
                        for (int i = 0; i <= 3; i++)
                        {
                            carta[0] = RandomNumber(1, carta, true);
                            carta[1] = RandomNumber(2, carta, false);

                            if (i == posicion[0])
                                posiciones[posicion[0]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[0], 0, true, true);
                            else if(i == posicion[1])
                                posiciones[posicion[1]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[1], 0, false, true);
                            else
                                posiciones[i].GetComponent<PuntosSeleccionLado>().ActivarImagen(4, 1, false, false);
                        }
                        estado = "Elegir Lados";
                        break;

                    case 3:
                        print("ronda3");
                        for (int i = 0; i <= 3; i++)
                            jugadores[i].GetComponent<ElegirLadoPoker>().centrar = false;

                        posicion[0] = RandomNumber(1, posicion, true);
                        posicion[1] = RandomNumber(2, posicion, false);
                        for (int i = 0; i <= 3; i++)
                        {
                            carta[0] = RandomNumber(1, carta, true);
                            carta[1] = RandomNumber(2, carta, false);

                            if (i == posicion[0])
                                posiciones[posicion[0]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[0], 0, true, false);
                            else if (i == posicion[1])
                                posiciones[posicion[1]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[1], 0, false, true);
                            else
                                posiciones[i].GetComponent<PuntosSeleccionLado>().ActivarImagen(4, 1, false, false);
                        }
                        estado = "Elegir Lados";
                        break;
                    case 4:
                        print("ronda4");
                        for (int i = 0; i <= 3; i++)
                            jugadores[i].GetComponent<ElegirLadoPoker>().centrar = false;

                        posicion[0] = RandomNumber(1, posicion, true);
                        posicion[1] = RandomNumber(2, posicion, false);
                        for (int i = 0; i <= 3; i++)
                        {
                            carta[0] = RandomNumber(1, carta, true);
                            carta[1] = RandomNumber(2, carta, false);

                            if (i == posicion[0])
                                posiciones[posicion[0]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[0], 0, true, false);
                            else if (i == posicion[1])
                                posiciones[posicion[1]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[1], 0, false, false);
                            else
                                posiciones[i].GetComponent<PuntosSeleccionLado>().ActivarImagen(4, 1, false, false);
                        }
                        estado = "Elegir Lados";
                        break;
                    case 5:
                        print("ronda5");
                        for (int i = 0; i <= 3; i++)
                            jugadores[i].GetComponent<ElegirLadoPoker>().centrar = false;

                        posicion[0] = RandomNumber(1, posicion, true);
                        posicion[1] = RandomNumber(2, posicion, false);
                        for (int i = 0; i <= 3; i++)
                        {
                            carta[0] = RandomNumber(1, carta, true);
                            carta[1] = RandomNumber(2, carta, false);

                            if (i == posicion[0])
                                posiciones[posicion[0]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[0], 0, true, false);
                            else if (i == posicion[1])
                                posiciones[posicion[1]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[1], 0, false, false);
                            else
                                posiciones[i].GetComponent<PuntosSeleccionLado>().ActivarImagen(4, 1, false, false);
                        }

                        estado = "Elegir Lados";
                        break;
                    case 6:
                    case 7:
                        print("ronda6");
                        posicion[0] = RandomNumber(1, posicion, true);
                        posicion[1] = RandomNumber(2, posicion, false);
                        posicion[2] = RandomNumber(3, posicion, false);

                        for (int i = 0; i <= 3; i++)
                        {
                            carta[0] = RandomNumber(1, carta, true);
                            carta[1] = RandomNumber(2, carta, false);
                            carta[2] = RandomNumber(3, carta, false);

                            if (i == posicion[0])
                                posiciones[posicion[0]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[0], 0, true, false);
                            else if (i == posicion[1])
                                posiciones[posicion[1]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[1], 0, false, false);
                            else if (i == posicion[2])
                                posiciones[posicion[2]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[2], 0, false, false);
                            else
                                posiciones[i].GetComponent<PuntosSeleccionLado>().ActivarImagen(4, 1, false, false);
                        }

                        estado = "Elegir Lados";
                        break;
                    /*case 7:
                        print("ronda7");

                        break;*/
                    case 8:
                        print("ronda2");
                        break;
                    case 9:
                        print("ronda2");
                        break;
                    case 10:
                        print("ronda2");
                        break;

                }
                break;

            case "Elegir Lados":
                
                if (seleccionados >= 4)
                    estado = "ResetearValores";
                break;
                
            case "ResetearValores":
                    rondas++;
                    seleccionados = 0;
                    for (int i = 0; i <= 3; i++)
                    {
                        jugadores[i].GetComponent<ElegirLadoPoker>().ResetearPosicion();
                        posiciones[i].GetComponent<PuntosSeleccionLado>().ResetearImagenes();
                        
                    }
                    for (int i = 0; i < posicion.Length; i++)
                        posicion[i] = 0;
                    for (int i = 0; i < color.Length; i++)
                        color[i] = 0;
                    for (int i = 0; i < carta.Length; i++)
                        carta[i] = 0;

                    estado = "Tiempo entre rondas";
                
                    break;

            case "Tiempo entre rondas":
                contador += Time.deltaTime;
                if (contador >= 1)
                {
                    for(int i = 0; i <= 3; i++)
                    {
                        jugadores[i].GetComponent<ElegirLadoPoker>().Activo = true;
                        Debug.Log(jugadores[i].GetComponent<ElegirLadoPoker>().Activo);

                    }
                    contador = 0;
                    estado = "Rondas";
                }
                break;
            case "Fin de Juego":

                break;
        }

        

        
    }

    public int RandomNumber(int caso,int[] array,bool carta)
    {
        switch (caso)
        {
            case 1:
                if (carta)
                    return cartaABuscar;
                else
                    return Random.Range(0, 3);

            case 2:
                int number2 = Random.Range(0, 3);
                    do
                    {
                        if (number2 == array[0])
                            number2 = Random.Range(0, 3);
                    }
                    while (number2 == array[0]);
                return number2;
            case 3:
                int number3 = Random.Range(0, 3);
                do
                {
                    if (number3 == array[0])
                        number3 = Random.Range(0, 3);
                }
                while (number3 == array[0] || number3 == array[1]);
                return number3;
            case 4:
                int number4 = Random.Range(0, 3);
                do
                {
                    if (number4 == array[0])
                        number4 = Random.Range(0, 3);
                }
                while (number4 == array[0] || number4 == array[1] || number4 == array[2]);
                return number4;
        }
        return 0;
    }


    public void sumarSeleccionados()
    {
        seleccionados++;
    }
}
