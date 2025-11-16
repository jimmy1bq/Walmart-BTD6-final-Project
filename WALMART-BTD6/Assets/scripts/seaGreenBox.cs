using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class seaGreenBoxScript : Box, IDamageTaken, IIndex
{
    protected void Awake()
    {
        boxColor = boxSO.boxType.seagreen;
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;
        boxData.boxsesOnMap.Add(boxData.ID, gameObject);
        boxData.ID++;
        StartCoroutine(Iframes());
    }
}

