using System.Collections.Generic;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PinkBox : Box
{
    [SerializeField] protected boxscriptableObj boxData;
    Coroutine AdvanceIndex;

  
    boxType boxColor = boxType.pink;
  
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
        Debug.Log(boxData.boxTypeToGO);
       
        AdvanceIndex =  StartCoroutine(advanceIndex());
        StartCoroutine(popTest());
       
    }

    // Update is called once per frame
    void Update()
    {

      
    }

    void moveToWayPoint(Vector3 wayPointOn)
    {
      enemyMoveMethod(transform.position, wayPointOn, balloonSpeedValue);
    }
    void damageTaken(int damage, boxType box) {
       
        boxType downToLayer = pop(damage, box);


       
      //  Instantiate(balloonPreFab[downToLayer],transform.position,Quaternion.identity);
    }

    IEnumerator popTest() {

        yield return new WaitForSeconds(3);
        damageTaken(1, boxColor);
    }
    IEnumerator advanceIndex() {
      
        yield return new WaitUntil(onWayPoint);
        i++;
        if (!(i >= totalWayPoints+1))
        {
            StartCoroutine(advanceIndex());
        }
        else {
            events.LoseLives.Invoke(layer);
            Destroy(gameObject);
        }
           
    }
    bool onWayPoint() {
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
    