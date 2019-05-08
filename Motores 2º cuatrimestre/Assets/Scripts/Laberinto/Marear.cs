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
            print("a");
            if(vecesEntradas[other.GetComponent<Player>().numPlayer]%2==0)
            {
                print("b");
                bool horizontal = !other.GetComponent<PlayerController>().invertHorizontal;
                other.GetComponent<PlayerController>().invertHorizontal = horizontal;
                vecesEntradas[other.GetComponent<Player>().numPlayer] += 1;
                other.gameObject.GetComponent<PlayerController>().disabled = true;
                // print("par");
            }
            else
            {
                print("c");
                bool vertical = !other.GetComponent<PlayerController>().invertVertical;
                other.GetComponent<PlayerController>().invertVertical = vertical;
                vecesEntradas[other.GetComponent<Player>().numPlayer] += 1;

                other.gameObject.GetComponent<PlayerController>().disabled = true;
                //print("impar");
            }
            StartCoroutine(ActivarMarear(other.gameObject));


            //other.GetComponent<PlayerController>().invertHorizontal = Random.Range(0, 2) == 1 ? true : false;
            //other.GetComponent<PlayerController>().invertVertical = Random.Range(0, 2) == 1 ? true : false;
        }
    }


    public IEnumerator ActivarMarear(GameObject player)
    {
        print(player.name);
        Vector3 pos = player.transform.position;
        
        for (int i=0;i<20;i++)
        {
            //print("entra");
            //print(i);
            print("d");
            
            player.transform.position=Vector3.Lerp(pos, new Vector3(transform.position.x,pos.y,transform.position.z),0.05f*i);
            yield return null;
        }
        player.GetComponent<Animator>().SetTrigger("Marear");
        Destroy(this);
    }
}
