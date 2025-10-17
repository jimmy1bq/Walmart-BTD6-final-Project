using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class LivesLossEvent : MonoBehaviour
{
    public UnityEvent onLivesLoss;
    public static LivesLossEvent instance;
    [SerializeField] GameObject UIManager;
    void Awake()
    {
        events.LoseLives.AddListener(loseLife);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

    public void loseLife(int damage) {
        
    }
   
}
