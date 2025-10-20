using System.Collections.Generic;
using UnityEngine;
using static boxscriptableObj;

public class Box : MonoBehaviour
{
  
  

   

 
    protected Dictionary<boxscriptableObj.boxType, GameObject> balloonPreFab=new Dictionary<boxscriptableObj.boxType, GameObject>();

    protected Dictionary<boxscriptableObj.boxType, int> balloonLayer =new Dictionary<boxscriptableObj.boxType, int>() {
            { boxType.none, 0 },
            { boxscriptableObj.boxType.red, 1 },
            { boxscriptableObj.boxType.blue, 2 },
            { boxscriptableObj.boxType.green, 3 },
            { boxscriptableObj.boxType.yellow, 4 },
            { boxscriptableObj.boxType.pink, 5 },
            { boxscriptableObj.boxType.black, 6 },
            { boxscriptableObj.boxType.white, 6 },
            { boxscriptableObj.boxType.purple, 6 },
            { boxscriptableObj.boxType.lead, 7 },
            { boxscriptableObj.boxType.orange, 7 },
            { boxscriptableObj.boxType.seagreen, 8 },
    };
    protected Dictionary<bigBoxType, int> bigBalloonHp =new Dictionary<bigBoxType, int>() {
            { bigBoxType.ceramic, 200 },
            { bigBoxType.moab, 2000 },
            { bigBoxType.bfb, 6000 },
            { bigBoxType.zomg, 20000 },
            { bigBoxType.ddt, 1000 },
            { bigBoxType.bad, 1000000 },
    };
    //this dictionary is used to get the balloon based on layer so I don't have to loop through the top dictionary to match the hp
    protected Dictionary<int, boxscriptableObj.boxType> layerToBalloon = new Dictionary<int, boxscriptableObj.boxType>() {
            { 1, boxscriptableObj.boxType.red },
            { 2, boxscriptableObj.boxType.blue },
            { 3, boxscriptableObj.boxType.green },
            { 4, boxscriptableObj.boxType.yellow },
            { 5, boxscriptableObj.boxType.pink },
            { 6, boxscriptableObj.boxType.black },
            { 7, boxscriptableObj.boxType.lead },
            { 8, boxscriptableObj.boxType.seagreen },
    };
    //balloon speed
    protected Dictionary<boxscriptableObj.boxType, int> balloonSpeed = new Dictionary<boxscriptableObj.boxType, int>() {
            { boxscriptableObj.boxType.red, 1 },
            { boxscriptableObj.boxType.blue, 2},
            { boxscriptableObj.boxType.green, 3 },
            { boxscriptableObj.boxType.yellow, 4},
            { boxscriptableObj.boxType.pink, 5 },
            { boxscriptableObj.boxType.black, 3},
            { boxscriptableObj.boxType.white, 3 },
            { boxscriptableObj.boxType.purple, 6 },
            { boxscriptableObj.boxType.lead, 2 },
            { boxscriptableObj.boxType.orange, 3 },
            { boxscriptableObj.boxType.seagreen, 3},
    };
    //big balloon speed
    protected Dictionary<bigBoxType, int> bigBalloonSpeed =  new Dictionary<bigBoxType, int>() {
            { bigBoxType.ceramic, 2 },
            { bigBoxType.moab, 4 },
            { bigBoxType.bfb,  3},
            { bigBoxType.zomg, 2 },
            { bigBoxType.ddt, 8 },
            { bigBoxType.bad, 1 },
    };

  

  
    
    protected boxscriptableObj.boxType pop(int damage, boxscriptableObj.boxType box) {
        int damageTaken= balloonLayer[box]-damage;
        if (damageTaken <=0 ) {
            return boxscriptableObj.boxType.none;
        }
        return layerToBalloon[damageTaken];
    }


    protected void enemyMoveMethod(Vector3 position, Vector3 wayPoint,int speed) { 
    this.transform.position = Vector3.MoveTowards(position, wayPoint, speed * Time.deltaTime);
    }

   
   


}
