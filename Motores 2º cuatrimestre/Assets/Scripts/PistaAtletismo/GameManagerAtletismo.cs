using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerAtletismo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void elegirJugadores(Text txtNumero)
    {
        int aux = 0;
        switch (txtNumero.text)
        {
            case 2:
                GameManagerGlobal.i.numeroJugadores = 2;
                aux = 2;
                break;

            case 3:
                GameManagerGlobal.i.numeroJugadores = 3;
                aux = 3;
                break;

            case 4:
                GameManagerGlobal.i.numeroJugadores = 4;
                aux = 4;
                break;

            default:
                break;
        }
    }
}
