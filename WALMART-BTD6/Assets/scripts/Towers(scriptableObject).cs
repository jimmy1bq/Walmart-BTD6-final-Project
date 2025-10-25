using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TowersSO")]
public class TowersSO : ScriptableObject {
    //put in tower stuff like targetting and make it refernce other boxSO
    public GameObject selectedTower;
    public GameObject rangeCricle;
    public GameObject tower1;
    
    public int towerID = 0;

    private void Awake()
    {
        Debug.Log("hi");
        Debug.Log(tower1);
    }
    public Vector3 placeTowerRangeCircle(GameObject tower) {
        Vector3 rangePos =new Vector3(tower.transform.position.x, tower.transform.position.y, tower.transform.position.z) + new Vector3(0, 0.01f, 0);

        return rangePos;
    }
    public bool rangeCheck(float distance,float range)
    {
        if (distance <= range) {
            return true;
        }
        return false;
    }
}
  

