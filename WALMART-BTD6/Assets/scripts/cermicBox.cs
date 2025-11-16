using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class cermBoxHp : Box, IDamageTaken, IIndex
{
    private void Awake()
    {
        boxColor = boxSO.boxType.ceramic;
        layer = balloonLayer[boxColor];
        hp = 10;
        balloonSpeedValue = balloonSpeed[boxColor];
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;
        boxData.boxsesOnMap.Add(boxData.ID, gameObject);
        boxData.ID++;
        StartCoroutine(Iframes());
      

    }
}

