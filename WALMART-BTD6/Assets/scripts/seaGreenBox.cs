using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class seaGreenBoxScript : Box, IDamageTaken, IIndex
{
    protected void Awake()
    {
        boxColor = boxType.seagreen;
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;
      
        if(id == -1) {
            id = boxData.ID;
        }    
        boxData.ID++;
        StartCoroutine(Iframes());
    }
}

