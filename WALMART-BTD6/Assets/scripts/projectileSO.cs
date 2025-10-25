using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "projectileSO")]
public class projectileSO : ScriptableObject
{
    public GameObject dartProjctile;
    //public int projectileID = 0;
    ////towerID, (key:tower,value:projectile)
    //public Dictionary<int,Dictionary<GameObject,GameObject>> projctileOnMap = new Dictionary<int,Dictionary<GameObject, GameObject>>();
    public enum additiveEffect {
        pierce, damage, fireDOT,frost

    }
    //hascode of projectile, their stats
    


    //apply effects here like extra pierce damage etc
    public void addStats(List effects) { 
    
    
    
    }
    

    private void OnDisable()
    {
        //projectileID = 0;
        //projctileOnMap.Clear();
    }

}
