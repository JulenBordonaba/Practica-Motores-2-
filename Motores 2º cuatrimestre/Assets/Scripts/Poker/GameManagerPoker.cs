using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPoker : MonoBehaviour
{
    public int rondas = 1;

    public GameObject[] jugadores;

    public GameObject[] posiciones;

    public int[] posicion;
    public int[] carta;
    public int[] color;

    public int seleccionados;

    private string estado = "Colocar Imagenes";

    public bool imagenesPuestas = false;
    
    
    void Update()
    {
        switch (estado)
        {
            case "Colocar Imagenes":

               

                if (rondas == 1 && !imagenesPuestas)
                {
                    for (int i = 0; i <= 3; i++)
                        jugadores[i].GetComponent<ElegirLadoPoker>().Activo = true;
                    posicion[0] = RandomNumber(1, posicion);
                    for (int i = 0; i <= 3; i++)
                    {
                        if (i == posicion[0])
                            posiciones[posicion[0]].GetComponent<PuntosSeleccionLado>().ActivarImagen(0, 0, true,true);
                        else
                            posiciones[i].GetComponent<PuntosSeleccionLado>().ActivarImagen(4, 1, false,false);
                    }
                    imagenesPuestas = true;
                    estado = "Elegir Lados";
                }
                else if (rondas == 2 && !imagenesPuestas)
                {
                    print("Entra");

                    /*for (int i = 0; i <= 3; i++)
                        jugadores[i].GetComponent<ElegirLadoPoker>().Activo = true;
                    */
                    
                    estado = "Elegir Lados";
                }

                break;

            case "Elegir Lados":
                
                if (seleccionados >= 4)
                    estado = "ResetearValores";
                break;
                
            case "ResetearValores":
                    rondas++;
                    seleccionados = 0;
                    imagenesPuestas = false;
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


                estado = "Resetear Posicion";
                break;

            case "Resetear Posicion":
                
                estado = "Colorcar Imagenes";
                break;


            case "Fin de Juego":

                break;
        }

        

        
    }

    public int RandomNumber(int caso,int[] array)
    {
        switch (caso)
        {
            case 1:
                int number = Random.Range(0, 3);
                return number;
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
