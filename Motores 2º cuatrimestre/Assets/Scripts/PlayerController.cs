using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float velocity = 1;
    public int jugador = 1;
    public bool horizontalMovement = true;
    public bool verticalMovement = true;
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Controller();
	}

    private void Controller()
    {
        Debug.Log(InputManager.controles[jugador].InputCode);
        transform.Translate( horizontalMovement ? Input.GetAxis("Horizontal" + InputManager.controles[jugador].InputCode) * velocity * Time.deltaTime : 0f, 0, verticalMovement ? Input.GetAxis("Vertical" + InputManager.controles[jugador].InputCode) * velocity * Time.deltaTime : 0f,Space.World);
    }

    
}
