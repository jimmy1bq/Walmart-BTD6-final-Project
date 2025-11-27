using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class OrangeBox : Box, IDamageTaken, IIndex
{
    private void Awake()
    {
        boxColor = boxType.orange;
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;
        personalId = boxData.ID;
        boxData.ID++;

    }
    //milestone 7
    public override void doDamage(int damage, GameObject p)
    {
        boxType downToLayer = pop(damage, boxColor);
        if (downToLayer == boxType.none)
        {
            Destroy(gameObject);
        }
        else
        {
            if (damage == 1)
            {
                if (camo)
                {

                    GameObject white = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "camoWhite" + ".prefab");
                    GameObject black = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "camoBlack" + ".prefab");

                    GameObject whiteGO = Instantiate(white, gameObject.transform.position*1.1f, Quaternion.identity);                   
                    IGetSetID whiteBoxidenfication = whiteGO.GetComponent<IGetSetID>();
                    whiteBoxidenfication.setID(personalId);

                    GameObject blackGO = Instantiate(black, gameObject.transform.position, Quaternion.identity);
                    IGetSetID blackBoxidenfication = blackGO.GetComponent<IGetSetID>();
                    blackBoxidenfication.setID(personalId);

                    IIndex whiteBoxIndex = whiteGO.GetComponent<IIndex>();
                    IIndex blackBoxIndex = blackGO.GetComponent<IIndex>();

                    blackBoxIndex.wayPointReciever(i);                   
                    whiteBoxIndex.wayPointReciever(i);
                    Destroy(gameObject);

                }
                else
                {
                    GameObject white = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "white" + ".prefab");
                    GameObject black = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "black" + ".prefab");

                    GameObject whiteGO = Instantiate(white, gameObject.transform.position * 1.1f, Quaternion.identity);
                    IGetSetID whiteBoxidenfication = whiteGO.GetComponent<IGetSetID>();
                    whiteBoxidenfication.setID(personalId);

                    GameObject blackGO = Instantiate(black, gameObject.transform.position, Quaternion.identity);
                    IGetSetID blackBoxidenfication = blackGO.GetComponent<IGetSetID>();
                    blackBoxidenfication.setID(personalId);

                    IIndex whiteBoxIndex = whiteGO.GetComponent<IIndex>();
                    IIndex blackBoxIndex = blackGO.GetComponent<IIndex>();

                    blackBoxIndex.wayPointReciever(i);
                    whiteBoxIndex.wayPointReciever(i);
                    Destroy(gameObject);

                }

            }
            else {
                GameObject boxToMake;
                if (camo)
                {
                    boxToMake = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + boxTypeToStringCamo[downToLayer] + ".prefab");
                   
                }
                else
                {
                    boxToMake = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + boxTypeToStringNonCamo[downToLayer] + ".prefab");
                    
                }
                spawnEnemiesAmount(boxToMake, 4);               
                Destroy(gameObject);
            }
        }
    }
}
//if (camo)
//{

//    GameObject white = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "camoWhite" + ".prefab");
//    GameObject black = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "camoBlack" + ".prefab");
//    Instantiate(white, gameObject.transform.position, Quaternion.identity);
//    Instantiate(black, gameObject.transform.position, Quaternion.identity);
//    IGetSetID whiteBoxidenfication = white.GetComponent<IGetSetID>();
//    IIndex whiteBoxIndex = white.GetComponent<IIndex>();
//    IDamageTaken whiteBoxDamage = white.GetComponent<IDamageTaken>();
//    IGetSetID blackBoxidenfication = black.GetComponent<IGetSetID>();
//    IIndex blackBoxIndex = black.GetComponent<IIndex>();
//    IDamageTaken blackBoxDamage = black.GetComponent<IDamageTaken>();
//    blackBoxIndex.wayPointReciever(i);
//    blackBoxidenfication.setID(id);
//    whiteBoxIndex.wayPointReciever(i);
//    whiteBoxidenfication.setID(id);
//    whiteBoxDamage.damageTaken(damage - 1, p);
//    blackBoxDamage.damageTaken(damage - 1, p);
//    Destroy(gameObject);

//}
//else
//{
//    GameObject white = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "white" + ".prefab");
//    GameObject black = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + "black" + ".prefab");

//    Instantiate(white, gameObject.transform.position, Quaternion.identity);
//    Instantiate(black, gameObject.transform.position, Quaternion.identity);

//    IGetSetID whiteBoxidenfication = white.GetComponent<IGetSetID>();
//    IIndex whiteBoxIndex = white.GetComponent<IIndex>();
//    IDamageTaken whiteBoxDamage = white.GetComponent<IDamageTaken>();
//    IGetSetID blackBoxidenfication = black.GetComponent<IGetSetID>();
//    IIndex blackBoxIndex = black.GetComponent<IIndex>();
//    IDamageTaken blackBoxDamage = black.GetComponent<IDamageTaken>();
//    blackBoxIndex.wayPointReciever(i);
//    blackBoxidenfication.setID(id);
//    whiteBoxIndex.wayPointReciever(i);
//    whiteBoxidenfication.setID(id);
//    whiteBoxDamage.damageTaken(damage - 1, p);
//    blackBoxDamage.damageTaken(damage - 1, p);
//    Destroy(gameObject);
//}

//            }          
//    }
