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
        /*
        for (int n = 0; n < 4; n++)
            posicion[n] = n;

        for (int n = 0; n < 100; n++) {
            int a = Random.Range(0, 4);
            int b = Random.Range(0, 4);
            int t = posicion[a];
            posicion[a] = posicion[b];
            posicion[b] = t;
        }*/

        switch (estado)
        {
            case "Rondas":

               switch (rondas)
                {
                    case 1:
                        print("ronda1");
                        RandomNumber(1, posicion,false);
                        for (int i = 0; i <= 3; i++)
                        {
                            carta[0] = cartaABuscar;
                            Debug.Log(carta[0]);
                            if (i == posicion[0])
                                posiciones[posicion[0]].GetComponent<PuntosSeleccionLado>().ActivarImagen(cartaABuscar, 0, true, true);
                            else
                                posiciones[i].GetComponent<PuntosSeleccionLado>().ActivarImagen(4, 1, false, false);
                        }
                        estado = "Elegir Lados";
                        break;

                    case 2:
                        print("ronda2");
                        for (int i = 0; i <= 3; i++)
                            jugadores[i].GetComponent<ElegirLadoPoker>().centrar = false;

                        RandomNumber(1, posicion,false);
                        RandomNumber(2, posicion,false);
                        for (int i = 0; i <= 3; i++)
                        {
                            carta[0] = cartaABuscar;
                            RandomNumber(2, carta, false);

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

                        RandomNumber(1, posicion, true);
                        RandomNumber(2, posicion, false);
                        for (int i = 0; i <= 3; i++)
                        {
                            carta[0] = cartaABuscar;
                            RandomNumber(2, carta, false);

                            RandomNumber(1, color, false);

                            if (i == posicion[0])
                                posiciones[posicion[0]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[0], color[0], true, false);
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

                        RandomNumber(1, posicion, true);
                        RandomNumber(2, posicion, false);
                        for (int i = 0; i <= 3; i++)
                        {
                            carta[0] = cartaABuscar;
                            RandomNumber(2, carta, false);


                            RandomNumber(1, color, false);
                            RandomNumber(2, color, false);

                            if (i == posicion[0])
                                posiciones[posicion[0]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[0], color[0], true, false);
                            else if (i == posicion[1])
                                posiciones[posicion[1]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[1], color[1], false, false);
                            else
                                posiciones[i].GetComponent<PuntosSeleccionLado>().ActivarImagen(4, 1, false, false);
                        }
                        estado = "Elegir Lados";
                        break;
                    case 5:
                        print("ronda5");
                        for (int i = 0; i <= 3; i++)
                            jugadores[i].GetComponent<ElegirLadoPoker>().centrar = false;

                        RandomNumber(1, posicion, true);
                        RandomNumber(2, posicion, false);
                        for (int i = 0; i <= 3; i++)
                        {
                            carta[0] = cartaABuscar;
                            RandomNumber(2, carta, false);


                            RandomNumber(1, color, false);
                            RandomNumber(2, color, false);

                            if (i == posicion[0])
                                posiciones[posicion[0]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[0], color[0], true, false);
                            else if (i == posicion[1])
                                posiciones[posicion[1]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[1], color[1], false, false);
                            else
                                posiciones[i].GetComponent<PuntosSeleccionLado>().ActivarImagen(4, 1, false, false);
                        }
                        estado = "Elegir Lados";
                        break;
                    case 6:
                        print("ronda6");
                        for (int i = 0; i <= 3; i++)
                            jugadores[i].GetComponent<ElegirLadoPoker>().centrar = false;

                        RandomNumber(1, posicion, true);
                        RandomNumber(2, posicion, false);
                        RandomNumber(3, posicion, false);
                        for (int i = 0; i <= 3; i++)
                        {
                            carta[0] = cartaABuscar;
                            RandomNumber(2, carta, false);
                            RandomNumber(3, carta, false);


                            RandomNumber(1, color, false);
                            RandomNumber(2, color, false);
                            RandomNumber(3, color, false);

                            if (i == posicion[0])
                                posiciones[posicion[0]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[0], color[0], true, false);
                            else if (i == posicion[1])
                                posiciones[posicion[1]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[1], color[1], false, false);
                           else if (i == posicion[2])
                                posiciones[posicion[2]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[2], color[2], false, false);
                            else
                                posiciones[i].GetComponent<PuntosSeleccionLado>().ActivarImagen(4, 1, false, false);
                        }

                        estado = "Elegir Lados";
                        break;
                    case 7:
                        print("ronda 7");

                        for(int i = 0; i <= 3; i++)
                            jugadores[i].GetComponent<ElegirLadoPoker>().centrar = false;

                        RandomNumber(1, posicion, true);
                        RandomNumber(2, posicion, false);
                        RandomNumber(3, posicion, false);
                        for (int i = 0; i <= 3; i++)
                        {
                            carta[0] = cartaABuscar;
                            RandomNumber(2, carta, false);
                            RandomNumber(3, carta, false);


                            RandomNumber(1, color, false);
                            RandomNumber(2, color, false);
                            RandomNumber(3, color, false);

                            if (i == posicion[0])
                                posiciones[posicion[0]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[0], color[0], true, false);
                            else if (i == posicion[1])
                                posiciones[posicion[1]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[1], color[1], false, false);
                            else if (i == posicion[2])
                                posiciones[posicion[2]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[2], color[2], false, false);
                            else
                                posiciones[i].GetComponent<PuntosSeleccionLado>().ActivarImagen(4, 1, false, false);
                        }

                        estado = "Elegir Lados";
                        break;
                    case 8:
                        print("ronda8");
                        for (int i = 0; i <= 3; i++)
                            jugadores[i].GetComponent<ElegirLadoPoker>().centrar = false;

                        RandomNumber(1, posicion, true);
                        RandomNumber(2, posicion, false);
                        RandomNumber(3, posicion, false);
                        for (int i = 0; i <= 3; i++)
                        {
                            carta[0] = cartaABuscar;
                            RandomNumber(2, carta, false);
                            RandomNumber(3, carta, false);

                            if (i == posicion[0])
                                posiciones[posicion[0]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[0], 0, true, true);
                            else if (i == posicion[1])
                                posiciones[posicion[1]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[1], carta[0], false, false);
                            else if (i == posicion[2])
                                posiciones[posicion[2]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[2], carta[0], false, false);
                            else
                                posiciones[i].GetComponent<PuntosSeleccionLado>().ActivarImagen(4, 1, false, false);
                        }

                        estado = "Elegir Lados";
                        break;
                    case 9:
                        print("ronda9");
                        for (int i = 0; i <= 3; i++)
                            jugadores[i].GetComponent<ElegirLadoPoker>().centrar = false;

                        RandomNumber(1, posicion, true);
                        RandomNumber(2, posicion, false);
                        RandomNumber(3, posicion, false);
                        RandomNumber(4, posicion, false);
                        for (int i = 0; i <= 3; i++)
                        {
                            carta[0] = cartaABuscar;
                            RandomNumber(2, carta, false);
                            RandomNumber(3, carta, false);
                            RandomNumber(4, carta, false);

                            if (i == posicion[0])
                                posiciones[posicion[0]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[0], 0, true, true);
                            else if (i == posicion[1])
                                posiciones[posicion[1]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[1], carta[0], false, false);
                            else if (i == posicion[2])
                                posiciones[posicion[2]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[2], carta[0], false, false);
                            else if (i == posicion[3])
                                posiciones[posicion[3]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[3], carta[0], false, false);
                        }

                        estado = "Elegir Lados";
                        break;
                    case 10:
                        print("ronda10");
                        for (int i = 0; i <= 3; i++)
                            jugadores[i].GetComponent<ElegirLadoPoker>().centrar = false;

                        RandomNumber(1, posicion, true);
                        RandomNumber(2, posicion, false);
                        RandomNumber(3, posicion, false);
                        RandomNumber(4, posicion, false);
                        for (int i = 0; i <= 3; i++)
                        {
                            carta[0] = cartaABuscar;
                            RandomNumber(2, carta, false);
                            RandomNumber(3, carta, false);
                            RandomNumber(4, carta, false);

                            RandomNumber(1, color, false);
                            RandomNumber(2, color, false);
                            RandomNumber(3, color, false);
                            RandomNumber(4, color, false);

                            if (i == posicion[0])
                                posiciones[posicion[0]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[0], color[0], true, false);
                            else if (i == posicion[1])
                                posiciones[posicion[1]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[1], color[1], false, false);
                            else if (i == posicion[2])
                                posiciones[posicion[2]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[2], color[2], false, false);
                            else if (i == posicion[3])
                                posiciones[posicion[3]].GetComponent<PuntosSeleccionLado>().ActivarImagen(carta[3], color[3], false, false);
                        }

                        estado = "Elegir Lados";
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

    public void RandomNumber(int caso,int[] array,bool carta)
    {
        switch (caso)
        {
            case 1:
                array[caso - 1] = Random.Range(0, 3);
                print(array[1]);
                break;

            case 2:
                do
                {
                    array[caso-1] = Random.Range(0, 3);
                }
                while (array[caso - 1] == array[0]);
                print(array[1]);
                break;
            case 3:
                do
                {
                    array[caso - 1] = Random.Range(0, 3);
                }
                while (array[caso - 1] == array[0] || array[caso - 1] == array[1]);
                print(array[2]);
                break;
            case 4:
                array[caso - 1] = 3;
                if (array[caso - 1] == array[0] || array[caso - 1] == array[1] || array[caso - 1] == array[2])
                    array[caso - 1]--;
                else if (array[caso - 1] == array[0] || array[caso - 1] == array[1] || array[caso - 1] == array[2])
                    array[caso - 1]--;
                else if (array[caso - 1] == array[0] || array[caso - 1] == array[1] || array[caso - 1] == array[2])
                    array[caso - 1]--;


                print(array[3]);
                break;
        }
    }


    public void sumarSeleccionados()
    {
        seleccionados++;
    }
}
