using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class YellowBox : Box, IDamageTaken, IIndex
{
    private void Awake()
    {
        boxColor = boxSO.boxType.yellow;
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;
        boxData.boxsesOnMap.Add(boxData.ID, gameObject);
        id = boxData.ID;
        boxData.ID++;
        StartCoroutine(Iframes());
    }
}

