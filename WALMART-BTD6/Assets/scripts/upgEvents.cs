using UnityEngine;

public class dMUpgradeEvents : MonoBehaviour
{
    //this script is soley to invoke the upgrade events
    //this scirpt can use a dicionatary<string,dictionary<int,int>>
    //where string is with path like "top" "mid" or "bot"

  
    
    private void Awake()
    {
       
   
    }
    //yes before you say anything i could put the if statments and possibly each event into one statment but this is the easiest solution
    //sats array
    //Range
    //Firerate
    //Damage
    //pierce
    public void upgrade100() {
       
        if (GameManager.instance.coins >= 170) {
            
            float[] stats = new float[] {
                0,0,0,1
            };
            Debug.Log("hi");
            events.GainCash.Invoke(-170);
            events.towerUpgrade.Invoke("top", "",stats);

        }
      
    }
    public void upgrade010()
    {       
        if (GameManager.instance.coins >= 120) {
            Debug.Log("hi");
            float[] stats = new float[] {
                0,0.5f,0,0
            };
            events.GainCash.Invoke(-110);
            events.towerUpgrade.Invoke("mid","",stats);
        }
    }

    public void upgrade001()
    {
        Debug.Log("hi1");
        if (GameManager.instance.coins >= 110)
        {
            float[] stats = new float[] {
                1,0,0,1
            };
            events.GainCash.Invoke(-110);
            events.towerUpgrade.Invoke("bot", "", stats);
        }
    }
    public void upgrade200()
    {
        if (GameManager.instance.coins >= 200)
        {
            Debug.Log("hi");
            float[] stats = new float[] {
                0,0,0,2
            };
            events.GainCash.Invoke(-200);
            events.towerUpgrade.Invoke("top", "", stats);
        }
    }
    public void upgrade020()
    {
        
        if (GameManager.instance.coins >= 190)
        {
            Debug.Log("hi");
            float[] stats = new float[] {
                0,0.5f,0,0
            };
            events.GainCash.Invoke(-190);
            events.towerUpgrade.Invoke("mid", "", stats);
        }
    }
    public void upgrade002()
    {
    
        if (GameManager.instance.coins >= 150)
        {
            Debug.Log("hi");
            float[] stats = new float[] {
                1,0.5f,0,1
            };
            events.GainCash.Invoke(-150);
            events.towerUpgrade.Invoke("bot", "", stats);
        }
    }
    public void upgrade003()
    {
       
        if (GameManager.instance.coins >= 650)
        {
            Debug.Log("hi");
            float[] stats = new float[] {
                2,0,0,5
            };
            events.GainCash.Invoke(-650);
            events.towerUpgrade.Invoke("bot", "", stats);
        }
    }
     public void upgrade030()
    {
        if (GameManager.instance.coins >= 250)
        {
            Debug.Log("hi");
            float[] stats = new float[] {
                0,0.5f,0,1
            };
            events.GainCash.Invoke(-250);
            events.towerUpgrade.Invoke("mid", "", stats);
        }
    }
    public void upgrade300()
    {
        if (GameManager.instance.coins >= 300)
        {
            float[] stats = new float[] {
                0,0.5f,0,1
            };
            events.GainCash.Invoke(-300);
            events.towerUpgrade.Invoke("top", "cannonball", stats);
        }
    }

}
