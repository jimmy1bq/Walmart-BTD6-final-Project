using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Animations;
using UnityEngine;

public class DartMonke : MonoBehaviour
{
    float range = 5;
    [SerializeField] TowersSO towerData;
    [SerializeField] projectileSO projctileData;
    [SerializeField] boxSO boxData;
    [SerializeField] int fireRate;
    int towerIDIM;
    private void Awake()
    {
        towerIDIM = towerData.towerID;
        towerData.towerID++;
    }
    void Start()
    {
     Vector3 rangePos = towerData.placeTowerRangeCircle(gameObject);
     GameObject rangeC =Instantiate(towerData.rangeCricle,rangePos, Quaternion.identity);
        rangeC.transform.parent = gameObject.transform;

        rangeC.SetActive(false);
     StartCoroutine(spawnattackCD());
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator attackEnemy() {
      GameObject closestEnemy = null;
        range = 5;

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
        //transform.GetChild(4).position
        if (closestEnemy != null)
        {
         //   Debug.Log("Throw");
            gameObject.transform.LookAt(closestEnemy.transform);
            Vector3 projctileSpawn = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
         //   Debug.Log(projctileData.dartProjctile);
            GameObject dart = Instantiate(projctileData.dartProjctile, projctileSpawn, transform.GetChild(4).rotation);
            dart.GetComponent<dartProj>().setClosestEnemy(closestEnemy);
        }
        else if (closestEnemy == null) {
            //if theres no enemy in range waait until theres one in range
            yield return new WaitUntil(enemyInRange);
            StartCoroutine(attackEnemy());
        }
            yield return new WaitForSeconds(fireRate);
            StartCoroutine(attackEnemy());
    }
    IEnumerator spawnattackCD() { 
             yield return new WaitForSeconds(1);
             StartCoroutine(attackEnemy());
    }
    bool enemyInRange() {
        foreach (var keyValuePair in boxData.boxsesOnMap) {
            if (keyValuePair.Value != null) { 
            float distance = Vector3.Magnitude(keyValuePair.Value.transform.position - transform.position);
               // Debug.Log("checking:"+ distance + ": " + keyValuePair  );
               //holy shit thank god unity loops thru the whole dictionary in a frame i was about to start
               // n(dictionary length) amount of thread to get all of them at the same time
                if (distance <= range) { return true; }
        }
        }
          return false;
    }
    //find first child with the string name; yes its suppose to be like roblox's findfirstChild method that they provide
    int findFirstChild() {

        return 1;
    }
}
