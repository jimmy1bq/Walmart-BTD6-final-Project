using UnityEngine;


public class towersParent : MonoBehaviour 
{
    [SerializeField] GameObject rangeCricle;
    

    
    protected Vector3 placeTowerRangeCircle(GameObject tower)
    {
        Vector3 rangePos = new Vector3(tower.transform.position.x, tower.transform.position.y, tower.transform.position.z) + new Vector3(0, 0.01f, 0);
        return rangePos;
    }
    //doubley circular linked list 

    void closestTargetting() { }
    void firstTargetting() { }
    void lastTargettign() { }
    void strongestTargettign() { }
    void weakestTargettign() { }



}
