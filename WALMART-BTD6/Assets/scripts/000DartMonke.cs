using NUnit.Framework;
using System.Collections;
using Unity.Mathematics;
using UnityEditor.Animations;
using UnityEngine;

public class DartMonke : MonoBehaviour
{
    float range = 10;
    [SerializeField] TowersSO towerData;
    [SerializeField] boxSO boxData;
    [SerializeField] int fireRate;
    void Start()
    {
     Vector3 rangePos = towerData.placeTowerRangeCircle(gameObject);
     GameObject rangeC =Instantiate(towerData.rangeCricle,rangePos, Quaternion.identity);
     rangeC.SetActive(false);
        StartCoroutine(spawnattackCD());
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator attackEnemy() {
      GameObject closestEnemy = null;
        range = 10;

        foreach (var keyValuePair in boxData.boxsesOnMap)
        {
            if (keyValuePair.Value != null)
            {

                float distance = Vector3.Magnitude(keyValuePair.Value.transform.position - transform.position);
                if (towerData.rangeCheck(distance, range))
                {
                    closestEnemy = keyValuePair.Value;
                    range = distance;
                }
            }
        }
        if (closestEnemy != null)
        {
            Debug.Log("Hit");
            gameObject.transform.LookAt(closestEnemy.transform);
            GameObject dart = Instantiate(towerData.dartProjectile, transform.GetChild(4).position, transform.GetChild(4).rotation);
            dart.GetComponent<dartProj>().setClosestEnemy(closestEnemy);            
        }
        yield return new WaitForSeconds(fireRate);
        StartCoroutine(attackEnemy());
    }
    IEnumerator spawnattackCD() { 
    
    
    yield return new WaitForSeconds(1);
    StartCoroutine(attackEnemy());
    }
    
}
