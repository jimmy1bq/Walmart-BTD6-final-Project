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
        events.GainCash.AddListener(loseLife);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void loseLife(int damage) {
        livesText.text =(int.Parse(livesText.text) - damage).ToString();
    }
    void gainCash(int Cash)
    {
        livesText.text = (int.Parse(cashText.text) - Cash).ToString();
    }
}
