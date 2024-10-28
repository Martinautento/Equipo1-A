using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Nivel1Nata : MonoBehaviour
{
    public string sceneName;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}
