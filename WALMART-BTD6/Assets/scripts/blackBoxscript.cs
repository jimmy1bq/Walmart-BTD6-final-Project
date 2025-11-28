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
        personalId = boxData.ID;
        boxData.ID++;
    }

    //heres lies an isssue that was resolved. So basically I tried to get dodamage to check for proppeitires because damage taken could get called multiple time in a frame but that end up not working cuz null issue but i just figured to override damage taken since
    public override void damageTaken(int damage, GameObject p)
    {
        if (!(p.GetComponent<IGiveProptieres>().returnCanHitBlack()))
        {
          
        }
        else
        {
            listofDamage.Add(damage);
            damageds = true;
        }
           
    }
    public override void doDamage(int damage)
    {
        GameObject boxToMake;
        boxType downToLayer = pop(damage, boxColor);
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
  

