using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorOlas : MonoBehaviour
{
    //Velocidad a la que se movera la ola
    public float velocidad = 10f;
    //Posicion en la que se generara la ola, es un arreglo de 3 posiciones
    private Vector3[] posiciones;
    //Lista de objetos ola
    private List<GameObject> olas;
    //objeto ola
    public GameObject olaprefab;
    //tiempo de lanzamiento entre las olas
    public float tiempoProximaOla;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos el arreglo de posiciones
        posiciones = new Vector3[3];
        //Definimos las posiciones relativas a la posición del generador en X
        posiciones[0] = new Vector3(0, 1.2f, 0);  // Carril superior
        posiciones[1] = new Vector3(0, -1.2f, 0); // Carril central
        posiciones[2] = new Vector3(0, -3.8f, 0); // Carril inferior
        
        //inicializad el pool de olas
        olas = new List<GameObject>();
        //Creamos 10 olas y las desactivamos
        for (int i = 0; i < 10; i++)
        {
            GameObject ola = Instantiate(olaprefab);
            ola.SetActive(false);
            olas.Add(ola);
        }

        //inicializa el tiempo de lanzamiento de la primera ola
        tiempoProximaOla = Time.time + Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //Verifica si es momento de lanzar una ola
        if (Time.time >= tiempoProximaOla)
        {
            Lanzar();
            tiempoProximaOla = Time.time + Random.Range(1f, 5f);
        }
    }

    //Metodo para lanzar una ola
    void Lanzar()
    {
        //Busca la primera ola desactivada en el pool
        for (int i = 0; i < olas.Count; i++)
        {
            if (!olas[i].activeInHierarchy)
            {
                // Coloca la ola en la posición de lanzamiento con respecto al generador
                Vector3 nuevaPosicion = transform.position + posiciones[Random.Range(0, 3)];
                olas[i].transform.position = nuevaPosicion;

                //Activa la ola
                olas[i].SetActive(true);
                
                //Aplica la velocidad a la ola
                olas[i].GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidad;
                break;
            }
        }
    }
}
