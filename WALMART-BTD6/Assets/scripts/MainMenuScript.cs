using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenuScript : MonoBehaviour
{
  public static MainMenuScript instance;
    Vector3 originalPosMMF;
    Vector3 originalPosXPBar;
    Vector3 originalPosPB;
    Scale originalSizeBTM;
    Vector3 originalBackButton;
    Color oldBGColor;

    int expGained = 10;
    void Awake()
    {
        events.levelUp.AddListener(levelUPED);
        instance = this;
    }
    //yea I know this could be done with an loop and list saving the position
    public void playButton() {
        Canvas canvasGUI = FindFirstObjectByType<Canvas>();
        GameObject barrenLandGUI = canvasGUI.transform.Find("BarrenTreesMapGUI").gameObject;
        GameObject monkeyMoneyFrame = canvasGUI.transform.Find("MoneyFrame").gameObject;
        GameObject xpBar = canvasGUI.transform.Find("xpBar").gameObject;
        GameObject playButton = canvasGUI.transform.Find("PlayButton").gameObject;
        GameObject bgColor = canvasGUI.transform.Find("BackGround").gameObject;
        UnityEngine.UI.Image bgColorImage = bgColor.GetComponent<UnityEngine.UI.Image>();
        GameObject backButton = canvasGUI.transform.Find("BackButton").gameObject;
        originalPosXPBar = xpBar.transform.position;
        originalSizeBTM = barrenLandGUI.transform.localScale;
        originalPosMMF = monkeyMoneyFrame.transform.position;
        originalPosPB = playButton.transform.position;
        originalBackButton = backButton.transform.position;
        oldBGColor = bgColor.GetComponent<UnityEngine.UI.Image>().color;
        monkeyMoneyFrame.LeanMove(new Vector3(monkeyMoneyFrame.transform.position.x, 5000, monkeyMoneyFrame.transform.position.z), 0.5f);
        xpBar.LeanMove(new Vector3(xpBar.transform.position.x, 5000, xpBar.transform.position.z), 0.5f);
        playButton.LeanMove(new Vector3(playButton.transform.position.x,  -5000, playButton.transform.position.z), 0.5f);
        backButton.LeanMove(new Vector3(backButton.transform.position.x, 100, backButton.transform.position.z), 0.5f);
        LeanTween.scale(barrenLandGUI.GetComponent<RectTransform>(), new Vector3(1,1,1), 0.2f);
        LeanTween.color(bgColorImage.rectTransform, new Color(0.25f, 0.22f, 0.16f), 0.5f);
        // bgColor.GetComponent<Image>().color = new Color(0.25f, 0.22f, 0.16f);

        //bgColor.LeanColor(new Color(0.25f, 0.22f, 0.16f), 1f);



    }

    public void backButtonClick()
    {
        Canvas canvasGUI = FindFirstObjectByType<Canvas>();
        GameObject monkeyMoneyFrame = canvasGUI.transform.Find("MoneyFrame").gameObject;
        GameObject playButton = canvasGUI.transform.Find("PlayButton").gameObject;
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
    public void barrenTreesMapSelected() {
        SceneManager.LoadSceneAsync("BarrenTreeMap");
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
