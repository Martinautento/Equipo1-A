using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fin : MonoBehaviour
{
    public GameObject victoria;
    
    //Activa el mensaje de victoria de la pantalla
    public void ActivarVictoria()
    {
        victoria.SetActive(true);
    }
}
