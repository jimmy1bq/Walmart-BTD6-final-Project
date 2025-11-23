using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GreenBox : Box, IDamageTaken, IIndex
{
    private void Awake()
    { 
        boxColor = boxType.green;
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;
       
        if (id == -1)
        {
            id = boxData.ID;
        }
        boxData.ID++;

    }
 }

