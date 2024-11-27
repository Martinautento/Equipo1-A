using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Nivel1 : MonoBehaviour
{
    private Vector3[] linea; // Posiciones predeterminadas para los 3 carriles
    private int Actual;  // Carril actual del jugador
    private Vector2 PosInicio; // Posición inicial del toque
    private Vector2 PosFin;   // Posición final del toque
    public float forwardSpeed = 5f; // Velocidad inicial del impulso
    private float currentSpeed; // Velocidad actual que disminuirá con el tiempo
    public float friction = 0.95f; // Factor de fricción para desacelerar el impulso

    private void Start()
    {
        // Definir las posiciones de los tres carriles (solo la posición Y es relevante)
        linea = new Vector3[3];
        linea[0] = new Vector3(0, 1.2f, 0); // Carril superior (solo Y)
        linea[1] = new Vector3(0, -1.2f, 0); // Carril medio (solo Y)
        linea[2] = new Vector3(0, -3.8f, 0); // Carril inferior (solo Y)

        // Inicia el jugador en el carril medio
        Actual = 1;
        transform.position = new Vector3(transform.position.x, linea[Actual].y, 0);

        // Inicia la velocidad actual en 0
        currentSpeed = 0f;
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
                    // Aplicar un impulso hacia adelante
                    MoveForward();
                }
                else
                {
                    // Guardar la posición inicial del toque si no es en el lado derecho
                    PosInicio = touch.position;
                }
            }
        }

        // Aplicar la fricción al movimiento
        if (currentSpeed > 0)
        {
            currentSpeed *= friction; // Reducir la velocidad con el tiempo
            transform.position += new Vector3(currentSpeed * Time.deltaTime, 0, 0); // Mover el jugador
        }
    }

    // Mover el jugador hacia adelante con un impulso
    private void MoveForward()
    {
        // Dar un impulso inicial
        currentSpeed = forwardSpeed;
    }
}