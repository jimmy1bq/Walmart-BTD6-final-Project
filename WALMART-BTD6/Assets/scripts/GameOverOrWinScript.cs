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
        Time.timeScale = 1f;
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
    public void unPauseGame()
    {
        Time.timeScale = orginalTimeScale;
        pauseScreenGUI.LeanMove(new Vector3(830, 1500, 0), 1f);
    }
    //waitForFunction is there so I can time when the game pause like after the menu falls down
    IEnumerator waitForfuncton()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0f;
    }
  
}
