using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [Header("Menu Opciones")]
    [Tooltip("Arrastra el Canvas con el Menu Options")]
    public Canvas menuOptions;
    [Tooltip("Arrastra el boton de continuar")]
    public Button btnContinue;
    [Tooltip("Booleana para controlar si está el menú o no")]
    public bool enMenus;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("MenuOpciones"))//para sacar el menu 
        {
            Debug.Log("esc");
            MenuFunction();//oculta o desoculta el menu
        }
    }

    public void MenuFunction()//oculta y desoculta el menu y para el tiempo del juego
    {
        if (!enMenus)//si hay menu
        {
            menuOptions.gameObject.SetActive(true);//lo muestra
            enMenus = true;
            btnContinue.GetComponent<Button>().Select();
            Time.timeScale = 0;//para el juego
        }
        else
        {
            menuOptions.gameObject.SetActive(false);//lo oculta
            Time.timeScale = 1;//reanuda el juego
            enMenus = false;
        }
    }
}
