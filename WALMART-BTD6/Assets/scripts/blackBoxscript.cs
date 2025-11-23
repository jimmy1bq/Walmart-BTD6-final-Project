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
        boxColor = boxType.black;
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;

        if (id == -1)
        {
            id = boxData.ID;
        }
        boxData.ID++;
    }
      
    public override void damageTaken(int damage, GameObject p)
    {
            GameObject boxToMake;
            boxType downToLayer = pop(damage, boxType.black);
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

