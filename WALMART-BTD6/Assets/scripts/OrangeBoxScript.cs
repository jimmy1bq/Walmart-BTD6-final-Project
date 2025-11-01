using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrangeBox : Box, IDamageTaken, IIndex
{

    [SerializeField] protected boxSO boxData;
    Coroutine AdvanceIndex;
    boxSO.boxType boxColor = boxSO.boxType.orange;
    int layer;
    int balloonSpeedValue;
    int i = 0;
    int ogI;
    int totalWayPoints;


    private void Awake()
    {
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;
        boxData.boxsesOnMap.Add(boxData.ID, gameObject);
        boxData.ID++;
        StartCoroutine(Iframes());
      

    }
    private void Start()
    {
        if (ogI != 0)
        {
            i = ogI;
        }
      
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
            events.LoseLives.Invoke(balloonLayer[boxColor]);
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


    public void damageTaken(int damage)
    {

        boxSO.boxType downToLayer = pop(damage, boxColor);


        if (downToLayer == boxSO.boxType.none)
        {
            Destroy(gameObject);
            boxData.boxsesOnMap.Remove(boxData.ID);
        }
        else
        {
            GameObject box = Instantiate(boxData.boxTypeToGO[downToLayer], transform.position, Quaternion.identity);
            IIndex boxIndex = box.GetComponent<IIndex>();
            boxIndex.wayPointReciever(i);
            boxData.boxsesOnMap.Remove(boxData.ID);
            Destroy(gameObject);
        }
    }
    public void wayPointReciever(int index)
    {
        ogI = index;
    }
}

