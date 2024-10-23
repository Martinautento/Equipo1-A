using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DesactivarFueraDePantalla : MonoBehaviour
{
    void OnBecameInvisible()
    {
        // Desactiva la pelota cuando sale de la pantalla
        Debug.Log("Pelota fuera de pantalla: " + gameObject.name);
        gameObject.SetActive(false);
    }

    //metodo para que se desactive el objeto si es que entra en contacto con un collider con la etiqueda player
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
