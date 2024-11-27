using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetos : MonoBehaviour
{
    //Velocidad a la que se movera la ola
    public float velocidad = 10f;
    //Posicion en la que se generara la ola, es un arreglo de 3 posiciones
    private Vector3[] posiciones;
    //Lista de objetos ola
    private List<GameObject> objetos;
    private List<GameObject> olas;
    //objeto ola
    public GameObject olaprefab;
    //objeto ola
    public GameObject staminaprefab;
    //tiempo de lanzamiento entre las objetos
    public float tiempoProximoObjeto;
    //variable para saber si se lanzara una ola o un objeto de stamina
    private bool lanzarOla;

    // Start is called before the first frame update
    void Start()
    {
        //Inicializamos el arreglo de posiciones
        posiciones = new Vector3[3];
        //Definimos las posiciones relativas a la posición del generador en X
        posiciones[0] = new Vector3(0, 1.2f, 0);  // Carril superior
        posiciones[1] = new Vector3(0, -1.2f, 0); // Carril central
        posiciones[2] = new Vector3(0, -3.8f, 0); // Carril inferior
        
        //inicializad el pool de objetos
        objetos = new List<GameObject>();
        olas = new List<GameObject>();
        //Creamos 10 objetos y las desactivamos
        for (int i = 0; i < 5; i++)
        {
            GameObject ola = Instantiate(olaprefab);
            ola.SetActive(false);
            olas.Add(ola);
        }
        for (int i = 0; i < 5; i++)
        {
            GameObject stamina = Instantiate(staminaprefab);
            stamina.SetActive(false);
            objetos.Add(stamina);
        }

        //inicializa el tiempo de lanzamiento de la primera ola
        tiempoProximoObjeto = Time.time + Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //Verifica si es momento de lanzar una ola
        if (Time.time >= tiempoProximoObjeto)
        {
            Lanzar();
            tiempoProximoObjeto = Time.time + Random.Range(1f, 5f);
        }
    }

    //Metodo para lanzar un objeto
    void Lanzar()
    {
        //Busca la primera ola desactivada en el pool
        for (int i = 0; i < 5; i++)
        {
            //Pone el valor de lanzarOla en falso o verdadero de forma aleatoria
            lanzarOla = Random.Range(0, 2) == 0;

            if(lanzarOla==false){
                if (!objetos[i].activeInHierarchy)
                {
                    // Coloca la ola en la posición de lanzamiento con respecto al generador
                    Vector3 nuevaPosicion = transform.position + posiciones[Random.Range(0, 3)];
                    objetos[i].transform.position = nuevaPosicion;

                    //Activa la ola
                    objetos[i].SetActive(true);
                    
                    //Aplica la velocidad a la ola
                    objetos[i].GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidad;
                    break;
                }
        }else
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
    //Metodo para desactivar el generador de olas cuando colisione con el final
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            gameObject.SetActive(false);
        }
    }
}
