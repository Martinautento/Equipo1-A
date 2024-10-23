using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanzamiento : MonoBehaviour
{
    public GameObject pelotaPrefab; // Prefab de la pelota a instanciar
    public Transform lanzador; // Posición del lanzador
    public float fuerza = 10f; // Fuerza de lanzamiento
    public int maxPelotas = 10; // Máximo número de pelotas que queremos manejar
    private List<GameObject> poolPelotas; // Lista de pelotas que usaremos como pool
    private float tiempoProximoLanzamiento; // Para controlar el tiempo entre lanzamientos

    void Start()
    {
        // Inicializa el pool de pelotas, creando objetos desactivados
        poolPelotas = new List<GameObject>();

        for (int i = 0; i < maxPelotas; i++)
        {
            GameObject pelota = Instantiate(pelotaPrefab); // Instancia la pelota
            pelota.SetActive(false); // Desactívala al inicio
            poolPelotas.Add(pelota); // Añádela al pool
        }

        // Inicializa el tiempo para el primer lanzamiento
        tiempoProximoLanzamiento = Time.time + Random.Range(1, 3);
    }

    void Update()
    {
        // Verifica si es momento de lanzar una pelota
        if (Time.time >= tiempoProximoLanzamiento)
        {
            Lanzar();
            tiempoProximoLanzamiento = Time.time + Random.Range(1, 3);
        }
    }

    void Lanzar()
    {
        Debug.Log("Intentando lanzar una pelota...");
        for (int i = 0; i < poolPelotas.Count; i++)
        {
            // Busca la primera pelota desactivada en el pool
            if (!poolPelotas[i].activeInHierarchy)
            {
                Debug.Log("Lanzando pelota: " + poolPelotas[i].name);
                poolPelotas[i].transform.position = lanzador.position; // Coloca la pelota en la posición del lanzador
                poolPelotas[i].SetActive(true); // Activa la pelota
                poolPelotas[i].GetComponent<Rigidbody2D>().velocity = Vector2.right * fuerza; // Aplica la fuerza
                break; // Sale del ciclo al activar una pelota
            }
        }
    }
}

