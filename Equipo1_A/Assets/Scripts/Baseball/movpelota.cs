using UnityEngine;

public class MovimientoPelota : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de la pelota
    public Transform lanzador; // Referencia al lanzador (objeto que lanza la pelota)
    public Transform pelota; // Referencia a la pelota
    public Transform bateador; // Referencia al bateador

    private Vector3 direccion;

    void Start()
    {

        // posicion inicial de la pelota igual a la del lanzador
        transform.position = lanzador.position;
        direccion = (bateador.position - transform.position).normalized;


    }

    void Update()
    {
        // Mover la pelota hacia el bateador
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    // Opcional: Reiniciar la pelota a la posición del lanzador después de ser bateada
    public void ReiniciarPelota()
    {
        if (lanzador != null)
        {
            transform.position = lanzador.position;
            // Opcional: Reiniciar la velocidad o cualquier otro estado necesario
        }
    }
}
