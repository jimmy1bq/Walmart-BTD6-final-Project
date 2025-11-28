using System.Collections;
using UnityEngine;

public class BADBox : Box
{
    private void Awake()
    {
        tankOrNot = true;
        balloonSpeedValue = 0.5f;
        outerProtectiveLayer = 3000;
        if (WayPointManager.instance != null) { totalWayPoints = WayPointManager.instance.wayPoints.Count - 1; }
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
        else
        {
            if (!(outerProtectiveLayer - damage < 0))
            {
                outerProtectiveLayer -= damage;
            }
            else
            {
                boxToMake = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "zomgTank" + ".prefab");
                spawnEnemiesAmount(boxToMake, 2);
                boxToMake = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "blackTank" + ".prefab");
                spawnEnemiesAmount(boxToMake, 2);
                Destroy(gameObject);
            }
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
