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
        livesText.text = (GameManager.instance.coins - Cash).ToString();
    }
}
