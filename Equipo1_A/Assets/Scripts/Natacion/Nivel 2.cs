using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


// Este script es para que el jugador se mueva hacia arriba o hacia abajo dependiendo de hacia donde deslice el dedo
// El personaje solo se puede mover en el eje Y hacia 3 posiciones: arriba, en medio y abajo
// Además, ahora el jugador se mueve hacia adelante al presionar el lado derecho de la pantalla
// Esto es en un espacio 2D

public class Nivel2_0 : MonoBehaviour
{
    private Vector3[] linea; // Posiciones predeterminadas para los 3 carriles
    private int Actual;  // Carril actual del jugador
    private float Deslizado = 50f; // Mínimo movimiento en píxeles para ser considerado un swipe
    private Vector2 PosInicio; // Posición inicial del toque
    private Vector2 PosFin;   // Posición final del toque
    public float forwardSpeed = 1f; // Velocidad del movimiento hacia adelante
    private float currentSpeed; // Velocidad actual que disminuirá con el tiempo
    public float friction = 0.95f; // Factor de fricción para desacelerar el impulso
    public float xposicion = 0f;
    private bool Fin=false;

    private void Start()
    {
        //bloquea la rotacion del objeto
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;

        // Definir las posiciones de los tres carriles (solo la posición Y es relevante)
        linea = new Vector3[3];
        linea[0] = new Vector3(0, 1.2f, 0); // Carril superior (solo Y)
        linea[1] = new Vector3(0, -1.2f, 0); // Carril medio (solo Y)
        linea[2] = new Vector3(0, -3.8f, 0); // Carril inferior (solo Y)


        // Inicia el jugador en el carril medio
        Actual = 1;
        transform.position = new Vector3(transform.position.x, linea[Actual].y, 0);

        currentSpeed = 0f;
    }

    private void Update()
    {
        if(Fin==false){

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
                // Guardar la posición final del toque
                PosFin = touch.position;

                // Determinar la distancia del swipe
                float swipeDeltaY = PosFin.y - PosInicio.y;

                // Detectar un swipe vertical
                if (Mathf.Abs(swipeDeltaY) > Deslizado)
                {
                    if (swipeDeltaY > 0) // Swipe hacia arriba
                    {
                        MoveUp();
                    }
                    else // Swipe hacia abajo
                    {
                        MoveDown();
                    }
                    
                }
                PosFin = PosInicio = Vector2.zero; // Reiniciar las posiciones
                swipeDeltaY = 0;
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

    // Mover el jugador hacia arriba (si no está ya en el carril superior)
    private void MoveUp()
    {
        if (Actual > 0)
        {
            xposicion=linea[Actual].x;
            Actual--;
            MoveToCurrentLane();
        }
    }

    // Mover el jugador hacia abajo (si no está ya en el carril inferior)
    private void MoveDown()
    {
        if (Actual < linea.Length - 1)
        {
            xposicion=linea[Actual].x;
            Actual++;
            MoveToCurrentLane();
        }
    }

    // Actualizar la posición del jugador al carril actual
    private void MoveToCurrentLane()
    {
        if(Actual==1){
            // Mantener la posición en el eje X, pero cambiar la posición en el eje Y
        transform.position = new Vector3(transform.position.x - xposicion, linea[Actual].y, 0);
        }else{
        // Mantener la posición en el eje X, pero cambiar la posición en el eje Y
        transform.position = new Vector3(transform.position.x + linea[Actual].x, linea[Actual].y, 0);
        }
    }

    // Mover el jugador hacia adelante en el eje X
    private void MoveForward()
    {
         // Dar un impulso inicial
        currentSpeed = forwardSpeed;
    }

    // Metodo para detectar la colision con una ola
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ola")
        {
            // Si el jugador colisiona con una ola, se reinicia la velocidad
            currentSpeed = -forwardSpeed * 5f;
            //Empuja al jugador hacia atrás
            transform.position += new Vector3(currentSpeed * Time.deltaTime, 0, 0);
        }
        //Si el juegador colisiona con el fin del nivel
        if (collision.gameObject.tag == "Finish")
        {
            Fin=true;
        }
    }
}
