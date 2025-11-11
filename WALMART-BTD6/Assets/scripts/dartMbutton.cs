using UnityEngine;

public class towerButtons : MonoBehaviour
{
    [SerializeField] GameObject DartMonkePrefab;

    [SerializeField] bool testBool1;
    public void selected() { 
        events.GainCash.Invoke(-200);
        events.towerSelected.Invoke(DartMonkePrefab);
    }
}
