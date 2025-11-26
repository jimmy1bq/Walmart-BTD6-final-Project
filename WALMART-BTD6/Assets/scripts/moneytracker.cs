using UnityEditor.SearchService;
using UnityEngine;

public class moneytracker : MonoBehaviour
{
    public static moneytracker instance;
    public int monkeyMoney = 0;
    private void Awake()
    {
        instance = this;
        events.addMM.AddListener(addMonkeyMoney);
        Object.DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        events.onLoad.Invoke(monkeyMoney);
    }

    void addMonkeyMoney(int money) { 
        monkeyMoney+=money;
        events.onLoad.Invoke(monkeyMoney);
    }
}
