using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Asigna aquí el jugador en el inspector
    private Vector3 offset;  // Diferencia entre la cámara y el jugador

    private void Start()
    {
        // Calcular el desplazamiento inicial entre la cámara y el jugador
        offset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        // Mantener la posición en Y y Z, pero mover la cámara en X siguiendo al jugador
        Vector3 newPosition = new Vector3(player.position.x + offset.x, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}
