using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float velocity = 1;
    public float rotationVelocity = 1080;
    public bool horizontalMovement = true;
    public bool verticalMovement = true;
    public bool invertHorizontal = false;
    public bool invertVertical = false;
    public bool girarPersonaje = true;

    private Rigidbody rb;
    public bool disabled = false;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Controller();
    }

    private void Controller()
    {
        if (disabled) return;
        //Debug.Log(InputManager.controles[jugador].InputCode);
        Vector3 desplazamiento = new Vector3((horizontalMovement ? Input.GetAxis("Horizontal" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) : 0f) * (invertHorizontal ? -1 : 1), 0, (verticalMovement ? Input.GetAxis("Vertical" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) : 0f) * (invertVertical ? -1 : 1));
        transform.Translate(desplazamiento.normalized * velocity * Time.deltaTime, Space.World);
        rb.angularVelocity = Vector3.zero;

        //transform.rotation = Quaternion.Euler(0, MovementKeys ? PlayerDirection : transform.rotation.eulerAngles.y, 0);
        //transform.rotation = Quaternion.Lerp(transform.rotation, MovementKeys ? Quaternion.Euler(transform.rotation.x, PlayerDirection, transform.rotation.z) : transform.rotation,0.8f);
        //transform.rotation = MovementKeys ? Quaternion.Euler(transform.eulerAngles.x, Mathf.LerpAngle(transform.eulerAngles.y, PlayerDirection, 0.9f), transform.eulerAngles.z) : transform.rotation;
        //transform.rotation = Quaternion.Euler(Vector3.RotateTowards(transform.rotation.eulerAngles, new Vector3(transform.rotation.x, PlayerDirection, transform.rotation.z), 90*Time.deltaTime,0.0f));
        /*if (transform.rotation.eulerAngles.y > 180)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y - 360, transform.rotation.z));
        }
        else if (transform.rotation.eulerAngles.y < -180)
        {
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y + 360, transform.rotation.z));
        }*/
        //transform.forward= new Vector3(-(horizontalMovement ? Input.GetAxis("Horizontal" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) : 0f) * (invertHorizontal ? -1 : 1), 0, (verticalMovement ? Input.GetAxis("Vertical" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) : 0f) * (invertVertical ? -1 : 1))
        if (girarPersonaje)
        {
            transform.rotation = MovementKeys ? Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, PlayerDirection, transform.eulerAngles.z), rotationVelocity * Time.deltaTime) : transform.rotation;
        }
        print("Player direction: " + PlayerDirection + " " + gameObject.name);
        //gameObject.GetComponentInChildren<Animator>().SetBool("", MovementKeys);
    }

    private float PlayerDirection
    {
        get { return Vector2.SignedAngle(new Vector2(0, 1), new Vector2(-(horizontalMovement ? Input.GetAxis("Horizontal" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) : 0f) * (invertHorizontal ? -1 : 1), (verticalMovement ? Input.GetAxis("Vertical" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) : 0f) * (invertVertical ? -1 : 1))); }
    }

    public bool MovementKeys
    {
        get { return !((horizontalMovement ? Input.GetAxis("Horizontal" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) : 0f) == 0 && (verticalMovement ? Input.GetAxis("Vertical" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) : 0f) == 0); }
    }

    private void OnEnable()
    {
        print("onEnable" + gameObject.name);
    }
    private void OnDisable()
    {
        print("onDisable" + gameObject.name);
    }


}
