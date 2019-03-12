using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control  {

    public ControlType type = ControlType.teclado;
    public int index = 1;

    public Control(ControlType _type, int _index)
    {
        type = _type;
        index = _index;
    }

    public string InputCode
    {
        get { return (type == ControlType.teclado ? "Teclado" : "Mando") + index.ToString(); }
    }
}
