using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activadorElementosAleatorio : MonoBehaviour
{
    [Tooltip("Lista con el número de objetos que quieres que se muestren de forma aleatoria")]
    public List<GameObject> objects = new List<GameObject>();
    [Tooltip("Numero de segundos que transcurren entre una activación y otra. 4.016667 es un buen número")]
    public float seconds;
    [Tooltip("Numero de objetos que son activados a la vez")]
    public float activarMultiplesObjetos;
    [Tooltip("Aumento de dificultad. Cuanto menor sea el mayor más rápido aumentará la dificultad. 0.005 es una progresion adecuada en los jugadpres y 0.5 en las filas de jugadores")]
    public float aumentoDificultad;

    private bool objetoEnActivo;//variable auxiliar para evitar que se active un objeto mientras hay otro activo
    private bool rondaEnActivo;//variable auxiliar para evitar que se active una ronda mientras hay otra activa
    private int numeroRandom;//variable para guardar el numero aleatorio generado
    private static float contadorActivaciones;//conador, cuantas mas rondas pasen mas difícil se vuelve el juego
    int last ;//variable auxiliar con el numero máximo de elemntos en la lista.
    private List<int> indices = new List<int>();//lista con todos los indices de los objetos generados aleatorioamente

    private void Start()
    {
        last = objects.Count;//last contiene el valor de la ultima posicion de la lista
    }

    private void OnEnable()
    {
        contadorActivaciones++;//suma una ronda
        rondaEnActivo = false;//desactivar la variable auxilair
    }

    // Update is called once per frame
    void Update()
    {   
        if (!rondaEnActivo)
        {
            rondaEnActivo = true;//activamos la ronda para que no se repita hasta el infinito

            for (int i = 0; i < activarMultiplesObjetos + (Mathf.Round(contadorActivaciones * (aumentoDificultad))); i++)//va a activar tantos objetos como se le ha indicado en activarMultiplesObjetos
            {
                numeroRandom = Random.Range(0, last);//se genera un numero aleatorio para determinar, al azar, que objeto se activa
                indices.Add(numeroRandom);//añade el numero generado a la lista con los indices
                ActivarObjeto(objects[numeroRandom]);//activamos el objeto
            }
            StartCoroutine(DesactivarRonda());//desactivar ronda e inicializar valores
        }
    }

    void ActivarObjeto(GameObject objeto)
    {
        objeto.SetActive(true); //activa el objeto
        if (objeto.GetComponent<Animator>())
        {//si el objeto tiene una animacíón, esta se reproduce
            AnimatorClipInfo[] m_CurrentClipInfo;//variable para conseguir el nombre del clip por defecto
            m_CurrentClipInfo = objeto.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0);//ubicacion del clip por defecto
            objeto.GetComponent<Animator>().Play(m_CurrentClipInfo[0].clip.name);//reproducir el clip por defecto
        }
    }

    IEnumerator DesactivarRonda()
    {
        yield return new WaitForSeconds(seconds);//esperar segundos antes de la siguiente activación
        foreach (int  indice in indices)//recorre una lista con todos los objetos aleatorios activados
        {
            objects[indice].SetActive(false);//desactiva cada objeto generado al azar
        }
        indices.Clear();//limpia la lista para que en la siguiente ronda esté vacía
        rondaEnActivo = false;//desactivar la variable auxilair
    }
}
