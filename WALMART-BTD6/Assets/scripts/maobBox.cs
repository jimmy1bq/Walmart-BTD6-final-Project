using System.Collections;
using UnityEngine;

public class moabBox : Box
{
    private void Awake()
    {
        tankOrNot = true;
        balloonSpeedValue = 2.3f;
        outerProtectiveLayer = 150;
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;
        personalId = boxData.ID;
        boxData.ID++;
    }
   
    public override void damageTaken(int damage, GameObject p)
    {
       // Debug.Log(damage);
        GameObject boxToMake;
        if (!(outerProtectiveLayer - damage < 0))
        {
            outerProtectiveLayer -= damage;
        }
        else {
            boxToMake = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "ceramic" + ".prefab");
            spawnEnemiesAmount(boxToMake, 4);
            Destroy(gameObject);
        }
      
    }
    protected override IEnumerator advanceIndex()
    {
        gameObject.transform.LookAt(WayPointManager.instance.wayPoints[i].transform);
        yield return new WaitUntil(onWayPoint);
        i++;
        if (!(i >= totalWayPoints + 1))
        {
            StartCoroutine(advanceIndex());
        }
        else
        {
            events.LoseLives.Invoke(outerProtectiveLayer);
            Destroy(gameObject);
        }

    }
}
