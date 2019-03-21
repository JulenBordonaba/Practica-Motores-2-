using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Podium : MonoBehaviour
{
    public GameObject[] podiums;
    public Material[] materials;
    public float tiempoSubida = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Posicionar(1, 2,3,4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Posicionar(int player1, int player2, int player3, int player4)
    {
        StartCoroutine(PonerEnPodio(0, player1));
        StartCoroutine(PonerEnPodio(1, player2));
        StartCoroutine(PonerEnPodio(2, player3));
        StartCoroutine(PonerEnPodio(3, player4));
    }

    public void Posicionar(int player1, int player2, int player3)
    {
        StartCoroutine(PonerEnPodio(0, player1));
        StartCoroutine(PonerEnPodio(1, player2));
        StartCoroutine(PonerEnPodio(2, player3));
    }

    public void Posicionar(int player1, int player2)
    {
        StartCoroutine(PonerEnPodio(0, player1));
        StartCoroutine(PonerEnPodio(1, player2));
    }

    public IEnumerator PonerEnPodio(int player, int position)
    {
        podiums[player].GetComponent<MeshRenderer>().material = materials[position-1];
        
        Vector3 startPosition = podiums[player].transform.position;
        float time = 0;
        do
        {
            podiums[player].transform.position = Vector3.Lerp(startPosition, startPosition + new Vector3(0, (4-position)*2, 0),time);
            time += tiempoSubida / 100;
            yield return null;

        } while (time < 100);
    }
    

}
