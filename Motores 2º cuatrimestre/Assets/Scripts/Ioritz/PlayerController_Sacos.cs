using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Sacos : MonoBehaviour
{
    static public List<GameObject> jugadores = new List<GameObject>();

    public float velocity = 1;
    public bool horizontalMovement = true;
    public bool verticalMovement = true;
    public bool invertHorizontal = false;
    public bool invertVertical = false;
   

    private Rigidbody rb;
    public bool disabled = false;

    private int playernum;
    private int direccion=-1;


    // Use this for initialization
    void Start()
    {
        jugadores.Add(gameObject);
        rb = GetComponent<Rigidbody>();
        playernum = gameObject.GetComponent<Player>().numPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        //Controller();
        Move();
    }

    private void Controller()
    {
        if (disabled) return;
        //Debug.Log(InputManager.controles[jugador].InputCode);
        transform.Translate((horizontalMovement ? Input.GetAxis("Horizontal" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) * velocity * Time.deltaTime : 0f) * (invertHorizontal ? -1 : 1), 0, (verticalMovement ? Input.GetAxis("Vertical" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) * velocity * Time.deltaTime : 0f) * (invertVertical ? -1 : 1), Space.World);
        rb.angularVelocity = Vector3.zero;
    }

    private void OnEnable()
    {
        print("onEnable" + gameObject.name);
    }
    private void OnDisable()
    {
        print("onDisable" + gameObject.name);
    }


    private void Move()
    {
        if (disabled) return;
        if (playernum != 0 && Input.GetAxis("Vertical" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) == -1)
        {
            direccion = 0;
            GM_Sacos.i.Mover(playernum,0);
            //Ejecutarainmacion de seleccion (un saltito) 
            disabled = true;            
        }

        if (playernum != 1 && Input.GetAxis("Horizontal" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) == 1)
        {
            direccion = 1;
            GM_Sacos.i.Mover(playernum,1);
            //Ejecutarainmacion de seleccion (un saltito) 
            disabled = true;
        }
            if (playernum != 2 && Input.GetAxis("Vertical" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) == 1)
        {
            direccion = 2;
            GM_Sacos.i.Mover(playernum,2);
            //Ejecutarainmacion de seleccion (un saltito) 
            disabled = true;
        }
        if (playernum != 3 && Input.GetAxis("Horizontal" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) == -1)
        {
            direccion = 3;
            GM_Sacos.i.Mover(playernum,3);
            //Ejecutarainmacion de seleccion (un saltito) 
            disabled = true;
            
        }
    }

}
