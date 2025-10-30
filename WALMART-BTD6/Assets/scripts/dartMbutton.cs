using UnityEngine;

public class dartMbutton : MonoBehaviour
{
    [SerializeField] TowersSO towerData;

    [SerializeField] bool testBool1;
    public void selected() { 
        events.GainCash.Invoke(-200);
        events.towerSelected.Invoke(towerData.tower1);
        Debug.Log("false");
    }
}
