using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI cashText;
    [SerializeField] Canvas canvasGUI;

    string pathToGUIs = "Assets/Resources/MiscellaniousGUI/";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        events.LoseLives.AddListener(loseLife);
        events.GainCash.AddListener(gainCoins);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void loseLife(int damage) {
        livesText.text =(GameManager.instance.hp - damage).ToString();
    }
    void gainCoins(int Cash)
    {
        cashText.text = (GameManager.instance.coins - Cash).ToString();
    }

    public void StartWaveEvent() {
        bool buh = WaveManager.waveDelegate.Invoke();
        if (buh)
        {
            GameObject startWaveButtonThing = canvasGUI.transform.Find("WaveStartButton(Clone)").gameObject;
            GameObject speedUpButton = Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(pathToGUIs + "speedUpButton" + ".prefab"), startWaveButtonThing.transform.position, Quaternion.identity);
            speedUpButton.transform.parent = canvasGUI.transform;
            Destroy(startWaveButtonThing);   
        }
    }
 
    public void speedUp() {
        Time.timeScale = 2.0f;
        canvasGUI = FindFirstObjectByType<Canvas>();
        GameObject speedWaveButtonThing = canvasGUI.transform.Find("speedUpButton(Clone)").gameObject;
        GameObject speedUpButton = Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(pathToGUIs + "speedDownButton" + ".prefab"), speedWaveButtonThing.transform.position, Quaternion.identity);
        speedUpButton.transform.parent = canvasGUI.transform;
        Destroy(speedWaveButtonThing);
    }
    public void speedDown() {
        Time.timeScale = 0.5f;
        GameObject slowWaveButtonThing = canvasGUI.transform.Find("speedDownButton(Clone)").gameObject;
        GameObject speedUpButton = Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(pathToGUIs + "speedUpButton" + ".prefab"), slowWaveButtonThing.transform.position, Quaternion.identity);
        speedUpButton.transform.parent = canvasGUI.transform;
        Destroy(slowWaveButtonThing);
    }


}
