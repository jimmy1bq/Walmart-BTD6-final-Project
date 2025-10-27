using UnityEngine;

public class firstTowerButton : MonoBehaviour
{
    [SerializeField] TowersSO towerData;
    public void OnClick() { 
    events.GainCash.Invoke(-200);
    events.towerSelected.Invoke(towerData.tower1);
    }
}
