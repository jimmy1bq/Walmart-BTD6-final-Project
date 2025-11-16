using UnityEngine;

public class towerButtons : MonoBehaviour
{
    [SerializeField] GameObject DartMonkePrefab;

    [SerializeField] bool testBool1;
    public void selected() {
        if (GameManager.instance.coins >= 200)
        {
            events.GainCash.Invoke(-200);
            events.towerSelected.Invoke(DartMonkePrefab);
        }
    }
}
