using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntosSeleccionLado : MonoBehaviour
{
    public GameObject carta;
    public Material[] materiales;
    public Color[] colores; // rojo azul verde amarillo
    public GameManagerPoker gameManager;
    private Renderer renderer;

    public bool acierto;
    public int llegados;

    private void Awake()
    {
        renderer = carta.GetComponent<Renderer>();
        OcultarImagenes();
    }

    public void OcultarImagenes()
    {
        renderer.material = materiales[4];
    }


    public void CambiarColor(int num)
    {

    }

    public void CambiarMaterial(int num, bool buena, bool cartaBuenaColorOriginal, bool CartasMalasColorOriginal, bool TodosMismoColor)
    {
        if (buena)
            acierto = true;
        else
            acierto = false;

        renderer.material = materiales[num];
        Debug.Log("Material :"+num);

    }

}
