using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PinkBox : Box
{

   

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
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position != WayPointManager.instance.wayPoints[i].position)
        {
            moveToWayPoint(WayPointManager.instance.wayPoints[i].position);
        }
        else if (i < totalWayPoints)
        {
            i++;
        }
        else if (i >= totalWayPoints) {
            events.LoseLives.Invoke(balloonLayer[boxColor]);
            Destroy(gameObject);
        }
    }

    void moveToWayPoint(Vector3 wayPointOn)
    {
      enemyMoveMethod(transform.position, wayPointOn, balloonSpeedValue);
    }
    void damageTaken(int damage, boxType box) {
        boxType downToLayer = pop(damage, box);

       

    }
}
