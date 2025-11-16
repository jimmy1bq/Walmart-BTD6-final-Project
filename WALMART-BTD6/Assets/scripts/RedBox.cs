using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RedBox : Box , IIndex, IDamageTaken
{
   


    private void Awake()
    {
        boxColor = boxSO.boxType.red;
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
        totalWayPoints = WayPointManager.instance.wayPoints.Count-1;
        boxData.boxsesOnMap.Add(boxData.ID, gameObject);
        boxData.ID++;
        StartCoroutine(Iframes());
    }
}
