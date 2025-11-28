using System.Collections;
using UnityEngine;

public class ddtBox : Box
{
    private void Awake()
    {
        tankOrNot = true;
        balloonSpeedValue = 5f;
        outerProtectiveLayer = 350;
        if (WayPointManager.instance != null) { totalWayPoints = WayPointManager.instance.wayPoints.Count - 1; }
        personalId = boxData.ID;
        boxData.ID++;
    }
   
    public override void damageTaken(int damage, GameObject p)
    {

        GameObject boxToMake;
        bool canHitLeadq = p.GetComponent<IGiveProptieres>().returnCanHitLead();
        if (!canHitLeadq)
        {
            Destroy(p);
        }
        else
        {
            if (!(outerProtectiveLayer - damage < 0))
            {
                outerProtectiveLayer -= damage;
            }
            else
            {
                boxToMake = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "camoCeramic" + ".prefab");
                spawnEnemiesAmount(boxToMake, 4);
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
