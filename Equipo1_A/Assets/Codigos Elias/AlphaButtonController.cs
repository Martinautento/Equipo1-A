using UnityEngine;
using UnityEngine.UI;

public class AlphaButtonController : MonoBehaviour
{
    public Button alphaButton;

    void Update()
    {
        // Detecta la pulsación de la tecla Alpha1
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // Ejecuta la acción del botón
            alphaButton.onClick.Invoke();
        }
    }
}
