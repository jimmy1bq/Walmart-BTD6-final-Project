using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI cashText;
    [SerializeField] Canvas canvasGUI;
    bool pasued;
    string pathToGUIs = "Assets/Resources/MiscellaniousGUI/";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        events.LoseLives.AddListener(loseLife);
        events.GainCash.AddListener(gainCoins);
       
            loseLife(0);
          
        gainCoins(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void loseLife(int damage) {
        if (GameObject.Find("Base") == null)
        {
            
            livesText.text = (GameManager.instance.hp).ToString();
        }
    }
    void gainCoins(int Cash)
    {
     
        cashText.text = (GameManager.instance.coins).ToString();
    }
    //so previously I had a bug where CanvasGUi was null and the problem might of been that button onClick event was calling the prefab because the script was attached to the prefab
    public void StartWaveEvent() {
        bool buh = WaveManager.waveDelegate.Invoke();
        if (buh)
        {
            pasued = GameOverOrWinScript.instance.pasued;
            GameObject startWaveButtonThing = canvasGUI.transform.Find("WaveStartButton(Clone)").gameObject;
            GameObject speedUpButton = Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(pathToGUIs + "speedUpButton" + ".prefab"), startWaveButtonThing.transform.position, Quaternion.identity);
            speedUpButton.transform.parent = canvasGUI.transform;
            Destroy(startWaveButtonThing);   
        }
    }
 
    public void speedUp() {
        pasued = GameOverOrWinScript.instance.pasued;
        if (pasued) { return; }
        Time.timeScale =5.0f;
        canvasGUI = FindFirstObjectByType<Canvas>();
        GameObject speedWaveButtonThing = canvasGUI.transform.Find("speedUpButton(Clone)").gameObject;
        GameObject speedUpButton = Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(pathToGUIs + "speedDownButton" + ".prefab"), speedWaveButtonThing.transform.position, Quaternion.identity);
        speedUpButton.transform.parent = canvasGUI.transform;
        Destroy(speedWaveButtonThing);
    }
    public void speedDown() {
        pasued = GameOverOrWinScript.instance.pasued;
        if (pasued) { return; }
        Time.timeScale = 1f;
        GameObject slowWaveButtonThing = canvasGUI.transform.Find("speedDownButton(Clone)").gameObject;
        GameObject speedUpButton = Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(pathToGUIs + "speedUpButton" + ".prefab"), slowWaveButtonThing.transform.position, Quaternion.identity);
        speedUpButton.transform.parent = canvasGUI.transform;
        Destroy(slowWaveButtonThing);
    }


}
