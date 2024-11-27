using UnityEngine;
using UnityEngine.UI;  // Necesario para usar la clase Text

public class CronometroNat : MonoBehaviour
{
    public Text tiempoTexto;  // Asigna el componente de texto desde el Inspector
    private float tiempoTranscurrido = 0f;
    private bool corriendo = true;  // Empieza automáticamente

    //start is called before the first frame update
    void Start()
    {
        IniciarCronometro();  // Inicia el cronómetro
    }
    void Update()
    {
        if (corriendo)
        {
            tiempoTranscurrido += Time.deltaTime;  // Incrementa el tiempo cada frame
            MostrarTiempo(tiempoTranscurrido);
        }
    }

    // Método para mostrar el tiempo en formato MM:SS
    void MostrarTiempo(float tiempo)
    {
        int minutos = Mathf.FloorToInt(tiempo / 60);  // Calcula los minutos
        int segundos = Mathf.FloorToInt(tiempo % 60);  // Calcula los segundos

        tiempoTexto.text = string.Format("{0:00}:{1:00}", minutos, segundos);  // Formato MM:SS
    }

    // Métodos adicionales opcionales
    public void IniciarCronometro() { corriendo = true; }
    public void DetenerCronometro() { corriendo = false; }
    public void ReiniciarCronometro()
    {
        tiempoTranscurrido = 0f;
        MostrarTiempo(tiempoTranscurrido);
    }
}
