using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEditor.SearchService;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI cashText;
    [SerializeField] Canvas canvasGUI;

    string pathToGUIs = "Assets/Resources/MiscellaniousGUI/";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        livesText.text = (GameManager.instance.hp).ToString();
        cashText.text = (GameManager.instance.coins).ToString();
    }
    void Start()
    {

        events.LoseLivesUI.AddListener(loseLife);
        events.GainCashUI.AddListener(gainCoins);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void loseLife(int damage) {
        livesText.text =(damage).ToString();
    }
    void gainCoins(int Cash)
    {
        cashText.text = (Cash).ToString();
    }
    public void StartWaveEvent() {
        bool buh = WaveManager.waveDelegate.Invoke();
        if (buh)
        {
            GameObject startWaveButtonThing = canvasGUI.transform.Find("WaveStartButton").gameObject;
            GameObject speedUpButton = Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(pathToGUIs + "speedUpButton" + ".prefab"), startWaveButtonThing.transform.position, Quaternion.identity);
            speedUpButton.transform.parent = canvasGUI.transform;
            Destroy(startWaveButtonThing);
            Debug.Log(canvasGUI);
        }
    }
 
    public void speedUp() {
    Time.timeScale = 2.0f;
        Debug.Log(canvasGUI);
        GameObject startWaveButtonThing = canvasGUI.transform.Find("speedUpButton").gameObject;
        Debug.Log(startWaveButtonThing);
        GameObject speedUpButton = Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(pathToGUIs + "speedDownButton" + ".prefab"), startWaveButtonThing.transform.position, Quaternion.identity);
        Debug.Log(speedUpButton);
        speedUpButton.transform.parent = canvasGUI.transform;
        Destroy(startWaveButtonThing);
    }
    public void speedDown() {
    Time.timeScale = 0.5f;
        GameObject startWaveButtonThing = canvasGUI.transform.Find("speedDownButton").gameObject;
        GameObject speedUpButton = Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(pathToGUIs + "speedUpButton" + ".prefab"), startWaveButtonThing.transform.position, Quaternion.identity);
        speedUpButton.transform.parent = canvasGUI.transform;
        Destroy(startWaveButtonThing);
    }

}
