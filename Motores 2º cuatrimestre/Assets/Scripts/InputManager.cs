using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlType
{
    mando,teclado
}

public class InputManager : MonoBehaviour {

    public static Control[] controles = new Control[4] { new Control(ControlType.teclado, 1), new Control(ControlType.teclado, 2), new Control(ControlType.teclado, 3), new Control(ControlType.teclado, 4) };

    public static int jugadores;

    private int mandosConectados = 0;

	// Use this for initialization
	void Start () {
        ReiniciarInputs();
        mandosConectados = MandosConectados;
        AsignarControles();
	}
	
	// Update is called once per frame
	void Update () {
        print(MandosConectados);
		if(mandosConectados!=MandosConectados)
        {
            print("cambio");
            if(mandosConectados>MandosConectados)
            {
                AsignarControles(false);
            }
            else
            {
                AsignarControles(true);
            }
            mandosConectados = MandosConectados;
        }

        //ReiniciarInputs();
    }

    public static void AsignarControles(bool masMandos)
    {
        List<int> indexes = new List<int>();

        if (!masMandos)
        {
            foreach (Control c in controles)
            {
                if (c.type == ControlType.teclado)
                {
                    indexes.Add(c.index);
                }
            }
        }
        else 
        {
            foreach (Control c in controles)
            {
                if (c.type == ControlType.mando)
                {
                    indexes.Add(c.index);
                }
            }
        }



        //asignar mandos
        for (int i = 0; i < MandosConectados; i++)
        {
            controles[i].type = ControlType.mando;
            if(masMandos)
            {
                bool esNuevo = true;
                foreach (int j in indexes)
                {
                    if (controles[i].index == j)
                    {
                        esNuevo = false;
                    }
                }

                if (esNuevo)
                {

                    bool estaCogido = false;
                    do
                    {
                        estaCogido = false;
                        controles[i].index = Random.Range(1, 5);
                        foreach (int j in indexes)
                        {
                            if (controles[i].index == j)
                            {
                                estaCogido = true;
                            }
                        }
                    } while (estaCogido);
                }
            }
            //controles[i].index = i+1;
        }

        

        
        //asignar teclados
        if (jugadores > MandosConectados)
        {
            for (int i = MandosConectados; i < jugadores; i++)
            {
                controles[i].type = ControlType.teclado;
                if (!masMandos)
                {
                    bool esNuevo = true;
                    foreach (int j in indexes)
                    {
                        if (controles[i].index == j)
                        {
                            esNuevo = false;
                        }
                    }

                    if (esNuevo)
                    {

                        bool estaCogido = false;
                        do
                        {
                            estaCogido = false;
                            controles[i].index = Random.Range(1, 5);
                            foreach (int j in indexes)
                            {
                                if (controles[i].index == j)
                                {
                                    estaCogido = true;
                                }
                            }
                        } while (estaCogido);
                    }
                }
                
            }
        }

        
    }

    public static void AsignarControles()
    {

        print("mandos " + MandosConectados);

        //asignar mandos
        for (int i = 0; i < MandosConectados; i++)
        {
            controles[i].type = ControlType.mando;
            
            controles[i].index = i+1;
        }




        //asignar teclados
        if (jugadores > MandosConectados)
        {
            for (int i = MandosConectados; i < jugadores; i++)
            {
                controles[i].type = ControlType.teclado;
                controles[i].index = i - MandosConectados;

            }
        }


    }

    public void ReiniciarInputs()
    {
        controles = new Control[4] { new Control(ControlType.teclado, 1), new Control(ControlType.teclado, 2), new Control(ControlType.teclado, 3), new Control(ControlType.teclado, 4) };
    }

    public static int MandosConectados
    {
        get { return Input.GetJoystickNames().Length; }
    }
}
