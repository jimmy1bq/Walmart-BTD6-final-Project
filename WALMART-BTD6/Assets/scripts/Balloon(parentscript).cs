using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static boxSO;

public class Box : MonoBehaviour

{

   protected Dictionary<boxSO.boxType, GameObject> keyValuePairs = new Dictionary<boxSO.boxType, GameObject>();
    protected Dictionary<boxSO.boxType, int> balloonLayer =new Dictionary<boxSO.boxType, int>() {
            { boxSO.boxType.none, 0 },
            { boxSO.boxType.red, 1 },
            { boxSO.boxType.blue, 2 },
            { boxSO.boxType.green, 3 },
            { boxSO.boxType.yellow, 4 },
            { boxSO.boxType.pink, 5 },
            { boxSO.boxType.black, 6 },
            { boxSO.boxType.white, 6 },
            { boxSO.boxType.purple, 6 },
            { boxSO.boxType.lead, 7 },
            { boxSO.boxType.orange, 7 },
            { boxSO.boxType.seagreen, 8 },
            { boxSO.boxType.ceramic, 9 },

    };
   
    //this dictionary is used to get the balloon based on layer boxSO I don't have to loop through the top dictionary to match the hp
    protected Dictionary<int, boxSO.boxType> layerToBalloon = new Dictionary<int, boxSO.boxType>() {
            { 1, boxSO.boxType.red },
            { 2, boxSO.boxType.blue },
            { 3, boxSO.boxType.green },
            { 4, boxSO.boxType.yellow },
            { 5, boxSO.boxType.pink },
            { 6, boxSO.boxType.black },
            { 7, boxSO.boxType.lead },
            { 8, boxSO.boxType.seagreen },
    };
    //balloon speed
    protected Dictionary<boxSO.boxType, int> balloonSpeed = new Dictionary<boxSO.boxType, int>() {
            { boxSO.boxType.red, 1 },
            { boxSO.boxType.blue, 2},
            { boxSO.boxType.green, 3 },
            { boxSO.boxType.yellow, 4},
            { boxSO.boxType.pink, 5 },
            { boxSO.boxType.black, 3},
            { boxSO.boxType.white, 3 },
            { boxSO.boxType.purple, 6 },
            { boxSO.boxType.lead, 2 },
            { boxSO.boxType.orange, 3 },
            { boxSO.boxType.seagreen, 3},
            { boxSO.boxType.ceramic, 3 },
    };

  

  
    
    protected boxSO.boxType pop(int damage, boxSO.boxType box) {
        int damageTaken= balloonLayer[box]-damage;
       
        if (damageTaken <=0 ) {
            return boxSO.boxType.none;
        }
        return layerToBalloon[damageTaken];
    }


    protected void enemyMoveMethod(Vector3 position, Vector3 wayPoint,int speed) { 
    this.transform.position = Vector3.MoveTowards(position, wayPoint, speed * Time.deltaTime);
    }
    protected IEnumerator Iframes()
    {
        yield return new WaitForFixedUpdate();
        gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<Collider>().enabled = true;
    }


   


}
