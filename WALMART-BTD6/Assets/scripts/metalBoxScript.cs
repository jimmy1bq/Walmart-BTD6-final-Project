using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class metalBoxScript : Box, IDamageTaken, IIndex
{

   
    private void Awake()
    {
        boxColor =boxType.lead;
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;

        personalId = boxData.ID;
        boxData.ID++;
    }
    //milestone 7 added this script
    public override void damageTaken(int damage, GameObject p)
    {
        GameObject boxToMake;
        boxType downToLayer = pop(damage, boxColor);
        bool canHitLeadq = p.GetComponent<IGiveProptieres>().returnCanHitLead();
        if (!canHitLeadq)
        {
            Destroy(p);
        }
        else
        {
            if (downToLayer == boxType.none)
            {
                Destroy(gameObject);              
            }
            else
            {
                if (camo)
                {
                    boxToMake = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + boxTypeToStringCamo[downToLayer] + ".prefab");
                }
                else
                {
                    boxToMake = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + boxTypeToStringNonCamo[downToLayer] + ".prefab");
                }
                spawnEnemiesAmount(boxToMake, 1);
                Destroy(gameObject);
            }         
        }
    }
}

