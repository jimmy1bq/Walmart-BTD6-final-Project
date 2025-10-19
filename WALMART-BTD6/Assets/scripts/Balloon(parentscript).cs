using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
  
    [SerializeField] protected  boxscriptableObj boxData;
    [SerializeField] private int[] noob;
    public static Box instance;


    protected enum boxType { 
    none,red,blue,green, yellow, pink, black, white, purple, lead, orange, seagreen }
    protected enum bigBoxType
    {
       ceramic, moab, bfb, zomg, ddt, bad
    }
    protected Dictionary<boxType, GameObject> balloonPreFab=new Dictionary<boxType, GameObject>();

    protected Dictionary<boxType, int> balloonLayer =new Dictionary<boxType, int>() {
            { boxType.none, 0 },
            { boxType.red, 1 },
            { boxType.blue, 2 },
            { boxType.green, 3 },
            { boxType.yellow, 4 },
            { boxType.pink, 5 },
            { boxType.black, 6 },
            { boxType.white, 6 },
            { boxType.purple, 6 },
            { boxType.lead, 7 },
            { boxType.orange, 7 },
            { boxType.seagreen, 8 },
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
    protected Dictionary<int, boxType> layerToBalloon = new Dictionary<int, boxType>() {
            { 1, boxType.red },
            { 2, boxType.blue },
            { 3, boxType.green },
            { 4, boxType.yellow },
            { 5, boxType.pink },
            { 6, boxType.black },
            { 7, boxType.lead },
            { 8, boxType.seagreen },
    };
    //balloon speed
    protected Dictionary<boxType, int> balloonSpeed = new Dictionary<boxType, int>() {
            { boxType.red, 1 },
            { boxType.blue, 2},
            { boxType.green, 3 },
            { boxType.yellow, 4},
            { boxType.pink, 5 },
            { boxType.black, 3},
            { boxType.white, 3 },
            { boxType.purple, 6 },
            { boxType.lead, 2 },
            { boxType.orange, 3 },
            { boxType.seagreen, 3},
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

  

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(boxData.redb);
    }
    
    protected boxType pop(int damage, boxType box) {
        int damageTaken= balloonLayer[box]-damage;
        if (damageTaken <=0 ) {
            return boxType.none;
        }
        return layerToBalloon[damageTaken];
    }


    protected void enemyMoveMethod(Vector3 position, Vector3 wayPoint,int speed) { 
    this.transform.position = Vector3.MoveTowards(position, wayPoint, speed * Time.deltaTime);
    }

    public void initDictionary() {
        //       balloonPreFab = new Dictionary<boxType, GameObject>() {
        //     { boxType.red, boxData.redb },
        //    { boxType.blue, boxData.blueb },
        //    { boxType.green, boxData.greenb },
        //   { boxType.yellow, boxData.yellowb },
        //  { boxType.pink, boxData.pinkb },
        // };
        Debug.Log(boxData.redb);
    }
   


}
