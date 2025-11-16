using System.Collections.Generic;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using JetBrains.Annotations;
using UnityEditor;

public class blackBoxScript : Box, IDamageTaken, IIndex
{
  


    private void Awake()
    {
        boxColor = boxSO.boxType.black;
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];   
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;       
        boxData.boxsesOnMap.Add(boxData.ID, gameObject);    
        boxData.ID++;
    }
}
