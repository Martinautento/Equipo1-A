using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void ExitGame()
    {
        // Guarda cualquier estado del juego si es necesario
        Application.Quit();
    }
}
