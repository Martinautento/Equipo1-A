using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staminaObj : MonoBehaviour
{
    
    //metodo ontriggerenter2d
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //si el objeto que colisiona es el jugador
        if (collision.CompareTag("Limite"))
        {
            //desactivamos el objeto
            gameObject.SetActive(false);
        }
        //si el objeto que colisiona es el jugador
        if (collision.CompareTag("Player"))
        {
            //desactivamos el objeto
            gameObject.SetActive(false);
        }
    }
}
