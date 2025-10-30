using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TowersSO")]
public class TowersSO : ScriptableObject {
    //put in tower stuff like targetting and make it refernce other boxSO
    public GameObject selectedTower;
    public GameObject tower1;
    
    public int towerID = 0;

    
    //delte this SO later
    public bool rangeCheck(float distance,float range)
    {
        if (distance <= range) {
            return true;
        }
        return false;
    }
}
  

