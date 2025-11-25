using System.Collections;
using UnityEngine;

public class zomgBox : Box
{
    private void Awake()
    {
        balloonSpeedValue = 1;
        outerProtectiveLayer = 800;
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;
        personalId = boxData.ID;
        boxData.ID++;
    }
   
    public override void damageTaken(int damage, GameObject p)
    {

        GameObject boxToMake;
        if (!(outerProtectiveLayer - damage < 0))
        {
            outerProtectiveLayer -= damage;
        }
        else {
            boxToMake = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "redTank" + ".prefab");
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
