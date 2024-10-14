using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GolpeoPelota : MonoBehaviour
{
    public float fuerzaGolpe = 10f; // Fuerza con la que se golpea la pelota
    public Transform bateador; // Referencia al bateador
    public List<GameObject> objetosPrefab; // Lista de prefabs que pueden lanzarse (pelotas u otros objetos)
    public Transform lanzador; // Posición del lanzador

    private Rigidbody2D rbPelota;
    private bool pelotaEnRango = false;

    // Pooling
    public int poolSize = 10; // Tamaño del pool
    private List<GameObject> pool; // Pool de objetos
    private float tiempoMinimoLanzamiento = 3f;
    private float tiempoMaximoLanzamiento = 5f;

    void Start()
    {
        // Si el bateador es este mismo objeto, lo asignamos automáticamente
        if (bateador == null)
        {
            bateador = this.transform;
        }

        // Inicializar el pool de objetos
        pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objetosPrefab[Random.Range(0, objetosPrefab.Count)], lanzador.position, Quaternion.identity);
            obj.SetActive(false); // Desactivar al inicio
            pool.Add(obj);
        }

        // Iniciar la corrutina para lanzar objetos
        StartCoroutine(LanzarObjetos());
    }

    void Update()
    {
        // Detectar entrada táctil en el lado derecho de la pantalla
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Vector2 toquePos = Input.GetTouch(0).position;
            if (toquePos.x > Screen.width / 2)
            {
                GolpearPelota();
            }
        }

        // Opcional: Para pruebas en PC, también puedes usar el clic del mouse
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPos = Input.mousePosition;
            if (clickPos.x > Screen.width / 2)
            {
                GolpearPelota();
            }
        }
        */
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Comprobar si el objeto con el que se colisiona es una pelota u otro objeto del pool
        if (other.CompareTag("Pelota") || objetosPrefab.Contains(other.gameObject))
        {
            rbPelota = other.GetComponent<Rigidbody2D>();
            pelotaEnRango = true;

            Debug.Log("Objeto en rango para batear.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Cuando el objeto sale del rango de bateo
        if (other.CompareTag("Pelota") || objetosPrefab.Contains(other.gameObject))
        {
            rbPelota = null;
            pelotaEnRango = false;
            Debug.Log("Objeto fuera de rango para batear.");
        }
    }

    void GolpearPelota()
    {
        if (pelotaEnRango && rbPelota != null)
        {
            // Aplicar una fuerza hacia la derecha en un ángulo de 45 grados
            Vector2 direccionGolpe = new Vector2(1f, 1f).normalized; // 45 grados
            rbPelota.velocity = direccionGolpe * fuerzaGolpe;
            Debug.Log("¡Objeto bateado!");
        }
        else
        {
            Debug.Log("No hay objeto en rango para batear.");
        }
    }

    IEnumerator LanzarObjetos()
    {
        // Retardo inicial antes de lanzar la primera pelota
        float tiempoInicial = Random.Range(tiempoMinimoLanzamiento, tiempoMaximoLanzamiento);
        yield return new WaitForSeconds(tiempoInicial); // Espera antes del primer lanzamiento

        while (true)
        {
            // Obtener un objeto del pool y lanzarlo
            GameObject objeto = ObtenerObjetoDelPool();
            if (objeto != null)
            {
                // Reactivar el objeto y posicionarlo en el lanzador
                objeto.transform.position = lanzador.position;
                objeto.SetActive(true);

                // Configurar el Rigidbody2D para darle velocidad inicial hacia el bateador
                Rigidbody2D rbObjeto = objeto.GetComponent<Rigidbody2D>();
                rbObjeto.velocity = new Vector2(-5f, 0f); // Velocidad inicial hacia la izquierda
                Debug.Log("Objeto lanzado.");
            }

            // Esperar un tiempo aleatorio antes de lanzar el siguiente objeto
            float tiempoLanzamiento = Random.Range(tiempoMinimoLanzamiento, tiempoMaximoLanzamiento);
            yield return new WaitForSeconds(tiempoLanzamiento);
        }
    }

    GameObject ObtenerObjetoDelPool()
    {
        // Buscar un objeto en el pool que esté desactivado y devolverlo
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null; // No hay objetos disponibles en el pool
    }

    void OnBecameInvisible()
    {
        // Desactivar el objeto cuando salga de la pantalla
        if (rbPelota != null && !rbPelota.gameObject.activeInHierarchy)
        {
            rbPelota.gameObject.SetActive(false);
            Debug.Log("Objeto desactivado al salir de la pantalla.");
        }
    }
}
