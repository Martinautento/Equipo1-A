using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{
    public Text scoreText;      // Asigna el Text desde el Inspector
    private int score = 0;       // Variable para almacenar el puntaje

    // Función pública para actualizar el puntaje
    public void AgregaPuntaje(int points)
    {
        score += points;
        ActualizaDisplay();
    }

    // Actualiza el Text en el Canvas
    void ActualizaDisplay()
    {
        scoreText.text = "Puntaje: " + score.ToString();
    }
}
