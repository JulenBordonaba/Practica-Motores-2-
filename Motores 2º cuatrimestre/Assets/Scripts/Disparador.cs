using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour {

    public int jugador = 0;
    public Transform spawnPoint;
    public GameObject shotPrefab;
    public float maxRotation = 30;
    public float minRotation = -30;
    public float cooldown = 5f;
    public float velocidadDisparo = 1;
    public float velocidadRotacion = 1f;
    public bool trayectoria = true;
    public LineRenderer line;

    private float rotation = 0;
    private float cooldownLeft;

	// Use this for initialization
	void Start () {
        rotation = gameObject.transform.eulerAngles.y;
        cooldownLeft = 0f;

    }
	
	// Update is called once per frame
	void Update () {
        Rotate();
        if(cooldownLeft > 0)
        {
            cooldownLeft -= Time.deltaTime;
        }
        else
        {
            if (Input.GetButtonDown("Button2" + InputManager.controles[jugador].InputCode))
            {
                Shot();
            }
        }

        if(trayectoria)
        {
            MarcarTrayectoria();
        }
        
	}

    public void MarcarTrayectoria()
    {
        Ray ray = new Ray();
        RaycastHit hit;
        ray.origin = spawnPoint.position;
        ray.direction = transform.forward;
        
        if(Physics.Raycast(ray, out hit ))
        {
            line.SetPosition(0, ray.origin);
            line.SetPosition(1, hit.point);
        }
    }

    public void Rotate()
    {
        rotation += Input.GetAxis("Horizontal" + InputManager.controles[jugador].InputCode) * velocidadRotacion;
        rotation = Mathf.Clamp(rotation, minRotation, maxRotation);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, rotation, transform.localEulerAngles.z);
    }

    public void Shot()
    {
        cooldownLeft = cooldown;
        GameObject disparo=Instantiate(shotPrefab, spawnPoint.position, transform.rotation);
        disparo.GetComponent<Pelota>().velocity = velocidadDisparo;
        disparo.GetComponent<Rigidbody>().velocity = transform.forward * velocidadDisparo;

    }
}
