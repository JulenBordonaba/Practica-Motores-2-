using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marear : MonoBehaviour
{
    public static int[] vecesEntradas = new int[4];


    // Start is called before the first frame update
    void Start()
    {
       for(int i =0;i<vecesEntradas.Length;i++)
        {
            vecesEntradas[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(vecesEntradas[other.GetComponent<Player>().numPlayer]%2==0)
            {
                bool horizontal = !other.GetComponent<PlayerController>().invertHorizontal;
                other.GetComponent<PlayerController>().invertHorizontal = horizontal;
                vecesEntradas[other.GetComponent<Player>().numPlayer] += 1;
                other.gameObject.GetComponent<PlayerController>().enabled = false;
                print("par");
            }
            else
            {
                bool vertical = !other.GetComponent<PlayerController>().invertVertical;
                other.GetComponent<PlayerController>().invertVertical = vertical;
                vecesEntradas[other.GetComponent<Player>().numPlayer] += 1;

                other.gameObject.GetComponent<PlayerController>().enabled = false;
                print("impar");
            }
            StartCoroutine(ActivarMarear(other.gameObject));


            //other.GetComponent<PlayerController>().invertHorizontal = Random.Range(0, 2) == 1 ? true : false;
            //other.GetComponent<PlayerController>().invertVertical = Random.Range(0, 2) == 1 ? true : false;
        }
    }


    public IEnumerator ActivarMarear(GameObject player)
    {
        print(player.name);
        
        for(int i=20;i<100;i++)
        {
            print("entra");
            //print(i);
            player.transform.position=Vector3.Lerp(player.transform.position,transform.position/* new Vector3(transform.position.x,player.transform.position.y,transform.position.z)*/, 0.01f*i);
            yield return null;
        }

        player.GetComponent<Animator>().SetTrigger("Marear");
    }
}
