using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        events.LoseLives.AddListener(loseLife);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void loseLife(int damage) {

        livesText.text =(int.Parse(livesText.text) - damage).ToString();
    }
}
