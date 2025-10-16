using System.Collections.Generic;
using UnityEngine;

public class RedBox : Box
{
    boxType boxColor = boxType.red;
    int layer;
    int balloonSpeedValue;
    int i=0;
   

    private void Awake()
    {
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
     

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
       else { i++; }
       
    }
    void gotPop() { 
        Destroy(gameObject);
    }
    void moveToWayPoint(Vector3 wayPointOn)
    {
       gameObject.transform.position = Vector3.MoveTowards(transform.position, wayPointOn, balloonSpeedValue * Time.deltaTime);
    }

}
