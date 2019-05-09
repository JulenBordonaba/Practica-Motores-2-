using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputController : MonoBehaviour
{
    public string horizontal;
    public string vertical;
    public string submit;
    public string cancel;

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
            inputModule.horizontalAxis = horizontal + 1;
            inputModule.verticalAxis = vertical + 1;
            inputModule.submitButton = submit + 1;
            inputModule.cancelButton = cancel + 1;
            return;
        }
        inputModule.horizontalAxis = horizontal + GameManagerGlobal.i.elegirRazasJugadorActual;
        inputModule.verticalAxis= vertical + GameManagerGlobal.i.elegirRazasJugadorActual;
        inputModule.submitButton= submit + GameManagerGlobal.i.elegirRazasJugadorActual;
        inputModule.cancelButton= cancel + GameManagerGlobal.i.elegirRazasJugadorActual;
    }
}
