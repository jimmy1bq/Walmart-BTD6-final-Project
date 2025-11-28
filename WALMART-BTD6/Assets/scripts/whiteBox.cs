using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class whiteBoxScript : Box, IDamageTaken, IIndex
{



    private void Awake()
    {
        boxColor = boxType.white;
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;

        personalId = boxData.ID;
        boxData.ID++;
    }
    public override void doDamage(int damage)
    {
        GameObject boxToMake;
        boxType downToLayer = pop(damage, boxType.white);
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
                spawnEnemiesAmount(boxToMake, 2);
                Destroy(gameObject);
            }
        }
    }

  

