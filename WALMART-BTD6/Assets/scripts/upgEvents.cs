using UnityEngine;

public class dMUpgradeEvents : MonoBehaviour
{
    //this script is soley to invoke the upgrade events
    //this scirpt can use a dicionatary<string,dictionary<int,int>>
    //where string is with path like "top" "mid" or "bot"

    GameManager gameManager;
    
    private void Awake()
    {
        gameManager = GameManager.instance;
    }
    //yes before you say anything i could put the if statments and possibly each event into one statment but this is the easiest solution
    public void upgrade100() {

        if (gameManager.coins >= 170) {
            events.GainCash.Invoke(-170);
            events.towerUpgrade.Invoke("top");

        }
      
    }
    public void upgrade010()
    {
        if (gameManager.coins >= 120) {
            events.GainCash.Invoke(-110);
            events.towerUpgrade.Invoke("mid");
        }
    }

    public void upgrade001()
    {
        if (gameManager.coins >= 110)
        {
            events.GainCash.Invoke(-110);
            events.towerUpgrade.Invoke("mid");
        }
    }
    public void upgrade200()
    {
        if (gameManager.coins >= 200)
        {
            events.GainCash.Invoke(-200);
            events.towerUpgrade.Invoke("top");
        }
    }
    public void upgrade020()
    {
        if (gameManager.coins >= 190)
        {
            events.GainCash.Invoke(-190);
            events.towerUpgrade.Invoke("mid");
        }
    }
    public void upgrade002()
    {
        if (gameManager.coins >= 150)
        {
            events.GainCash.Invoke(-150);
            events.towerUpgrade.Invoke("bot");
        }
    }
    public void upgrade003()
    {
        if (gameManager.coins >= 650)
        {
            events.GainCash.Invoke(-650);
            events.towerUpgrade.Invoke("bot");
        }
    }
     public void upgrade030()
    {
        if (gameManager.coins >= 250)
        {
            events.GainCash.Invoke(-250);
            events.towerUpgrade.Invoke("bot");
        }
    }
    public void upgrade300()
    {
        if (gameManager.coins >= 300)
        {
            events.GainCash.Invoke(-300);
            events.towerUpgrade.Invoke("bot");
        }
    }

}
