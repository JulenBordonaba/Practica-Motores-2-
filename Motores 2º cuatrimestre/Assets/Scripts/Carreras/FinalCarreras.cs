using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalCarreras : MonoBehaviour
{


    public GameManagerLaberinto gmLaberinto;
    private int llegados = 0;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.GetComponent<ContadorVueltas>().vueltasActuales >= other.GetComponent<ContadorVueltas>().vueltasMaximas - 1)
        {
            other.gameObject.GetComponent<MovimientoCoche>().enabled = false;
            other.gameObject.GetComponent<Empuje>().enabled = false;
            G.positions[other.gameObject.GetComponent<Player>().numPlayer] = llegados + 1;
            llegados += 1;
            if (llegados >= G.activePlayers)
            {
                SceneManager.LoadScene("Podium2");
            }
        }
    }

}
