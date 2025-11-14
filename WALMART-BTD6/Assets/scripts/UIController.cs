using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI cashText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
}
