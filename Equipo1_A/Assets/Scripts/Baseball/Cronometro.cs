using UnityEngine;
using UnityEngine.UI;  // Para manipular el Text UI

public class Cronometro : MonoBehaviour
{
    public float timeRemaining = 90f;  
    public Text timerText;             // Asigna el Text desde el Inspector
    public GameObject endPanel;        // Panel que se mostrará al finalizar

    public GolpeoPelota Player;        // Referencia al script de golpeo 

    private bool timerRunning = true;  // Controla si el cronómetro sigue activo

    // Start is called before the first frame update
    void Start()
    {
        endPanel.SetActive(false);  // Oculta el panel de fin de nivel
    }
    void Update()
    {
        if (timerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerRunning = false;
                EndLevel();
            }
        }
    }

    void UpdateTimerDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void EndLevel()
    {
        endPanel.SetActive(true);  // Muestra el panel de fin de nivel
        // Detén el juego o realiza otras acciones necesarias
        Player.FinJuego();
    }
}
