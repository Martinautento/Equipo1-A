using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para manipulación de portales para las pelotas del juego.
public class Portales : MonoBehaviour
{
    // Variable para determinar si el portal es de entrada o de salida.
    public bool entrada;
    // Variable para determinar el transform del portal conectado.
    public Transform portalConectado;
    // Transform del portal de entrada
    public Transform portalEntrada;

    // Variable para determinar la velocidad de la pelota.
    private Vector2 velocidad;
    // Variable booleana para determinar si ya se estableció un número de pelotas
    private bool x;
    // Variable para determinar la cantidad de pelotas que deben pasar por el portal.
    public int cantidadPelotas;
    private int pass = 0;

    // Referencia al SpriteRenderer del portal de entrada para activarlo/desactivarlo
    private SpriteRenderer spriteRendererEntrada;
    private SpriteRenderer spriteRendererSalida;

    private void Start()
    {
        // Obtener el componente SpriteRenderer de ambos portales
        spriteRendererEntrada = portalEntrada.GetComponent<SpriteRenderer>();
        spriteRendererSalida = portalConectado.GetComponent<SpriteRenderer>();

        // Desactivar ambos sprites al inicio
        spriteRendererEntrada.enabled = false;
        spriteRendererSalida.enabled = false;
    }

    // Método para detectar colisiones con OnTriggerEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!x)
        {
            EstablecerNumeroPelotas();
        }

        if (collision.CompareTag("Pelota") || collision.CompareTag("Tomate"))
        {
            pass++;
            if(pass== cantidadPelotas -1){
                // Activa los SpriteRenderers de entrada y salida para indicar que el portal está activo
                spriteRendererEntrada.enabled = true;
                
            }

            // Si la variable pass es igual a cantidadPelotas, activa el portal
            if (pass == cantidadPelotas)
            {
                spriteRendererSalida.enabled = true;
                // Obtiene el Rigidbody2D de la pelota y guarda su velocidad
                Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
                velocidad = rb.velocity;

                // Teletransporta la pelota al portal conectado
                collision.transform.position = portalConectado.position;

                // Cambia la dirección de la velocidad
                rb.velocity = -velocidad * 0.75f;

                // Reinicia el contador de pelotas y desactiva el estado de activación
                pass = 0;
                x = false;

                // Desactiva los SpriteRenderers después de la teletransportación
                StartCoroutine(DesactivarSprites());
            }
        }
    }

    // Método para establecer un número aleatorio de pelotas que deben pasar
    private void EstablecerNumeroPelotas()
    {
        cantidadPelotas = Random.Range(1, 10);
        x = true;
    }

    // Corrutina para desactivar los SpriteRenderers después de un corto retraso
    private IEnumerator DesactivarSprites()
    {
        yield return new WaitForSeconds(0.5f);
        spriteRendererEntrada.enabled = false;
        spriteRendererSalida.enabled = false;
    }

}
