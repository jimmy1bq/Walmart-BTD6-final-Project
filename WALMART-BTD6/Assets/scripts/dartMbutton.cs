using UnityEngine;

public class towerButtons : MonoBehaviour
{
    [SerializeField] GameObject DartMonkePrefab;
    [SerializeField] GameObject cannonTowerPrefab;

    [SerializeField] bool testBool1;
    public void selected() {
        if (GameManager.instance.coins >= 200)
        {
            events.towerSelected.Invoke(DartMonkePrefab);
        }
    }
    public void selected2()
    {
        if (GameManager.instance.coins >= 300)
        {
            events.towerSelected.Invoke(cannonTowerPrefab);
        }
    }
}
