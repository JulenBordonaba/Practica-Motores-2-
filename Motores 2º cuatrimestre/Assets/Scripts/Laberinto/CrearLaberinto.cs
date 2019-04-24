using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearLaberinto : MonoBehaviour
{
    public Texture2D laberinto;
    public List<BloqueColor> bloques = new List<BloqueColor>();



    [ContextMenu("Crear Laberinto")]
    public void Crear()
    {
        GameObject padre = Instantiate(new GameObject("Laberinto"), Vector3.zero, Quaternion.identity);
        for (int i = 0; i < laberinto.width; i++)
        {
            for (int j = 0; j < laberinto.height; j++)
            {
                foreach (BloqueColor b in bloques)
                {
                    if (laberinto.GetPixel(i, j) == b.color)
                    {
                        GameObject bloque = Instantiate(b.bloque, padre.transform);
                        bloque.transform.position = new Vector3(i, 0.5f, j);

                        switch(Random.Range(4,7))
                        {
                            case 0:
                                bloque.transform.rotation = Quaternion.Euler(0, 0, 0);
                                break;
                            case 1:
                                bloque.transform.rotation = Quaternion.Euler(90, 0, 0);
                                break;
                            case 2:
                                bloque.transform.rotation = Quaternion.Euler(-90, 0, 0);
                                break;
                            case 3:
                                bloque.transform.rotation = Quaternion.Euler(180, 0, 0);
                                break;
                            case 4:
                                bloque.transform.rotation = Quaternion.Euler(0, 90, 0);
                                break;
                            case 5:
                                bloque.transform.rotation = Quaternion.Euler(0, -90, 0);
                                break;
                            case 6:
                                bloque.transform.rotation = Quaternion.Euler(0, 180, 0);
                                break;
                            case 7:
                                bloque.transform.rotation = Quaternion.Euler(0, 0, 90);
                                break;

                            case 8:
                                transform.rotation = Quaternion.Euler(0, 0, -90);
                                break;

                            case 9:
                                transform.rotation = Quaternion.Euler(0, 0, 180);
                                break;
                        }

                    }
                }
            }
        }
    }
}
[System.Serializable]
public class BloqueColor
{
    public GameObject bloque;
    public Color color;
}


