using UnityEngine;

public class dartMbutton : MonoBehaviour
{
    [SerializeField] GameObject DartMonkePrefab;

    [SerializeField] bool testBool1;
    public void selected() { 
        events.GainCash.Invoke(-200);
        events.towerSelected.Invoke(DartMonkePrefab);
       
    }
}
