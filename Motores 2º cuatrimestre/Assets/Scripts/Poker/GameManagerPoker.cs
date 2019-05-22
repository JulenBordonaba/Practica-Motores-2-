using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cartas
{
    Corazon,
    Rombo,
    Trebol,
    Pica,
    Vacio
};
public enum Posiciones
{
    Derecha,
    Izquierda,
    Abajo,
    Arriba
};
public enum Colores
{
    Rojo,
    Amarillo,
    Verde,
    Azul,
    Vacio
}

public class GameManagerPoker : MonoBehaviour
{
    public Cartas CartaBuscada;
    public int rondas = 1;
    public int cartaInicio = 0;
    private int cart;
    public int[] pos;
    public int[] cartas;
    public int[] colores;
    public Posiciones[] posicion;
    public Cartas[] carta;
    public Colores[] color;

    public GameObject[] jugadores;
    public GameObject[] posiciones;

    public int seleccionados;
    
    private float contador = 0;
    public int pintadas = 0;
    private string estado = "DarValores";

    public bool cartaBuenaPintada;

    private void Awake()
    {
        cart = Random.Range(0, 3);

        if (cart == 0)
            CartaBuscada = Cartas.Corazon;
        else if (cart == 1)
            CartaBuscada = Cartas.Rombo;
        else if (cart == 2)
            CartaBuscada = Cartas.Trebol;
        else if (cart == 3)
            CartaBuscada = Cartas.Pica;
    }


    private void Update()
    {
        switch (estado)
        {
            case "DarValores":

                DarCarta();
                DarColor();
                DarPosicion();

                estado = "Rondas";
                break;

            case "Rondas":

                switch (rondas)
                {
                    case 1:

                        Debug.Log(CartaBuscada);

                        int n = Random.Range(0, 3);
                        posiciones[n].GetComponent<PuntosSeleccionLado>().CambiarMaterial(cart,true,true,false,false);
                        posiciones[n].GetComponent<PuntosSeleccionLado>().CambiarColor(cart);
                        
                        estado = "ElegirLado";
                        break;

                    case 2:

                        for (int i = 0; i <= 3; i++)
                            AplicarPosicion(i,2,true,true,false,false);
                        estado = "ElegirLado";
                        break;
                    case 3:

                        for (int i = 0; i <= 3; i++)
                            AplicarPosicion(i, 2, false, true, false, false);
                        estado = "ElegirLado";
                        break;
                    case 4:

                        for (int i = 0; i <= 3; i++)
                            AplicarPosicion(i, 2, false, false, false, true);
                        estado = "ElegirLado";
                        break;
                    case 5:

                        for (int i = 0; i <= 3; i++)
                            AplicarPosicion(i, 2, false, false, false, true);
                        estado = "ElegirLado";
                        break;

                    case 6:

                        for (int i = 0; i <= 3; i++)
                            AplicarPosicion(i, 3, false, false, false, true);
                        estado = "ElegirLado";
                        break;

                    case 7:

                        for (int i = 0; i <= 3; i++)
                            AplicarPosicion(i, 3, false, false, false, true);
                        estado = "ElegirLado";
                        break;

                    case 8:

                        for (int i = 0; i <= 3; i++)
                            AplicarPosicion(i, 3, true, false, true, false);
                        estado = "ElegirLado";
                        break;
                    case 9:

                        for (int i = 0; i <= 3; i++)
                            AplicarPosicion(i, 4, false, false, true, false);
                        estado = "ElegirLado";
                        break;
                    case 10:

                        for (int i = 0; i <= 3; i++)
                            AplicarPosicion(i, 5, false, false, false, true);
                        estado = "ElegirLado";
                        break;



                }
                break;

            case "ElegirLado":
                
                break;
            case "RestablecerValores":
                rondas++;
                pintadas = 0;
                cartaBuenaPintada = false;
                for (int i = 0; i <= 3; i++)
                    posiciones[i].GetComponent<PuntosSeleccionLado>().OcultarImagenes();
            break;
        }
    }

        

    public void AplicarPosicion(int i, int cartasApintar, bool cartaBuenaColorOriginal, bool CartasMalasColorOriginal, bool TodosMismoColor,bool todosDiferentes)
    {
        if (posicion[i] == Posiciones.Derecha)
        {
            CambiarCarta(posiciones[0],i, cartasApintar, cartaBuenaColorOriginal, CartasMalasColorOriginal, TodosMismoColor);
            if (todosDiferentes)
                AplicarColor(posiciones[0], i);
        }
        else if(posicion[i] == Posiciones.Izquierda)
        {
            CambiarCarta(posiciones[1],i, cartasApintar, cartaBuenaColorOriginal, CartasMalasColorOriginal, TodosMismoColor);
            if (todosDiferentes)
                AplicarColor(posiciones[1],i);
        }
        else if (posicion[i] == Posiciones.Abajo)
        {
            CambiarCarta(posiciones[2],i, cartasApintar, cartaBuenaColorOriginal, CartasMalasColorOriginal, TodosMismoColor);
            if (todosDiferentes)
                AplicarColor(posiciones[2],i);
        }
        else if (posicion[i] == Posiciones.Arriba)
        {
            CambiarCarta(posiciones[3],i, cartasApintar, cartaBuenaColorOriginal, CartasMalasColorOriginal, TodosMismoColor);
            if (todosDiferentes)
                AplicarColor(posiciones[3],i);
        }
    }

    public void CambiarCarta(GameObject obj, int i,int cartasAPintar, bool cartaBuenaColorOriginal, bool CartasMalasColorOriginal, bool TodosMismoColor)
    {
        if (pintadas < cartasAPintar)
        {
            if (!cartaBuenaPintada)
            {
                for (int n = 0; n <= 3; n++)
                {
                    if (carta[n] == CartaBuscada)
                    {
                        obj.GetComponent<PuntosSeleccionLado>().CambiarMaterial(cart, true, cartaBuenaColorOriginal, false, TodosMismoColor);
                        pintadas++;
                        Debug.Log("Cartas Pintadas:" + pintadas);
                        cartaBuenaPintada = true;
                    }
                }
            }
            else
            {
                if (carta[i] == Cartas.Corazon && carta[i] != CartaBuscada && pintadas <= cartasAPintar)
                {
                    obj.GetComponent<PuntosSeleccionLado>().CambiarMaterial(0, false, false, CartasMalasColorOriginal, TodosMismoColor);
                    pintadas++;
                }
                else if (carta[i] == Cartas.Rombo && carta[i] != CartaBuscada && pintadas <= cartasAPintar)
                {
                    obj.GetComponent<PuntosSeleccionLado>().CambiarMaterial(1, false, false, CartasMalasColorOriginal, TodosMismoColor);
                    pintadas++;
                }
                else if (carta[i] == Cartas.Trebol && carta[i] != CartaBuscada && pintadas <= cartasAPintar)
                {

                    obj.GetComponent<PuntosSeleccionLado>().CambiarMaterial(2, false, false, CartasMalasColorOriginal, TodosMismoColor);
                    pintadas++;
                }
                else if (carta[i] == Cartas.Pica && carta[i] != CartaBuscada && pintadas <= cartasAPintar)
                {
                    obj.GetComponent<PuntosSeleccionLado>().CambiarMaterial(3, false, false, CartasMalasColorOriginal, TodosMismoColor);
                    pintadas++;
                }
            }
        }
        else
            obj.GetComponent<PuntosSeleccionLado>().CambiarMaterial(4, false,false,false,false);
    }

    public void AplicarColor(GameObject obj, int i)
    {
        if(color[i] == Colores.Rojo)
        {
            obj.GetComponent<PuntosSeleccionLado>().CambiarColor(0);
        }
        else if (color[i] == Colores.Amarillo)
        {
            obj.GetComponent<PuntosSeleccionLado>().CambiarColor(1);
        }
        else if (color[i] == Colores.Verde)
        {
            obj.GetComponent<PuntosSeleccionLado>().CambiarColor(2);
        }
        else if (color[i] == Colores.Azul)
        {
            obj.GetComponent<PuntosSeleccionLado>().CambiarColor(3);
        }
        else if(color[i] == Colores.Vacio)
        {
            obj.GetComponent<PuntosSeleccionLado>().CambiarColor(4);
        }
    }

    public void DarPosicion()
    {
        for (int n = 0; n <= 3; n++)
            pos[n] = n;

        for (int n = 0; n < 1000; n++)
        {
            int a = Random.Range(0, 3);
            int b = Random.Range(0, 3);
            int t = pos[a];
            pos[a] = pos[b];
            pos[b] = t;
        }

        for (int i = 0; i <= 3; i++)
        {
            if (pos[i] == 0)
                posicion[i] = Posiciones.Derecha;
            else if (pos[i] == 1)
                posicion[i] = Posiciones.Izquierda;
            else if (pos[i] == 2)
                posicion[i] = Posiciones.Abajo;
            else if (pos[i] == 3)
                posicion[i] = Posiciones.Arriba;
        }
    }

    public void DarCarta()
    {
        for (int n = 0; n <= 3; n++)
            cartas[n] = n;

        for (int n = 0; n < 1000; n++)
        {
            int a = Random.Range(0, 3);
            int b = Random.Range(0, 3);
            int t = cartas[a];
            cartas[a] = cartas[b];
            cartas[b] = t;
        }

        for (int i = 0; i <= 4; i++)
        {
            if (cartas[i] == 0)
                carta[i] = Cartas.Corazon;
            else if (cartas[i] == 1)
                carta[i] = Cartas.Rombo;
            else if (cartas[i] == 2)
                carta[i] = Cartas.Trebol;
            else if (cartas[i] == 3)
                carta[i] = Cartas.Pica;
            else if (cartas[i] == 4)
                carta[i] = Cartas.Vacio;
        }
    }

    public void DarColor()
    {
        for (int n = 0; n <= 3; n++)
            colores[n] = n;

        for (int n = 0; n < 1000; n++)
        {
            int a = Random.Range(0, 3);
            int b = Random.Range(0, 3);
            int t = colores[a];
            colores[a] = colores[b];
            colores[b] = t;
        }

        for (int i = 0; i <= 4; i++)
        {
            if (colores[i] == 0)
                color[i] = Colores.Rojo;
            else if (colores[i] == 1)
                color[i] = Colores.Amarillo;
            else if (colores[i] == 2)
                color[i] = Colores.Verde;
            else if (colores[i] == 3)
                color[i] = Colores.Azul;
            else if (colores[i] == 4)
                color[i] = Colores.Vacio;
        }
    }


}