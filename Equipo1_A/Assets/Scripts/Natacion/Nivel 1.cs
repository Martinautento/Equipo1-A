using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Este script es para que el jugador se mueva hacia arriba o hacia abajo dependiendo de hacia donde deslice el dedo
// El personaje solo se puede mover en el eje Y hacia 3 posiciones: arriba, en medio y abajo
// Además, ahora el jugador se mueve hacia adelante al presionar el lado derecho de la pantalla
// Esto es en un espacio 2D

public class Nivel1 : MonoBehaviour
{
    private Vector3[] linea; // Posiciones predeterminadas para los 3 carriles
    private int Actual;  // Carril actual del jugador
    private Vector2 PosInicio; // Posición inicial del toque
    private Vector2 PosFin;   // Posición final del toque
    public float forwardSpeed = 1f; // Velocidad del movimiento hacia adelante


    private void Start()
    {

        // Definir las posiciones de los tres carriles (solo la posición Y es relevante)
        linea = new Vector3[3];
        linea[0] = new Vector3(0, 3f, 0); // Carril superior (solo Y)
        linea[1] = new Vector3(0, 0f, 0); // Carril medio (solo Y)
        linea[2] = new Vector3(0, -3f, 0); // Carril inferior (solo Y)

        // Inicia el jugador en el carril medio
        Actual = 1;
        transform.position = new Vector3(transform.position.x, linea[Actual].y, 0);
    }

    private void Update()
    {

        // Detectar input táctil
        if (Input.touchCount > 0)
        {
            UnityEngine.Touch touch = Input.GetTouch(0);

            if (touch.phase == UnityEngine.TouchPhase.Began)
            {
                // Verificar si el toque ocurre en el lado derecho de la pantalla
                if (touch.position.x > Screen.width / 2)
                {
                        MoveForward(); // Mover hacia adelante si se toca el lado derecho
                    
                    
                }
                else
                {
                    // Guardar la posición inicial del toque si no es en el lado derecho
                    PosInicio = touch.position;
                }
            }
            else if (touch.phase == UnityEngine.TouchPhase.Ended && touch.position.x < Screen.width / 2)
            {

            }
        }
    }



    // Mover el jugador hacia adelante en el eje X
    private void MoveForward()
    {
            // Mover al jugador hacia adelante
            transform.position += new Vector3(forwardSpeed, 0, 0);
    }
}
