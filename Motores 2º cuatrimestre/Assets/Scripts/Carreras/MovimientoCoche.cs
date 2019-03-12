using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCoche : MonoBehaviour
{
    
    public float acceleration = 50;
    public float vel = 30;
    public float manejo = 90;
    public int jugador;
    public Vector2 MinMaxAngleX;
    public Vector2 MinMaxAngleZ;

    private float rotation;
    private float tiempoCarrera;
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
        LimitarRotacion();

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

        
        if(contVueltas.vueltasActuales == contVueltas.vueltasMaximas)
            gameObject.GetComponent<MovimientoCoche>().enabled = false;
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

    public void LimitarRotacion()
    {
        if (transform.eulerAngles.x > MinMaxAngleX.y || transform.eulerAngles.z > MinMaxAngleZ.y)
        {
            rotationLimit.x = Mathf.Clamp(rotationLimit.x, 0, MinMaxAngleX.y);
            rotationLimit.z = Mathf.Clamp(rotationLimit.z, 0, MinMaxAngleZ.y);
            transform.eulerAngles = new Vector3(rotationLimit.x, transform.eulerAngles.y, rotationLimit.z);
        }
        else if (transform.eulerAngles.x < MinMaxAngleX.x || transform.eulerAngles.z < MinMaxAngleZ.x)
        {
            rotationLimit.x = Mathf.Clamp(rotationLimit.x, MinMaxAngleX.x, 0);
            rotationLimit.z = Mathf.Clamp(rotationLimit.z, MinMaxAngleZ.x, 0);
            transform.eulerAngles = new Vector3(rotationLimit.x, transform.eulerAngles.y, rotationLimit.z);
        }
    }
}




