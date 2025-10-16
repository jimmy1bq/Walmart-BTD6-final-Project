using System.Collections.Generic;
using UnityEngine;

public class RedBox : Box
{
    boxType boxColor = boxType.red;
    int layer;
    int balloonSpeedValue;
    
    private void Awake()
    {
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
     

    }
    private void Start()
    {
        moveToWayPoint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void gotPop() { 
        Destroy(gameObject);
    }
    void moveToWayPoint()
    {
        foreach (Transform point in wayPoints)
        {
            transform.position = Vector3.MoveTowards(transform.position, point.position, balloonSpeedValue * Time.deltaTime);
        }
    }

}
