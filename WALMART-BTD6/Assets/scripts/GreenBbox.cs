using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GreenBox : Box
{
    [SerializeField] protected boxSO boxData;
    Coroutine AdvanceIndex;
    boxSO.boxType boxColor = boxSO.boxType.green;
    int layer;
    int balloonSpeedValue;
    int i = 0;
    int totalWayPoints;


    private void Awake()
    {
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;


    }
    private void Start()
    {
        AdvanceIndex = StartCoroutine(advanceIndex());
    }

    // Update is called once per frame
    void Update()
    {


    }

    void moveToWayPoint(Vector3 wayPointOn)
    {
        enemyMoveMethod(transform.position, wayPointOn, balloonSpeedValue);
    }
    void damageTaken(int damage, boxSO.boxType box)
    {

        boxSO.boxType downToLayer = pop(damage, box);
        Instantiate(boxData.boxTypeToGO[downToLayer], transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    IEnumerator advanceIndex()
    {
      
        yield return new WaitUntil(onWayPoint);
        i++;
        if (!(i >= totalWayPoints + 1))
        {
            StartCoroutine(advanceIndex());
        }
        else
        {
            events.LoseLives.Invoke(layer);
            Destroy(gameObject);
        }

    }
    bool onWayPoint()
    {
        if (transform.position == WayPointManager.instance.wayPoints[i].position)
        {
            return true;
        }
        else
        {
            moveToWayPoint(WayPointManager.instance.wayPoints[i].position);
            return false;
        }

    }
}

