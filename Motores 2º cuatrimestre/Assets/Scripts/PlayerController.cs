using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float velocity = 1;
    public bool horizontalMovement = true;
    public bool verticalMovement = true;
    public bool invertHorizontal = false;
    public bool invertVertical = false;

    private Rigidbody rb;
    

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Controller();
	}

    private void Controller()
    {
        //Debug.Log(InputManager.controles[jugador].InputCode);
        transform.Translate( horizontalMovement ? Input.GetAxis("Horizontal" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) * velocity * Time.deltaTime : 0f * (invertHorizontal ? -1 : 1), 0, verticalMovement ? Input.GetAxis("Vertical" + InputManager.controles[gameObject.GetComponent<Player>().numPlayer].InputCode) * velocity * Time.deltaTime : 0f * (invertVertical ? -1 : 1), Space.World);
        rb.angularVelocity = Vector3.zero;
    }

    
}
