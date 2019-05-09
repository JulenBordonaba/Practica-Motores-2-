using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputController : MonoBehaviour
{



    public const string horizontal="Horizontal";
    public const string vertical="Vertical";
    public const string submit= "Button1";
    public const string cancel="Button2";

    private UnityEngine.EventSystems.StandaloneInputModule inputModule;

    // Start is called before the first frame update
    void Start()
    {
        inputModule = GetComponent<UnityEngine.EventSystems.StandaloneInputModule>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagerGlobal.i.elegirRazasJugadorActual < 1 || GameManagerGlobal.i.elegirRazasJugadorActual > 4)
        {
            inputModule.horizontalAxis = horizontal + InputManager.controles[0].InputCode;
            inputModule.verticalAxis = vertical + InputManager.controles[0].InputCode;
            inputModule.submitButton = submit + InputManager.controles[0].InputCode;
            inputModule.cancelButton = cancel + InputManager.controles[0].InputCode;
            return;
        }
        inputModule.horizontalAxis = horizontal + InputManager.controles[GameManagerGlobal.i.elegirRazasJugadorActual-1].InputCode;
        inputModule.verticalAxis= vertical + InputManager.controles[GameManagerGlobal.i.elegirRazasJugadorActual-1].InputCode;
        inputModule.submitButton= submit + InputManager.controles[GameManagerGlobal.i.elegirRazasJugadorActual-1].InputCode;
        inputModule.cancelButton= cancel + InputManager.controles[GameManagerGlobal.i.elegirRazasJugadorActual-1].InputCode;
    }
}
