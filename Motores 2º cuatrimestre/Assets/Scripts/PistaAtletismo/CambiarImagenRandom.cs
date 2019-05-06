using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambiarImagenRandom : MonoBehaviour
{
    [Tooltip("Arrastra las imágenes que quieres que cambien de forma aleatoria")]
    public List<Sprite> imagenes = new List<Sprite>();//
    [Tooltip("Tiempo que se verá la imagen en pantalla cuando cambia de forma aleatoria. 0.1 es un buen número")]
    public float segundos;//segundos que queremos que esté una imagen en pantalla, antes de cambiar a la siguiente
    [Header("Boton Play")]
    [Tooltip("Arrastra el boton de play")]
    public Button btPlay;
    bool imagenEnPantalla;//variable booleana para controlar que las imágenes no pasan demasiado rápido
    bool stop;
    int last;//variable auxiliar con el numero máximo de elemntos en la lista.
    int numeroAleatorio;//variable donde se va a guardar el numero generado al azar

    // Start is called before the first frame update
    void Start()
    {
        last = imagenes.Count;//last contiene el valor de la ultima posicion de la lista
    }

    // Update is called once per frame
    void Update()
    {
        if (!imagenEnPantalla && !stop)
        {
            imagenEnPantalla = true;//cambiamos la booleana para evitar que las imágenes pasen de forma instantánea
            StartCoroutine(CambiarImagen());//se camiba la imagen por otra al azar de la lista
        }
            
    }

    IEnumerator CambiarImagen()//cambia de imagen por otra al azar
    {
        yield return new WaitForSeconds(segundos);//esperar segundos antes de la siguiente activación
        numeroAleatorio = Random.Range(0, last);//se genera un numero aleatorio entre 0 y el último elemento de la lista
        gameObject.GetComponent<Image>().sprite = imagenes[numeroAleatorio];// se muestra la imagen que coincide con el numero aleatorio de la lista
        imagenEnPantalla = false;
    }

    public void StopImagenRandom()// detiene la secuencia de imagenes aleatorias. tras enseñar 3 imagenes aleatorias más y relentizando el tiempo entre ellas elige un minijuego al azar.
    {
        stop = true;
        StartCoroutine(CambiarImagenLento(segundos + 0.3f));//se camiba la imagen por otra al azar de la lista
    }

    IEnumerator CambiarImagenLento(float secs)//cambia de imagen por otra al azar, recibe un float con los segundos
    {
        yield return new WaitForSeconds(secs);//esperar segundos antes de la siguiente activación
        numeroAleatorio = Random.Range(0, last);//se genera un numero aleatorio entre 0 y el último elemento de la lista
        gameObject.GetComponent<Image>().sprite = imagenes[numeroAleatorio];// se muestra la imagen que coincide con el numero aleatorio de la lista
        StartCoroutine(CambiarImagenLento2(segundos + 0.6f));//se camiba la imagen por otra al azar de la lista
    }

    IEnumerator CambiarImagenLento2(float secs)//cambia de imagen por otra al azar, recibe un float con los segundos
    {
        yield return new WaitForSeconds(secs);//esperar segundos antes de la siguiente activación
        numeroAleatorio = Random.Range(0, last);//se genera un numero aleatorio entre 0 y el último elemento de la lista
        gameObject.GetComponent<Image>().sprite = imagenes[numeroAleatorio];// se muestra la imagen que coincide con el numero aleatorio de la lista
        StartCoroutine(CambiarImagenLento3(segundos + 0.9f));//se camiba la imagen por otra al azar de la lista
    }

    IEnumerator CambiarImagenLento3(float secs)//cambia de imagen por otra al azar, recibe un float con los segundos
    {
        int i = 0;
        yield return new WaitForSeconds(secs);//esperar segundos antes de la siguiente activación
        foreach (Sprite imagen in imagenes)
        {
            if (imagen.name == GameManagerGlobal.i.minijuegos[GameManagerGlobal.i.siguienteMinijuego])
                gameObject.GetComponent<Image>().sprite = imagenes[i];// se muestra la imagen que coincide con el numero aleatorio de la lista
            i++;
        }
        btPlay.gameObject.SetActive(true);
        btPlay.Select();
    }

    public void ElegirMinijuego()
    {
        Debug.Log("siguiente minijuego: " + GameManagerGlobal.i.minijuegos[GameManagerGlobal.i.siguienteMinijuego]);
        SceneManager.LoadScene(GameManagerGlobal.i.minijuegos[GameManagerGlobal.i.siguienteMinijuego]);
    }

    public void ResetearVariables()
    {
        stop = false;
        imagenEnPantalla = false;
    }
}
