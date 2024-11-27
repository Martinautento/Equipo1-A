using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Este método se llamará cuando se haga clic en el botón.
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
