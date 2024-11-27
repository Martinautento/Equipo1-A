using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasLv1_2 : MonoBehaviour
{
    public GameObject victoria;
    
    //Activa el mensaje de victoria de la pantalla
    public void ActivarVictoria()
    {
        victoria.SetActive(true);
    }

}
