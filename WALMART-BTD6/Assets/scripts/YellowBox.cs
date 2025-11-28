using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class YellowBox : Box, IDamageTaken, IIndex
{
    private void Awake()
    {
        boxColor = boxType.yellow;
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
        if (WayPointManager.instance != null) { totalWayPoints = WayPointManager.instance.wayPoints.Count - 1; }
        personalId = boxData.ID;
        boxData.ID++;
    }
}

