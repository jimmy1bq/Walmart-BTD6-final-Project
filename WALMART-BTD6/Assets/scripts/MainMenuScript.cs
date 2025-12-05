using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEditor.SearchService;
using NUnit.Framework.Internal.Execution;
using System.Collections;
using TMPro;
using Unity.VisualScripting;


public class MainMenuScript : MonoBehaviour
{
  public static MainMenuScript instance;
    [SerializeField] Canvas canvasGUI;
    [SerializeField] GameObject playButtonGO;
    Vector3 originalPosMMF;
    Vector3 originalPosXPBar;
    Vector3 originalPosPB;
    Scale originalSizeBTM;
    Vector3 originalBackButton;
    Color oldBGColor;
    bool hasStoredOriginalPositions = false;
    int expGained = 10;
    WaitForSeconds frequnceyOfChange = new WaitForSeconds(0.08f);
    void Awake()
    {
        Time.timeScale = 1f;
         Debug.Log(gameObject.name + ":" + gameObject.GetInstanceID());
        if (instance != null && instance != this) {  
            Destroy(gameObject);
            StopAllCoroutines();
            return;
          
        }
        events.levelUp.AddListener(levelUPED);
        instance = this;
        events.buttonEvent.AddListener(playButton);
        Debug.Log(events.buttonEvent.GetAwaiter());
    }
    private void OnDisable()
    {
        events.buttonEvent.RemoveListener(playButton);
        Destroy(gameObject);
    }
    void Start()
    {
        StartCoroutine(SetupUI());
    }
    IEnumerator SetupUI()
    {

        yield return new WaitForNextFrameUnit() ;
        Canvas.ForceUpdateCanvases();
        GameObject playBuTToNGo = Instantiate(playButtonGO, new Vector3(960, 540, 0), Quaternion.identity);
        playBuTToNGo.transform.parent = FindAnyObjectByType<Canvas>().transform;
    }
    public void clickclick() {
        Debug.Log("HI");
        events.buttonEvent.Invoke(1);
    }

    //yea I know this could be done with an loop and list saving the position
    public void playButton(int buh)
    {

        GameObject barrenLandGUI = canvasGUI.transform.Find("BarrenTreesMapGUI").gameObject;
        GameObject monkeyMoneyFrame = canvasGUI.transform.Find("MoneyFrame").gameObject;
        GameObject xpBar = canvasGUI.transform.Find("xpBar").gameObject;
        GameObject playButton = canvasGUI.transform.Find("PlayButton(Clone)").gameObject;
        Debug.Log(playButton.transform.position);
        GameObject bgColor = canvasGUI.transform.Find("BackGround").gameObject;
        UnityEngine.UI.Image bgColorImage = bgColor.GetComponent<UnityEngine.UI.Image>();
        GameObject backButton = canvasGUI.transform.Find("BackButton").gameObject;
        RectTransform playButtonRect = playButton.GetComponent<RectTransform>();

        //originalPosXPBar = xpBar.transform.position;
        //originalSizeBTM = barrenLandGUI.transform.localScale;
        //originalPosMMF = monkeyMoneyFrame.transform.position;
        //originalPosPB = playButton.transform.position;
        //originalBackButton = backButton.transform.position;
        //oldBGColor = bgColor.GetComponent<UnityEngine.UI.Image>().color;

        if (!hasStoredOriginalPositions)
        {
            originalPosXPBar = xpBar.transform.position;
            originalSizeBTM = barrenLandGUI.transform.localScale;
            originalPosMMF = monkeyMoneyFrame.transform.position;
            originalPosPB = playButton.transform.position;
            originalBackButton = backButton.transform.position;
            oldBGColor = bgColor.GetComponent<UnityEngine.UI.Image>().color;
            hasStoredOriginalPositions = true;
        }

        LeanTween.cancel(monkeyMoneyFrame);
        LeanTween.cancel(xpBar);
        LeanTween.cancel(playButton);
        LeanTween.cancel(backButton);
        //monkeyMoneyFrame.GetComponent<RectTransform>().anchoredPosition = originalPosXPBar;
        //nevermind stupidleantween problem
        monkeyMoneyFrame.LeanMove(new Vector3(monkeyMoneyFrame.transform.position.x, 5000, monkeyMoneyFrame.transform.position.z), 0.5f);
        xpBar.LeanMove(new Vector3(xpBar.transform.position.x, 5000, xpBar.transform.position.z), 0.5f);
        playButton.LeanMove(new Vector3(playButton.transform.position.x, -5000, playButton.transform.position.z), 0.5f);
        StartCoroutine(tweenPoistion(playButton, playButton.transform.position, new Vector3(playButton.transform.position.x, -1000, playButton.transform.position.z), 0.05f));
        // LeanTween.moveLocal(playButton, new Vector3(playButtonRect.anchoredPosition.x, -5000, 0), 0.5f);

        backButton.LeanMove(new Vector3(backButton.transform.position.x, 100, backButton.transform.position.z), 0.5f);
        LeanTween.scale(barrenLandGUI.GetComponent<RectTransform>(), new Vector3(1, 1, 1), 0.2f);
        LeanTween.color(bgColorImage.rectTransform, new Color(0.25f, 0.22f, 0.16f), 0.5f);
        //bgColor.GetComponent<UnityEngine.UI.Image>().color = new Color(0.25f, 0.22f, 0.16f);

        bgColor.LeanColor(new Color(0.25f, 0.22f, 0.16f), 1f);
        Debug.Log("Active tweens: " + LeanTween.maxSearch);
        Debug.Log("Tweens in use: " + LeanTween.tweensRunning);
    }
    IEnumerator tweenPoistion(GameObject gameObjectToTween,Vector3 originPosition, Vector3 targetPosition, float tweenTime) {
        //like object pooling(gameObject pooling) but with "object" or classes
        //yes this isn't AI I known this optimization strat for a bit of time along with Object pooling
        Debug.Log("1:"+"HI");
        Debug.Log("2:"+gameObjectToTween);
        Debug.Log("3:"+originPosition);
        Debug.Log("4:"+targetPosition);
        Debug.Log(tweenTime);
        float time = 0;
        WaitForSeconds waitTime = new WaitForSeconds(0.08f);
        Debug.Log("wheres the bug");
        //for (; time <= tweenTime; time += Time.deltaTime) {
        //    Debug.Log("5:"+"DUHH");
        //    //broken loop??
        //    Debug.Log(frequnceyOfChange);

        //    Debug.Log("WHY NO CHANGE");
        //    Debug.Log("6:"+gameObjectToTween.transform.position);
        //    Vector3 currentPosition = Vector3.Lerp(originPosition, targetPosition, time/tweenTime);
        //    Debug.Log("7:"+currentPosition);
        //    gameObjectToTween.transform.position=currentPosition;
        //    Debug.Log("8:" + time);
        //    Debug.Log("9:" + tweenTime);
        //    //inf yield??
        //    Debug.Log(frequnceyOfChange);

        //    yield return null; 
        //    Debug.Log("10:"+time);
        //    Debug.Log("11:"+tweenTime);
        //}
        while (time < tweenTime) {
            Debug.Log("10:" + time);
            Debug.Log("10.5:" + Time.unscaledDeltaTime);
            Debug.Log("10.5:" + Time.deltaTime);
            Debug.Log("11:" + tweenTime);
            Vector3 currentPosition = Vector3.Lerp(originPosition, targetPosition, time / tweenTime);
            gameObjectToTween.transform.position = currentPosition;
            yield return null;
            time += Time.unscaledDeltaTime;

        }


    }

    public void backButtonClick()
    {
        Debug.Log("BACKBUTTON");
        Canvas canvasGUI = FindFirstObjectByType<Canvas>();
        GameObject monkeyMoneyFrame = canvasGUI.transform.Find("MoneyFrame").gameObject;
        GameObject playButton = canvasGUI.transform.Find("PlayButton(Clone)").gameObject;
        GameObject xpBar = canvasGUI.transform.Find("xpBar").gameObject;
        GameObject bgColor = canvasGUI.transform.Find("BackGround").gameObject;
        GameObject backButton = canvasGUI.transform.Find("BackButton").gameObject;
        GameObject barrenLandGUI = canvasGUI.transform.Find("BarrenTreesMapGUI").gameObject;
        UnityEngine.UI.Image bgColorImage = bgColor.GetComponent<UnityEngine.UI.Image>();
        monkeyMoneyFrame.LeanMove(originalPosMMF, 0.5f);
        playButton.LeanMove(originalPosPB, 0.5f);
        LeanTween.color(bgColorImage.rectTransform, oldBGColor, 0.5f);
        LeanTween.scale(barrenLandGUI.GetComponent<RectTransform>(),new Vector3(0,0,0), 0.2f);
        backButton.LeanMove(originalBackButton, 0.5f);
    }

    public void BarrenTreesMapSelected()
    {
        StartCoroutine(LoadMap("BarrenTreeMap"));
    }

    IEnumerator LoadMap(string mapName)
    {
        LeanTween.cancelAll();
        AsyncOperation load = SceneManager.LoadSceneAsync(mapName, LoadSceneMode.Additive);
        yield return load;
        SceneManager.UnloadSceneAsync("MainMenu");
    }
    //public void barrenTreesMapSelected() {
    //    LeanTween.cancelAll();
    //    SceneManager.LoadSceneAsync("BarrenTreeMap");
    //    SceneManager.UnloadSceneAsync("MainMenu");

    //}
    public void InvisibleTrailsMapSelected()
    {
        LeanTween.cancelAll();
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadSceneAsync("InvisibleTrails");
       

    }
    public void InfernoPlainsMapSelected()
    {
        LeanTween.cancelAll();
        SceneManager.LoadSceneAsync("InfernoPlains");
        SceneManager.UnloadSceneAsync("MainMenu");

    }
    public void plusMonkeyMoneyButton() {
     events.addMM.Invoke(1+(expGained/2));
     events.gainExp.Invoke(10);
    
    }

    void levelUPED(int level) {
        expGained += (10 + (level / 3));    
    }
}
