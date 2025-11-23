using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class seaGreenBoxScript : Box, IDamageTaken, IIndex
{
    protected void Awake()
    {
        boxColor = boxType.seagreen;
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;

        if (id == -1)
        {
            id = boxData.ID;
        }
        boxData.ID++;
        StartCoroutine(Iframes());
    }
    //milestone 7
    public override void damageTaken(int damage, GameObject p)
    {
        Debug.Log("Pop");
        boxType downToLayer = pop(damage, boxColor);
        if (downToLayer == boxType.none)
        {
            Destroy(gameObject);
        }
        if (camo)
        {
            if (damage == 1)
            {
                GameObject orangeBox = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "camoOrange" + ".prefab");
                spawnEnemiesAmount(orangeBox, 2);
            }
            else if (damage == 2)
            {
                GameObject white = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "camoWhite" + ".prefab");
                GameObject black = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "camoBlack" + ".prefab");
                spawnEnemiesAmount(white, 2);
                spawnEnemiesAmount(black, 2);
            }
            else if (damage > 2)
            {
                GameObject boxToMake;
                boxToMake = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + boxTypeToStringCamo[downToLayer] + ".prefab");
                spawnEnemiesAmount(boxToMake, 8);
            }
        }
             if(!camo)
                {
                Debug.Log("Pop3");
                if (damage == 1)
                    {
                        GameObject orangeBox = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "orange" + ".prefab");
                        spawnEnemiesAmount(orangeBox, 2);
                    }
                    else if (damage == 2)
                    {
                        GameObject white = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "white" + ".prefab");
                        GameObject black = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "black" + ".prefab");
                        spawnEnemiesAmount(white, 2);
                        spawnEnemiesAmount(black, 2);
                    }
                    else if (damage > 2)
                    {
                        GameObject boxToMake;
                        boxToMake = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + boxTypeToStringNonCamo[downToLayer] + ".prefab");
                        spawnEnemiesAmount(boxToMake, 8);
                    }
                }
                Destroy(gameObject);
            }
        }
    

