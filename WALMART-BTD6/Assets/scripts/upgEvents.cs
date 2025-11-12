using UnityEngine;

public class dMUpgradeEvents : MonoBehaviour
{
    //this script is soley to invoke the upgrade events
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

}
