using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorVueltas : MonoBehaviour
{
    public int vueltasMaximas;
    [HideInInspector]
    public float vueltasActuales;

    public Text vueltasActualesText;
    public Text vueltasTotalesText;

    public GameObject[] checkPoints; //El ultimo siempre es la meta ( tienen que estar ordenados) checkPoint1,checkPoint2,checkPoint3...checkPointMeta.

    private string NextCollider = "CheckPoint";
    private int NumeroCollider = 0;

    private void Awake()
    {
        NumeroCollider = 0;
        vueltasTotalesText.text = vueltasMaximas.ToString();
    }
    private void Update()
    {
        Debug.Log(NextCollider + NumeroCollider);

        if(vueltasActuales != vueltasMaximas)
            vueltasActualesText.text = (vueltasActuales +1).ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == checkPoints[NumeroCollider] && NumeroCollider<checkPoints.Length-1)
            NumeroCollider++;

        if(other.gameObject == checkPoints[NumeroCollider])
        {
            NumeroCollider = 1;
            vueltasActuales ++;
            vueltasActualesText.text = vueltasActuales.ToString();
        }
    }

}
