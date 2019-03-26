using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerteCubeWall : MonoBehaviour
{
    [Tooltip("La lista contiene todos los game objects que van a formar la pared, cubos, combas, espacios en blanco y gemas")]
    private List<GameObject> wall = new List<GameObject>();//
    [Header("Prefabs")]
    [Tooltip("Hay que arrastra el prefab de los cubos para romper")]
    public GameObject cubePrefab;
    [Tooltip("Hay que arrastrar el prefab de la bomba")]
    public GameObject bombPrefab;
    [Tooltip("Hay que arrastrar el prefab de la gema")]
    public GameObject gemPrefab;

    [Header("CubeReference")]
    [Tooltip("Arrastra el cubo de referencia para generar la pared. Lo ideal es el primer cubo de la línea del suelo. El más a la izquierda")]
    public GameObject cubeReference;
    [Tooltip("Separación entre cubo y cubo. 1.6 es un buen número")]
    public float cubeSeparation;
    [Tooltip("Numero de columnas que va a tener la pared. Ahora mismo son 18")]
    public float columns;
    [Tooltip("Numero de filas que va a tener la pared. Ahora mismo son 17")]
    public float rows;

    private int randomCube;
    
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int k = 1; k < rows; k++)
            {
                randomCube = Random.Range(1, 100);//numero aleatorio de 1 a 100. De 1 a 70 es un cubo, de 71 a 76 es una bomba, de 77 a 86 es una gema, el resto es un espacio en blanco
                if(randomCube>=1 && randomCube <= 70)
                {
                    //crear cubo en su posicion
                    Instantiate(cubePrefab, new Vector3(cubeReference.transform.position.x + (i* cubeSeparation), cubeReference.transform.position.y - (k*cubeSeparation), cubeReference.transform.position.z), cubeReference.transform.rotation);
                }

                if (randomCube >= 71 && randomCube <= 74)
                {
                    //crear cubo en su posicion
                    Instantiate(bombPrefab, new Vector3(cubeReference.transform.position.x + (i * cubeSeparation), cubeReference.transform.position.y - (k * cubeSeparation), cubeReference.transform.position.z), cubeReference.transform.rotation);
                }

                if (randomCube >= 75 && randomCube <= 91)
                {
                    //crear cubo en su posicion
                    Instantiate(gemPrefab, new Vector3(cubeReference.transform.position.x + (i * cubeSeparation), cubeReference.transform.position.y - (k * cubeSeparation), cubeReference.transform.position.z), cubeReference.transform.rotation);
                }


            }
        }
    }

}
