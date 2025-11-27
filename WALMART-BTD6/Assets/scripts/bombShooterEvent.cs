using System.Collections.Generic;
using UnityEngine;

public class bombShooterEvent : MonoBehaviour
{
    public void upgrade100()
    {

        if (GameManager.instance.coins >= 210)
        {
            Dictionary<string, float> stats = new Dictionary<string, float> {
                //everything is going to be mutiply by %
                    {"Range", 1.1f},
                    { "FireRate",1},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},

            };
            events.GainCash.Invoke(-210);
            events.towerUpgrade.Invoke("top", "bigBomb", stats, false);

        }

    }
    public void upgrade010()
    {
        if (GameManager.instance.coins >= 220)
        {
            Dictionary<string, float> stats = new Dictionary<string, float> {
                    {"Range", 1},
                    { "FireRate",0.8f},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1}
            };
            events.GainCash.Invoke(-220);
            events.towerUpgrade.Invoke("mid", "", stats, false);
        }
    }

    public void upgrade001()
    {
        if (GameManager.instance.coins >= 110)
        {
            Dictionary<string, float> stats = new Dictionary<string, float> {
                    {"Range", 1.25f},
                    { "FireRate",1},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},
            };
            events.GainCash.Invoke(-110);
            events.towerUpgrade.Invoke("bot", "", stats, false);
        }
    }
    public void upgrade200()
    {
        if (GameManager.instance.coins >= 220)
        {
            Dictionary<string, float> stats = new Dictionary<string, float> {
                    {"Range", 1.1f},
                    { "FireRate",1.05f},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",2},
            };
            events.GainCash.Invoke(-220);
            events.towerUpgrade.Invoke("top", "heavybomb", stats, false);
        }
    }
    public void upgrade020()
    {

        if (GameManager.instance.coins >= 10)
        {
            Dictionary<string, float> stats = new Dictionary<string, float> {
                    {"Range", 1},
                    { "FireRate",0.83f},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},

            };
            events.GainCash.Invoke(-190);
            events.towerUpgrade.Invoke("mid", "", stats, false);
        }
    }
    public void upgrade002()
    {
        //later add camo detc 
        if (GameManager.instance.coins >= 150)
        {

            Dictionary<string, float> stats = new Dictionary<string, float> {
                    {"Range", 1.17f},
                    { "FireRate",0.83f},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},
            };
            events.GainCash.Invoke(-150);
            events.towerUpgrade.Invoke("bot", "", stats, true);
        }
    }
    public void upgrade003()
    {

        if (GameManager.instance.coins >= 650)
        {

            Dictionary<string, float> stats = new Dictionary<string, float> {
                    {"Range", 1.12f},
                    { "FireRate",1},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},
            };
            events.GainCash.Invoke(-650);
            events.towerUpgrade.Invoke("bot", "arrowProj", stats, false);
        }
    }
    public void upgrade030()
    {
        if (GameManager.instance.coins >= 250)
        {

            Dictionary<string, float> stats = new Dictionary<string, float> {
                    {"Range", 1},
                    { "FireRate",0.66f},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},
            };
            events.GainCash.Invoke(-250);
            events.towerUpgrade.Invoke("mid", "tripleDartProjectile", stats, false);
        }
    }
    public void upgrade300()
    {
        if (GameManager.instance.coins >= 300)
        {
            Dictionary<string, float> stats = new Dictionary<string, float> {
                    {"Range", 1f},
                    { "FireRate",1f},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},
            };
            events.GainCash.Invoke(-300);
            events.towerUpgrade.Invoke("top", "biggerbomb", stats, true);
        }
    }

    public void upgrade400()
    {
        if (GameManager.instance.coins >= 2380)
        {
            Dictionary<string, float> stats = new Dictionary<string, float> {
                    {"Range", 1f},
                    { "FireRate",1.1f},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},
            };
            events.GainCash.Invoke(-2380);
            events.towerUpgrade.Invoke("top", "impactProj", stats, false);
        }
    }
    public void upgrade040()
    {
        if (GameManager.instance.coins >= 7385)
        {
            Dictionary<string, float> stats = new Dictionary<string, float> {
                    {"Range", 1f},
                    { "FireRate",0.83f},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},
            };
            events.GainCash.Invoke(-7385);
            events.towerUpgrade.Invoke("mid", "", stats, false);
        }
    }
    public void upgrade004()
    {
        if (GameManager.instance.coins >= 2750)
        {
            Dictionary<string, float> stats = new Dictionary<string, float> {
                    {"Range", 1.1f},
                    { "FireRate",0.83f},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},
            };
            events.GainCash.Invoke(-2750);
            events.towerUpgrade.Invoke("bot", "upgradedBolt", stats, true);

        }
    }
    public void upgrade500()
    {
        if (GameManager.instance.coins >= 46750)
        {
            Dictionary<string, float> stats = new Dictionary<string, float> {
                    {"Range", 1f},
                    { "FireRate",1.1f},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},
            };
            events.GainCash.Invoke(-46750);
            events.towerUpgrade.Invoke("top", "crushProj", stats, false);
        }
    }
    public void upgrade050()
    {
        if (GameManager.instance.coins >= 46000)
        {
            Dictionary<string, float> stats = new Dictionary<string, float> {
                    {"Range", 1f},
                    { "FireRate",.73f},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},
            };
            events.GainCash.Invoke(-46000);
            events.towerUpgrade.Invoke("mid", "", stats, false);
        }
    }
    public void upgrade005()
    {
        if (GameManager.instance.coins >= 22060)
        {
            Dictionary<string, float> stats = new Dictionary<string, float> {
                    {"Range", 1.3f},
                    { "FireRate",.125f},
                    { "ProjctileSpeed",1},
                    { "AddtionalDamage",1},
                    { "pierce",1},
            };
            events.GainCash.Invoke(-22060);
            events.towerUpgrade.Invoke("bot", "strongestBolt", stats, true);
        }
    }
}
