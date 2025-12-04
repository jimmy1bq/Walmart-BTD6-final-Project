using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moneytracker : MonoBehaviour
{
    public static moneytracker instance;
    public int monkeyMoney = 0;
    private void Awake()
    {
        if (instance == null) { instance = this; Object.DontDestroyOnLoad(this.gameObject); }
        events.addMM.AddListener(addMonkeyMoney);
     
    }
    void Start()
    {
        events.onLoad.Invoke(monkeyMoney);
    }

    public void addMonkeyMoney(int money) { 
        monkeyMoney+=money;
        UnityEngine.SceneManagement.Scene curScene = SceneManager.GetActiveScene();
        int currentSceneIndex = curScene.buildIndex;
        if (currentSceneIndex==1) {
            FindFirstObjectByType<Canvas>().transform.Find("MoneyFrame").Find("Money").gameObject.GetComponent<TextMeshProUGUI>().text = monkeyMoney.ToString();
        }
    }
    public void upDateMonkeyMoneyGUI() {
        events.onLoad.Invoke(monkeyMoney);
    }
}
