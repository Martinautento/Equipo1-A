using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class nata : MonoBehaviour
{
    // Asigna este script al botón y asegúrate de asignar el nombre de la escena en el Inspector.
    public string Nivel1;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene(Nivel1);
    }
}
