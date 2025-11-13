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
        Debug.Log("hi1");
        if (gameManager.coins >= 170) {
            Debug.Log("hi");
            events.GainCash.Invoke(-170);
            events.towerUpgrade.Invoke("top");

        }
      
    }
    public void upgrade010()
    {
        Debug.Log("hi1");
        if (gameManager.coins >= 120) {
            Debug.Log("hi");
            events.GainCash.Invoke(-110);
            events.towerUpgrade.Invoke("mid");
        }
    }

    public void upgrade001()
    {
        Debug.Log("hi1");
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
            Debug.Log("hi");
            events.GainCash.Invoke(-200);
            events.towerUpgrade.Invoke("top");
        }
    }
    public void upgrade020()
    {
        Debug.Log("hi1");
        if (gameManager.coins >= 190)
        {
            events.GainCash.Invoke(-190);
            events.towerUpgrade.Invoke("mid");
        }
    }
    public void upgrade002()
    {
        Debug.Log("hi1");
        if (gameManager.coins >= 150)
        {
            Debug.Log("hi");
            events.GainCash.Invoke(-150);
            events.towerUpgrade.Invoke("bot");
        }
    }
    public void upgrade003()
    {
        Debug.Log("hi1");
        if (gameManager.coins >= 650)
        {
            Debug.Log("hi");
            events.GainCash.Invoke(-650);
            events.towerUpgrade.Invoke("bot");
        }
    }
     public void upgrade030()
    {
        Debug.Log("hi1");
        if (gameManager.coins >= 250)
        {
            Debug.Log("hi");
            events.GainCash.Invoke(-250);
            events.towerUpgrade.Invoke("bot");
        }
    }
    public void upgrade300()
    {
        Debug.Log("hi1");
        if (gameManager.coins >= 300)
        {
            Debug.Log("hi");
            events.GainCash.Invoke(-300);
            events.towerUpgrade.Invoke("bot");
        }
    }

}
