using UnityEngine;

public class GameManager : MonoBehaviour
{//yes I could just make this into a scriptable object too 
   public static GameManager instance;
   public  int hp;
   public  int coins;
   public  bool monkeyGUIActive= false;

   private void Awake()
    {
        instance = this;
        events.LoseLives.AddListener(loseLives);
        events.GainCash.AddListener(gainCoins);
        hp = 100;
        coins = 650;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void loseLives(int damage) { 
        hp -= damage;
    }
    void gainCoins(int cash)
    {
       coins += cash;
    }
}
