using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class cermBoxHp : Box, IDamageTaken, IIndex
{
    private void Awake()
    {
        outerProtectiveLayer = 10;
        boxColor = boxType.ceramic;
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;
        personalId = boxData.ID;
        boxData.ID++;
    }
    public override void damageTaken(int damage, GameObject p)
    {

        
        if (!(outerProtectiveLayer - damage <= 0))
        {           
            outerProtectiveLayer -= damage;
        }
        else
        {           
            boxType downToLayer = pop(damage-outerProtectiveLayer, boxColor);
            if (downToLayer == boxType.none)
            {
                Destroy(gameObject);
            }
            else if (camo)
            {
                if (damage - outerProtectiveLayer == 0) {
                    GameObject seaGreenBox = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "camoSeaGreen" + ".prefab");
                    spawnEnemiesAmount(seaGreenBox, 2);

                }
                else if (damage - outerProtectiveLayer == 1)
                {
                    GameObject orangeBox = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "camoOrange" + ".prefab");
                    spawnEnemiesAmount(orangeBox, 8);
                }
                else if (damage - outerProtectiveLayer == 2)
                {
                    GameObject white = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "camoWhite" + ".prefab");
                    GameObject black = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "camoBlack" + ".prefab");
                    spawnEnemiesAmount(white, 8);
                    spawnEnemiesAmount(black, 8);
                }
                else if (damage - outerProtectiveLayer > 2)
                {
                    GameObject boxToMake;
                    boxToMake = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + boxTypeToStringCamo[downToLayer] + ".prefab");
                    spawnEnemiesAmount(boxToMake, 16);
                }
            }
            else if (!camo)
            {
               
                if (damage - outerProtectiveLayer == 0)
                {
                    GameObject seaGreenBox = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "seaGreen" + ".prefab");
                    spawnEnemiesAmount(seaGreenBox, 2);

                }
                if (damage - outerProtectiveLayer == 1)
                {
                    GameObject orangeBox = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "orange" + ".prefab");
                    spawnEnemiesAmount(orangeBox, 8);
                }
                else if (damage - outerProtectiveLayer == 2)
                {
                    GameObject white = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "white" + ".prefab");
                    GameObject black = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "black" + ".prefab");
                    spawnEnemiesAmount(white, 8);
                    spawnEnemiesAmount(black, 8);
                }
                else if (damage - outerProtectiveLayer > 2)
                {
                    GameObject boxToMake;
                    boxToMake = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + boxTypeToStringNonCamo[downToLayer] + ".prefab");
                    spawnEnemiesAmount(boxToMake, 16);
                }
            }
            Destroy(gameObject);
        }
    }
}
 


