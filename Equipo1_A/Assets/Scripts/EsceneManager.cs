using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Libreria para manejar las escenas
using UnityEngine.SceneManagement;

//Clase para manejar las escenas

public class EsceneManager : MonoBehaviour
{
    //Metodo para ir a la escena que se le indique
    public void IrAEscena(string nombreEscena)
    {
        //Cargamos la escena que se le indique
        UnityEngine.SceneManagement.SceneManager.LoadScene(nombreEscena);
    }
}
