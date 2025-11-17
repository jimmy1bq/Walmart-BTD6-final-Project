using System.Collections.Generic;
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
    //Range+%
    //Firerate+%
    //projctilespeed+%
    //Damage+num
    //pierce+num
      //{"Range", 5},
      //    { "FireRate",2},
      //    { "ProjctileSpeed",1},
      //    { "AddtionalDamage",0},
      //    { "pierce",0},
      //    { "popCount",0}
    public void upgrade100() {
       
        if (GameManager.instance.coins >= 170) {
            
            Dictionary<string,float> stats = new Dictionary<string,float> {
                //everything is going to be mutiply by %
                    {"Range", 1},
                    { "FireRate",1},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",2},
               
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
            Dictionary<string,float> stats = new Dictionary<string,float> {
                    {"Range", 1},
                    { "FireRate",0.8f},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1}
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
            Dictionary<string,float> stats = new Dictionary<string,float> {
                    {"Range", 1.25f},
                    { "FireRate",1},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},
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
            Dictionary<string,float> stats = new Dictionary<string,float> {
                    {"Range", 1},
                    { "FireRate",1},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",2},
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
            Dictionary<string,float> stats = new Dictionary<string,float> {
                    {"Range", 1},
                    { "FireRate",0.83f},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},
             
            };
            events.GainCash.Invoke(-190);
            events.towerUpgrade.Invoke("mid", "", stats);
        }
    }
    public void upgrade002()
    {
        //later add camo detc 
        if (GameManager.instance.coins >= 150)
        {
            Debug.Log("hi");
            Dictionary<string,float> stats = new Dictionary<string,float> {
                    {"Range", 1.17f},
                    { "FireRate",0.83f},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},
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
            Dictionary<string,float> stats = new Dictionary<string,float> {
                    {"Range", 1.12f},
                    { "FireRate",1},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},
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
            Dictionary<string,float> stats = new Dictionary<string,float> {
                    {"Range", 1},
                    { "FireRate",0.66f},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},
            };
            events.GainCash.Invoke(-250);
            events.towerUpgrade.Invoke("mid", "", stats);
        }
    }
    public void upgrade300()
    {
        if (GameManager.instance.coins >= 300)
        {
            Dictionary<string,float> stats = new Dictionary<string,float> {
                    {"Range", 1.15f},
                    { "FireRate",1.83f},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},
            };
            events.GainCash.Invoke(-300);
            events.towerUpgrade.Invoke("top", "cannonball", stats);
        }
    }

}
