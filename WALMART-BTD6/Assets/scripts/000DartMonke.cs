using System.Collections;
using UnityEngine;

public class DartMonke : MonoBehaviour
{
    int range = 10;
    [SerializeField] TowersSO towerData;
    [SerializeField] int fireRate;
    void Start()
    {
     Vector3 rangePos = towerData.placeTowerRangeCircle(gameObject);
     GameObject range =Instantiate(towerData.rangeCricle,rangePos, Quaternion.identity);
     range.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator throwProjectile() {
      yield return new WaitForSeconds(fireRate);
    }
}
