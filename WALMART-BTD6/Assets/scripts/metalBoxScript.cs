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
       
        if (id == -1)
        {
            id = boxData.ID;
        }
        boxData.ID++;
        StartCoroutine(Iframes());
    }
    //milestone 7 added this script
    public override void damageTaken(int damage, GameObject p)
    {

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
                GameObject boxToMake = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemyModelPath + boxTypeToStringNonCamo[downToLayer] + ".prefab");
                GameObject box = Instantiate(boxToMake, transform.position, Quaternion.identity);
                IGetSetID boxidenfication = box.GetComponent<IGetSetID>();
                IIndex boxIndex = box.GetComponent<IIndex>();
                boxIndex.wayPointReciever(i);
                boxidenfication.setID(id);
                
                Destroy(gameObject);
            }
        }
    }
}

