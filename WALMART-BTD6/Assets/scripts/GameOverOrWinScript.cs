using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using NUnit.Framework.Internal.Execution;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class GameOverOrWinScript : MonoBehaviour
{
    public static GameOverOrWinScript instance;
    Coroutine waitForFunction=null;
    
    public bool pasued = false;
    [SerializeField] GameObject pauseScreenGUI;
    float orginalTimeScale;
    private void Awake()
    {
        if (instance != null) { return; }
        instance = this;
    }

    public void gameRestart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void gameExitt() {
        SceneManager.LoadScene(1);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().name);
    }
    public void pauseGame() {
        if (Time.timeScale!=0) {
            orginalTimeScale = Time.timeScale;
        }
        if (waitForFunction != null) {
            StopCoroutine(waitForfuncton());
        }
        pauseScreenGUI.LeanMove(new Vector3(830, 550, 0), 1f);
        waitForFunction=StartCoroutine(waitForfuncton());
        pasued = true;
    }
    public void unPauseGame()
    {
        if (waitForFunction != null) {
        StopCoroutine(waitForFunction);   
            
        }
        pasued=false;
        Time.timeScale = orginalTimeScale;
        pauseScreenGUI.LeanMove(new Vector3(830, 1500, 0), 1f);
    }
    //waitForFunction is there so I can time when the game pause like after the menu falls down
    IEnumerator waitForfuncton()
    {
        yield return new WaitForSeconds(1.5f);
        if (pasued)
        {
            Time.timeScale = 0f;
        }
    }
   
}
