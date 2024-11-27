using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GolpeoPelota2 : MonoBehaviour
{
    public float fuerzaGolpe = 10f; // Fuerza con la que se golpea la pelota
    public Transform bateador; // Referencia al bateador
    private Rigidbody2D rbPelota;
    private bool pelotaEnRango = false;
    private bool finJuego = false;
    public Puntaje Puntos; // Referencia al script de puntaje

    void Start()
    {
        // Si el bateador es este mismo objeto, lo asignamos automáticamente
        if (bateador == null)
        {
            bateador = this.transform;
        }
    }

    void Update()
    {
        // Detectar entrada táctil en el lado izquierdo de la pantalla
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 toquePos = Input.GetTouch(0).position;
            if (toquePos.x < Screen.width / 2)
            {
                GolpearPelota();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Comprobar si el objeto con el que se colisiona es una pelota u otro objeto del pool
        if (other.CompareTag("Pelota")|| other.CompareTag("Tomate"))
        {
            rbPelota = other.GetComponent<Rigidbody2D>();
            pelotaEnRango = true;

            Debug.Log("Objeto en rango para batear.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Cuando el objeto sale del rango de bateo
        if (other.CompareTag("Pelota") || other.CompareTag("Tomate"))
        {
            rbPelota = null;
            pelotaEnRango = false;
            Debug.Log("Objeto fuera de rango para batear.");
        }
    }

    void GolpearPelota()
    {
        if(!finJuego){
            if (pelotaEnRango && rbPelota != null)
            {
                // Aplicar una fuerza hacia la izquierda en un ángulo de 135 grados
                Vector2 direccionGolpe = new Vector2(-1f, 1f).normalized; // 135 grados
                rbPelota.velocity = direccionGolpe * fuerzaGolpe;
                Debug.Log("¡Objeto bateado!");
                Puntos.AgregaPuntaje(10);  // Añade 10 puntos si se cumple la condición
            }
            else
            {
                Debug.Log("No hay objeto en rango para batear.");
            }
        }
    }

    // Función para finalizar el juego
    public void FinJuego()
    {
        finJuego = true;
    }
}
