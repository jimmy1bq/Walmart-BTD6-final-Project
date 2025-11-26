using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework.Internal.Execution;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class GameOverOrWinScript : MonoBehaviour
{
    [SerializeField] GameObject pauseScreenGUI;
    float orginalTimeScale;
    public void gameRestart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void gameExitt() {
        SceneManager.LoadScene(1);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }
    public void pauseGame() { 
        orginalTimeScale = Time.timeScale;
        pauseScreenGUI.LeanMove(new Vector3(830, 550, 0), 1f);
        StartCoroutine(waitForfuncton());
    }
    IEnumerator waitForfuncton()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
    }
    public void unPauseGame() {
        Time.timeScale = orginalTimeScale;
        pauseScreenGUI.LeanMove(new Vector3(830, 1500, 0), 1f);
    }
}
