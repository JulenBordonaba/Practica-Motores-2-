using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoCoche : MonoBehaviour
{


    private void Start()
    {
        Physics.gravity = new Vector3(0,-27,0);
    }

    public float acceleration = 50;
    public float vel = 30;
    public float manejo = 90;
    public int jugador;
    public float minAngleX = -20;
    public float maxAngleX = 20;
    public float minAngleZ = -45;
    public float maxAngleZ = 45;
    public float impactForce;
    public GameObject Tiempos;

    private float rotation;
    [HideInInspector]
    public float tiempoCarrera;
    private Vector3 rotationLimit;
    private ContadorVueltas contVueltas;
    private Rigidbody rb;

    private void Awake()
    {
        contVueltas = GetComponent<ContadorVueltas>();
        rb = GetComponent<Rigidbody>();
        rotation = transform.eulerAngles.y;

    }

    private void Update()
    {
        LimitRotation();

        rotationLimit = transform.eulerAngles;
        tiempoCarrera += Time.deltaTime;
        Debug.Log(InputManager.controles[jugador].InputCode);
        rb.AddForce(transform.forward * Time.deltaTime * acceleration * Input.GetAxis("Vertical" + InputManager.controles[jugador].InputCode), ForceMode.VelocityChange);

        rotation += Input.GetAxis("Horizontal" + InputManager.controles[jugador].InputCode) * Time.deltaTime * manejo;

        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotation, transform.eulerAngles.z);
        
        rb.velocity = LimitVelocity(rb.velocity);
        Vector3 locVel = transform.InverseTransformDirection(rb.velocity);
        locVel = new Vector3(locVel.x * 0.93f, locVel.y, locVel.z);
        rb.velocity = transform.TransformDirection(locVel);

        
        if(contVueltas.vueltasActuales == contVueltas.vueltasMaximas )
        {
            FindObjectOfType<TiempoVuelta>().AddCarToArray(gameObject);
            gameObject.GetComponent<MovimientoCoche>().enabled = false;
        }


    }

    private void FixedUpdate()
    {
        rotationLimit.x = transform.eulerAngles.x;
        rotationLimit.z = transform.eulerAngles.z;
    }

    public Vector3 LimitVelocity(Vector3 velocity)
    {
        Vector2 v = new Vector2(velocity.x, velocity.z);

        if(v.magnitude > vel)
        {
            v = v.normalized * vel;
        }
        return new Vector3(v.x, velocity.y, v.y);
    }

    public void LimitRotation()
    {
        transform.localEulerAngles = new Vector3(G.ClampAngle(transform.localEulerAngles.x,minAngleX,maxAngleX ), transform.eulerAngles.y, G.ClampAngle(transform.localEulerAngles.z, minAngleZ,maxAngleZ));
    }

}




