using System.Collections.Generic;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using JetBrains.Annotations;

public class PinkBox : Box, IDamageTaken, IIndex
{
    private void Awake()
    {
        boxColor = boxType.pink;   
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
        if (WayPointManager.instance != null) { totalWayPoints = WayPointManager.instance.wayPoints.Count - 1; }
        personalId = boxData.ID;
        boxData.ID++;
    }
}
    