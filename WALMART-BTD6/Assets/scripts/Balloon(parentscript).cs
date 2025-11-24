using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static boxSO;

public class Box : MonoBehaviour, IDamageTaken, IIndex, IGetSetID

{
    protected enum boxType
    {
        none, red, blue, green, yellow, pink, black, white, purple, lead, orange, seagreen,
        ceramic, moab, bfb, zomg, ddt, bad
    }

   

    [SerializeField] protected boxSO boxData;
    protected Coroutine AdvanceIndex;
    protected boxType boxColor;

    protected int layer;
    protected int balloonSpeedValue;
    protected int i = 0;
    protected int outerProtectiveLayer = 0;
    protected int totalWayPoints;
    protected int parentId = -1;
    protected int personalId = -1;
    protected bool damaged = false;

    protected bool camo = false;

    protected string enemyModelPath = "Assets/Resources/boxEnemiesWScript/";

//  protected Dictionary<boxSO.boxType, GameObject> keyValuePairs = new Dictionary<boxSO.boxType, GameObject>();
    protected Dictionary<boxType, int> balloonLayer =new Dictionary<boxType, int>() {
            {boxType.none, 0 },
            {boxType.red, 1 },
            {boxType.blue, 2 },
            {boxType.green, 3 },
            {boxType.yellow, 4 },
            {boxType.pink, 5 },
            {boxType.black, 6 },
            {boxType.white, 6 },
            {boxType.purple, 6 },
            {boxType.orange, 7 },
            {boxType.lead, 7 },
            {boxType.seagreen, 8 },
            {boxType.ceramic, 9 },

    };
   
    //this dictionary is used to get the balloon based on layer boxSO I don't have to loop through the top dictionary to match the hp
    protected Dictionary<int,boxType> layerToBalloon = new Dictionary<int,boxType>() {
            { 1,boxType.red },
            { 2,boxType.blue },
            { 3,boxType.green },
            { 4,boxType.yellow },
            { 5,boxType.pink },
            { 6,boxType.black },
            { 7,boxType.orange},
            { 8,boxType.seagreen},
            { 9,boxType.ceramic}
    };
    //balloon speed
    protected Dictionary<boxType, int> balloonSpeed = new Dictionary<boxType, int>() {
            {boxType.red, 1 },
            {boxType.blue, 2},
            {boxType.green, 3 },
            {boxType.yellow, 4},
            {boxType.pink, 5 },
            {boxType.black, 3},
            {boxType.white, 3 },
            {boxType.purple, 6 },
            {boxType.orange, 2 },
            {boxType.lead, 3 },
            {boxType.seagreen, 3},
            {boxType.ceramic, 3 },
    };
    //milestone7
    protected Dictionary<boxType, string> boxTypeToStringNonCamo = new Dictionary<boxType, string>()
    {
            {boxType.red, "red" },
            {boxType.blue, "blue"},
            {boxType.green, "green" },
            {boxType.yellow, "yellow"},
            {boxType.pink, "pink"},
            {boxType.black, "black"},
            {boxType.white, "white"},
            {boxType.purple, "purple"},
            {boxType.orange, "orange"},
            {boxType.lead, "metal"},
            {boxType.seagreen, "seaGreen"},
            {boxType.ceramic, "ceramic"},
    };
    protected Dictionary<boxType, string> boxTypeToStringCamo = new Dictionary<boxType, string>()
    {
            {boxType.red, "camoRed" },
            {boxType.blue, "camoBlue"},
            {boxType.green, "camoGreen" },
            {boxType.yellow, "camoYellow"},
            {boxType.pink, "camoPink"},
            {boxType.black, "camoBlack"},
            {boxType.white, "camoWhite"},
            {boxType.purple, "camoPurple"},
            {boxType.orange, "camoOrange"},
            {boxType.lead, "camoMetal"},
            {boxType.seagreen, "camoSeaGreen"},
            {boxType.ceramic, "camoCeramic"},
    };

    protected void Start()
    {
        //milestone 7
   
        if (gameObject.layer == 11) {
            camo = true;        
        }
        AdvanceIndex = StartCoroutine(advanceIndex());
    }
    protected IEnumerator advanceIndex()
    {
        yield return new WaitUntil(onWayPoint);
        i++;
        if (!(i >= totalWayPoints + 1))
        {
            StartCoroutine(advanceIndex());
        }
        else
        {
            events.LoseLives.Invoke(layer);
            Destroy(gameObject);
        }

    }
    protected bool onWayPoint()
    {
        if (transform.position == WayPointManager.instance.wayPoints[i].position)
        {
            return true;
        }
        else
        {
            moveToWayPoint(WayPointManager.instance.wayPoints[i].position);         
            return false;
        }

    }
    protected boxType pop(int damage,boxType box) {
        int damageTaken= balloonLayer[box]-damage;
        boxType downToLayer;
        if (damageTaken <=0 ) {
            downToLayer = boxType.none;
        }
        else { 
            downToLayer = layerToBalloon[damageTaken]; 
        }           
        int moneyEarned = balloonLayer[box] - balloonLayer[downToLayer];
        events.GainCash.Invoke(moneyEarned);
        return downToLayer;
    }

    protected void moveToWayPoint(Vector3 wayPointOn)
    {
        enemyMoveMethod(transform.position, wayPointOn, balloonSpeedValue);
    }
    protected void enemyMoveMethod(Vector3 position, Vector3 wayPoint,int speed) { 
    gameObject.transform.position = Vector3.MoveTowards(position, wayPoint, speed * Time.deltaTime);
    }
    protected IEnumerator Iframes()
    {
        yield return new WaitForFixedUpdate();
        gameObject.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<Collider>().enabled = true;
    }
   public void wayPointReciever(int index)
    {
        i = index;
    }
    //mileestone 7 changed this to use assestdatabase to load my prefbs now
    public virtual void damageTaken(int damage, GameObject p)
    {
        GameObject boxToMake;
        boxType downToLayer = pop(damage, boxColor);
        if (!(outerProtectiveLayer - damage <= 0)) {
            outerProtectiveLayer -= damage;       
        }
        else
        {
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
                spawnEnemiesAmount(boxToMake, 1);
                Destroy(gameObject);
            }
        }
    }
    protected void spawnEnemiesAmount(GameObject enemyToSpawn, int amount) {
        List<GameObject> boxList = new List<GameObject>();
        for (int i = amount; i > 0; i--) {
            GameObject boxToAddOntoList = Instantiate(enemyToSpawn,transform.position,Quaternion.identity);   
            boxList.Add(boxToAddOntoList);
        }

        foreach (GameObject box in boxList)
        {
            IGetSetID boxidenfication = box.GetComponent<IGetSetID>();
            IIndex boxIndex = box.GetComponent<IIndex>();
            boxIndex.wayPointReciever(i);
            boxidenfication.setID(personalId);
        }

    }

    public void setID(int IDs) {       
        parentId = IDs;
    }
    
    public int parentGetID() {
        return parentId;
    }
    public int personalGetID() {
        return personalId;    
    }


}
