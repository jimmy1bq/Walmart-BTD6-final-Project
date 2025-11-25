using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
  public static MainMenuScript instance;
    Vector3 originalPosMMF;
    Vector3 originalPosPB;
    Color oldBGColor;
    void Awake()
    {
        instance = this;
    }
    public void playButton() {
        Canvas canvasGUI = FindFirstObjectByType<Canvas>();
        GameObject monkeyMoneyFrame = canvasGUI.transform.Find("MoneyFrame").gameObject;
        GameObject playButton = canvasGUI.transform.Find("PlayButton").gameObject;
        GameObject bgColor = canvasGUI.transform.Find("BackGround").gameObject;
        originalPosMMF = monkeyMoneyFrame.transform.position;
        originalPosPB = playButton.transform.position;
        oldBGColor = bgColor.GetComponent<UnityEngine.UI.Image>().color;
        monkeyMoneyFrame.LeanMove(new Vector3(monkeyMoneyFrame.transform.position.x, 5000, monkeyMoneyFrame.transform.position.z), 1f);
        playButton.LeanMove(new Vector3(playButton.transform.position.x,  -5000, playButton.transform.position.z), 1f);
        bgColor.LeanColor(new Color(64, 56, 42), 1f);

    }

    public void backButton()
    {
        Canvas canvasGUI = FindFirstObjectByType<Canvas>();
        GameObject monkeyMoneyFrame = canvasGUI.transform.Find("MoneyFrame").gameObject;
        GameObject playButton = canvasGUI.transform.Find("PlayButton").gameObject;
        GameObject bgColor = canvasGUI.transform.Find("BackGround").gameObject;
        monkeyMoneyFrame.LeanMove(originalPosMMF, 1f);
        playButton.LeanMove(originalPosPB, 1f);
        bgColor.LeanColor(oldBGColor, 1f);
    }
    public void plusMonkeyMoneyButton() { }
}
