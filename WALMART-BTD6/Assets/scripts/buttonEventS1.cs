using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonEvent : MonoBehaviour
{
    public void unloadMainScreen()
    {

        SceneManager.LoadScene(1);
        SceneManager.UnloadSceneAsync(0);
    }
}
