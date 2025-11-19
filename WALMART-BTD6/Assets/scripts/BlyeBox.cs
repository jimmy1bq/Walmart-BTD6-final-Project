using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlueBox : Box, IDamageTaken, IIndex
{

    
    private void Awake()
    {
        boxColor = boxSO.boxType.blue;
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;
        boxData.boxsesOnMap.Add(boxData.ID, gameObject);
        if (id == -1)
        {
            id = boxData.ID;
        }
        boxData.ID++;
       

    }
}
