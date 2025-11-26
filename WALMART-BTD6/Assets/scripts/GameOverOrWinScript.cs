using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOrWinScript : MonoBehaviour
{
    public void gameRestart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void gameExitt() {
        SceneManager.LoadScene(1);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
