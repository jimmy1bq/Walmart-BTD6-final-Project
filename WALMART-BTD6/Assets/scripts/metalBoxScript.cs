using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class metalBoxScript : Box, IDamageTaken, IIndex
{

   
    private void Awake()
    {
        boxColor = boxSO.boxType.lead;
        layer = balloonLayer[boxColor];
        balloonSpeedValue = balloonSpeed[boxColor];
        totalWayPoints = WayPointManager.instance.wayPoints.Count - 1;
        boxData.boxsesOnMap.Add(boxData.ID, gameObject);
        if (id == -1)
        {
            id = boxData.ID;
        }
        boxData.ID++;
        StartCoroutine(Iframes());
    }
    public override void damageTaken(int damage, GameObject p)
    {

        boxSO.boxType downToLayer = pop(damage, boxColor);
        bool canHitLeadq = p.GetComponent<IGiveProptieres>().returnCanHitLead();
        if (!canHitLeadq)
        {
            Destroy(p);
        }
        else
        {
            if (downToLayer == boxSO.boxType.none)
            {
                Destroy(gameObject);
                boxData.boxsesOnMap.Remove(boxData.ID);
            }
            else
            {
                GameObject box = Instantiate(boxData.boxTypeToGO[downToLayer], transform.position, Quaternion.identity);
                IGetSetID boxidenfication = box.GetComponent<IGetSetID>();
                IIndex boxIndex = box.GetComponent<IIndex>();
                boxIndex.wayPointReciever(i);
                boxidenfication.setID(id);
                boxData.boxsesOnMap.Remove(boxData.ID);
                Destroy(gameObject);
            }
        }
    }
}

