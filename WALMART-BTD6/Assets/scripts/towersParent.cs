using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SocialPlatforms;


public class towersParent : MonoBehaviour, IHovering, IUNORSelected, IPopToPopCount, ICollidingWithTowers
{

    [SerializeField] protected LayerMask enemy;

    protected string monkeyModelPath = "Assets/Resources/DartMonkey/";
    protected string monkeyGeneralGUIPath = "Assets/Resources/towerGUI/";
    protected string monkeyGUIPath = "Assets/Resources/towerGUI/";
    protected string projctilePath = "Assets/Resources/Projectile/";
    protected string towerName;

    protected GameObject monkeyUI;
    protected GameObject rangeC;
    protected GameObject rangeCircle;
    protected string projctile;
    protected bool colliding;
    protected bool hiddenDec;

    //milestone 7
    protected LayerMask boxLayerToHit = 1 << 9;

    protected int price;
    protected int targettingNum;

    protected Dictionary<string, int> pathToTier;
    protected Dictionary<string, float> stats;
    //later put an array with function 

    public delegate IEnumerator TargettingDelegate();

    bool hoveringS = false;

    protected List<TargettingDelegate> targgetingList = new List<TargettingDelegate>();
    protected List<string> targettingListNames = new List<string> { "first", "closest", "last", "strongest", "random" };

    protected void Start()
    {
        events.changeTarget.AddListener(changeTarget);
        targgetingList.Add(() => firstTargetting());
        targgetingList.Add(() => closestTargetting());
        targgetingList.Add(() => lastTargettign());
        targgetingList.Add(() => strongestTargettign());
        targgetingList.Add(() => randomTargettign());

    }
    protected void Update()
    {
        if (hoveringS)
        {
            if (checkForCollisionWithTower())
            {
                rangeC.GetComponent<Renderer>().material.color = new Color(255 / 255, 0 / 255, 0 / 255, 0.3f);
                colliding = true;
            }
            else
            {
                rangeC.GetComponent<Renderer>().material.color = new Color(255 / 255, 255 / 255, 255 / 255, 0.3f);
                colliding = false;
            }
        }
    }
    protected bool checkForCollisionWithTower()
    {
        Collider[] colliders = Physics.OverlapBox(gameObject.transform.position, new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z) * .75f, quaternion.identity, (1 << 8 | 1 << 10));
        if (colliders.Length > 0)
        {
            Debug.Log(colliders[0]);
            return true;
        }
        return false;
    }
    protected Vector3 placeTowerRangeCircle(GameObject tower)
    {
        Vector3 rangePos = new Vector3(tower.transform.position.x, tower.transform.position.y, tower.transform.position.z) + new Vector3(0, 0.01f, 0);
        return rangePos;
    }

    protected IEnumerator closestTargetting()
    {
        GameObject closestEnemy = null;
        //milestone 7 layermask change
        Collider[] enemyCollider = Physics.OverlapSphere(gameObject.transform.position, stats["Range"], boxLayerToHit);
        float rangeClosest = stats["Range"];
        float distance;
        foreach (var enemies in enemyCollider)
        {
            distance = Vector3.Magnitude(gameObject.transform.position - enemies.transform.position);
            if (distance <= rangeClosest)
            {
                rangeClosest = distance;
                closestEnemy = enemies.gameObject;
            }
        }
        if (closestEnemy != null)
        {
            attackEnemy(closestEnemy);
            yield return new WaitForSeconds(stats["FireRate"]);
        }
        else if (closestEnemy == null)
        {
            //if theres no enemy in range waait until theres one in range

            yield return new WaitUntil(enemyInRange);
        }
        //later this is not going to be closesttargetting incase the player changes targetting
        StartCoroutine(targgetingList[targettingNum].Invoke());

    }
    //milestone 7
    protected IEnumerator firstTargetting()
    {
        GameObject firstEnemy = null;
        float distance = 99999f;
        int indexHighest = 0;
        Collider[] enemyCollider = Physics.OverlapSphere(gameObject.transform.position, stats["Range"], boxLayerToHit);
        foreach (var enemies in enemyCollider)
        {
            IreturnIndexNum ei = enemies.gameObject.GetComponent<IreturnIndexNum>();
            Debug.Log(ei.wayPointIndex() > indexHighest);

            if (ei.wayPointIndex() > indexHighest)
            {
                firstEnemy = enemies.gameObject;
                distance = enemies.gameObject.GetComponent<IreturnIndexNum>().returnDistanceFromWayPoint();
                indexHighest = ei.wayPointIndex();
            }
            else if (ei.wayPointIndex() == indexHighest)
            {
                if (enemies.gameObject.GetComponent<IreturnIndexNum>().returnDistanceFromWayPoint() < distance)
                {
                    Debug.Log("hi");
                    firstEnemy = enemies.gameObject;
                    distance = enemies.gameObject.GetComponent<IreturnIndexNum>().returnDistanceFromWayPoint();
                }
            }
        }
        if (firstEnemy != null)
        {
            Debug.Log("HI");
            attackEnemy(firstEnemy);
            yield return new WaitForSeconds(stats["FireRate"]);
        }
        else { yield return new WaitUntil(enemyInRange); }
        StartCoroutine(targgetingList[targettingNum].Invoke());
    }
    //milestone 7
    protected IEnumerator lastTargettign()
    {
        GameObject lastEnemy = null;
        float distance = 0f;
        int indexLowest = 0;
        Collider[] enemyCollider = Physics.OverlapSphere(gameObject.transform.position, stats["Range"], boxLayerToHit);
        foreach (var enemies in enemyCollider)
        {
            IreturnIndexNum ei = enemies.gameObject.GetComponent<IreturnIndexNum>();
            Debug.Log(ei.wayPointIndex() > indexLowest);

            if (ei.wayPointIndex() < indexLowest)
            {
                lastEnemy = enemies.gameObject;
                distance = enemies.gameObject.GetComponent<IreturnIndexNum>().returnDistanceFromWayPoint();
                indexLowest = ei.wayPointIndex();
            }
            else if (ei.wayPointIndex() == indexLowest)
            {
                if (enemies.gameObject.GetComponent<IreturnIndexNum>().returnDistanceFromWayPoint() > distance)
                {

                    lastEnemy = enemies.gameObject;
                    distance = enemies.gameObject.GetComponent<IreturnIndexNum>().returnDistanceFromWayPoint();
                }
            }
        }

        if (lastEnemy != null)
        {
            attackEnemy(lastEnemy);
            yield return new WaitForSeconds(stats["FireRate"]);
        }
        else { yield return new WaitUntil(enemyInRange); }
        StartCoroutine(targgetingList[targettingNum].Invoke());
    }
    //milestone 7
    protected IEnumerator strongestTargettign()
    {
        Debug.Log("HI");
        GameObject strongestEnemy = null;
        int layerHighest = 0;
        int hpHighest = 0;
        //milestone 7 layermask change
        Collider[] enemyCollider = Physics.OverlapSphere(gameObject.transform.position, stats["Range"], boxLayerToHit);
        foreach (var enemies in enemyCollider)
        {
            if (enemies.gameObject.GetComponent<IreturnIndexNum>().returnOuterProtLayer() > hpHighest)
            {
                hpHighest = enemies.gameObject.GetComponent<IreturnIndexNum>().returnOuterProtLayer();
                strongestEnemy = enemies.gameObject;
            }
            else if (enemies.gameObject.GetComponent<IreturnIndexNum>().returnOuterProtLayer() == hpHighest)
            {

                if (enemies.gameObject.GetComponent<IreturnIndexNum>().returnBoxLayer() > layerHighest)
                {
                    layerHighest = enemies.gameObject.GetComponent<IreturnIndexNum>().returnBoxLayer();
                    strongestEnemy = enemies.gameObject;

                }

            }

        }
        Debug.Log(strongestEnemy);
        if (strongestEnemy != null)
        {
            attackEnemy(strongestEnemy);
            yield return new WaitForSeconds(stats["FireRate"]);
        }
        else if (strongestEnemy == null)
        {
            yield return new WaitUntil(enemyInRange);
        }
        StartCoroutine(targgetingList[targettingNum].Invoke());
    }
    //Milestone 7
    protected IEnumerator randomTargettign() {
        Collider[] enemyCollider = Physics.OverlapSphere(gameObject.transform.position, stats["Range"], boxLayerToHit);
        float randoNUM = UnityEngine.Random.Range(0, (float)(enemyCollider.Count() - 1));


        if (enemyCollider.Length != 0)
        {
            attackEnemy(enemyCollider[(int)randoNUM].gameObject);
            yield return new WaitForSeconds(stats["FireRate"]);
        }
        else if (enemyCollider.Length == 0)
        {
            yield return new WaitUntil(enemyInRange);
        }
        StartCoroutine(targgetingList[targettingNum].Invoke());


    }
    protected void changeTarget(int change)
    {
        if (targettingNum + change >= 5)
        {
            targettingNum = 0;
        }
        else if (targettingNum + change <= -1)
        {
            targettingNum = 4;
        }
        else
        {
            targettingNum += change;
        }
        updateTargetGUI();
    }
    protected virtual void attackEnemy(GameObject closestEnemy)
    {
        gameObject.transform.LookAt(closestEnemy.transform);
        Vector3 projctileSpawn = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
        GameObject proj = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(projctilePath + projctile + ".prefab");
        GameObject projctileGO = Instantiate(proj, projctileSpawn, Quaternion.Euler(gameObject.transform.eulerAngles.x + 90, gameObject.transform.eulerAngles.y, 0));
        projctileGO.GetComponent<IStatChange>().statChangePierce(stats["pierce"]);
        projctileGO.GetComponent<IStatChange>().statChangeProjSpeed(stats["ProjctileSpeed"]);
        projctileGO.GetComponent<IGiveEnemy>().setEnemy(closestEnemy);
        projctileGO.GetComponent<IProjctileOwner>().setProjectileOwner(gameObject);
        projctileGO.GetComponent<IGiveProptieres>().getParentLayerMask(boxLayerToHit);
    }
    bool enemyInRange()
    {
        //milestone 7 layer mask
        Collider[] enemyCollider = Physics.OverlapSphere(gameObject.transform.position, stats["Range"], boxLayerToHit);
        if (enemyCollider.Length != 0)
        {
            return true;
        }
        return false;
    }
    protected void changeModel()
    {
        string modelName = string.Empty;
        foreach (var pTT in pathToTier)
        {
            modelName = modelName + pTT.Value.ToString();
        }
        foreach (Transform h in gameObject.transform)
        {
            if (h.gameObject.name == "RangeCircleThing(Clone)")
            {
                continue;
            }
            Destroy(h.gameObject);
        }
        string modelPath = "Assets/Resources/DartMonkey/" + modelName + ".prefab";
        GameObject newModelPrefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(modelPath);
        GameObject newModel = Instantiate(newModelPrefab, gameObject.transform.position, Quaternion.identity);
        newModel.transform.parent = gameObject.transform;
        newModel.GetComponent<BoxCollider>().enabled = false;
        rangeC.transform.parent = null;
        rangeC.transform.localScale = new Vector3(stats["Range"] * 2, .0001f, stats["Range"] * 2);
        rangeC.transform.parent = gameObject.transform;

    }
    //milestone 7
    protected virtual void towerUpgrade(string upgradeTier, string projectile, Dictionary<string, float> statsUpgrade, bool hiddenDec)
    {

        foreach (var statBuff in statsUpgrade)
        {
            stats[statBuff.Key] *= statBuff.Value;
        }
        if (projectile != "")
        {
            projctile = projectile;
        }
        if (hiddenDec)
        {
            boxLayerToHit = (1 << 9 | 1 << 11);
        }
        pathToTier[upgradeTier] += 1;
        updateGUI();
        changeModel();
    }


    protected void updateGUI()
    {
        //holy mircale I manage to do a simple intergration of my check for bloacked path and addmax paths code
        //stores each GUI string name to whether they are top mid or bo
        //then loop through the dicionatry to update thes(later this would include the GUI next to the upgrade button.
        //var is a entry of the dictionary
        Dictionary<string, string> tiersOnEachPath = new Dictionary<string, string>();
        tiersOnEachPath.Add("top", (pathToTier["top"] + 1) + "00");
        tiersOnEachPath.Add("mid", "0" + (pathToTier["mid"] + 1) + "0");
        tiersOnEachPath.Add("bot", "0" + "0" + (pathToTier["bot"] + 1));
        GameObject newPreFab = null;
        string blockedPath = checkForBlockedPaths();
        List<string> maxPaths = addmaxPaths();
        foreach (var h in tiersOnEachPath)
        {

            //newPreFab is the prefab in assest to replace the old GUI
            //childToDestroyGO(GO=gameobject) is old GUI to kill.
            //key is the name of the old GUI and key is the upgrade tier button to show

            if (h.Key == blockedPath)
            {
                newPreFab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(monkeyGeneralGUIPath + "pathClosed" + ".prefab");
            }
            else if (maxPaths.Contains(h.Key))
            {
                newPreFab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(monkeyGeneralGUIPath + "maxUp" + ".prefab");
            }
            else if ((h.Key != blockedPath) && !maxPaths.Contains(h.Key))
            {
                newPreFab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(monkeyGUIPath+towerName + h.Value + ".prefab");
            }
            //the 0th child is the frame containnig everything 
            GameObject childToDestroyGO = monkeyUI.transform.GetChild(0).gameObject.transform.Find(h.Key).gameObject;
            GameObject newGO = Instantiate(newPreFab, childToDestroyGO.transform.position, Quaternion.identity);
            GameObject popCountGO = monkeyUI.transform.Find("popCount").gameObject;
            newGO.transform.SetParent(monkeyUI.transform.GetChild(0).transform);
            newGO.gameObject.GetComponent<RectTransform>().localScale = childToDestroyGO.GetComponent<RectTransform>().localScale;
            newGO.name = h.Key;
            //milestone 7
            popCountGO.GetComponent<TextMeshProUGUI>().text = stats["popCount"].ToString();
            updateTargetGUI();
            Destroy(childToDestroyGO);
        }
    }
    protected void updateTargetGUI()
    {
        GameObject text = monkeyUI.transform.Find("curTarget").transform.gameObject;
        text.GetComponent<TextMeshProUGUI>().text = targettingListNames[targettingNum];
    }
    protected string checkForBlockedPaths()
    {

        bool restricted = false;
        string nonUpgradedPath = null;
        int upgradedPaths = 0;

        foreach (var pTT in pathToTier)
        {
            if (pTT.Value == 0)
            {
                nonUpgradedPath = pTT.Key;
            }
            else if (pTT.Value != 0)
            {

                upgradedPaths++;
                if (upgradedPaths == 2)
                {
                    restricted = true;
                }
            }
        }
        if (restricted)
        {

            return nonUpgradedPath;
        }
        return null;
    }
    protected List<string> addmaxPaths()
    {
        List<string> paths = new List<string>();
        string pathToBlock = null;
        bool restricted = false;
        foreach (var pTT in pathToTier)
        {
            if (pTT.Value >= 5)
            {
                restricted = true;
                paths.Add(pTT.Key);
            }
            else if (pTT.Value >= 3)
            {
                restricted = true;
                continue;
            }
            if (pTT.Value == 2)
            {
                pathToBlock = pTT.Key;
            }
        }
        if (restricted)
        {
            paths.Add(pathToBlock);
        }
        return paths;
    }




    protected void checkHovering(bool hovering)
    {
        if (!hovering)
        {
            gameObject.layer = LayerMask.NameToLayer("Tower");
            rangeC.SetActive(false);
            rangeC.GetComponent<Renderer>().material.color = new Color(255 / 255, 255 / 255, 255 / 255, 0.3f);
            gameObject.GetComponent<BoxCollider>().enabled = true;
            events.GainCash.Invoke(-price);
            Debug.Log(GameManager.instance.coins);
            StartCoroutine(targgetingList[targettingNum].Invoke());
        }
        else
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            rangeC.SetActive(true);
        }
    }
    public void damageDealt(int popCounts)
    {

        stats["popCount"] += popCounts;
        if (monkeyUI)
        {
            GameObject popText = monkeyUI.GetComponent<RectTransform>().Find("popCount").gameObject;
            popText.GetComponent<TextMeshProUGUI>().text = stats["popCount"].ToString();
        }
    }
    protected IEnumerator spawnattackCD()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(closestTargetting());
    }

    protected int findFirstChild(string name, GameObject objectToSearch)
    {
        int i = 0;
        foreach (Transform child in objectToSearch.transform)
        {

            if (child.name == name)
            {
                return i;
            }
            else
            {
                i++;
            }
        }
        i++;
        return -1;
    }
    public void hoveringState(bool hovering)
    {
        hoveringS = hovering;
        checkHovering(hovering);
    }
    public void towerSelected()
    {
        rangeC.SetActive(true);
        GameManager.instance.monkeyGUIActive = true;
        events.towerUpgrade.AddListener(towerUpgrade);
        events.destroyTower.AddListener(destroyTowere);
        GameObject genUI = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(monkeyGeneralGUIPath + "generalGUI" + ".prefab");
        monkeyUI = Instantiate(genUI);
        //upgradeGUI frame
        GameObject upgradeGUI = monkeyUI.transform.GetChild(0).gameObject;
        monkeyUI.gameObject.GetComponent<RectTransform>().Translate(1300, 610, 0);
        monkeyUI.transform.parent = GameObject.Find("Canvas").transform;
        updateGUI();
        
        monkeyUI.SetActive(true);
    }
    public void towerUnSelected()
    {
        events.destroyTower.RemoveListener(destroyTowere);
        events.towerUpgrade.RemoveListener(towerUpgrade);
        GameManager.instance.monkeyGUIActive = false;
        rangeC.SetActive(false);
        Destroy(monkeyUI);
    }

    public bool collidingwithOtherObject()
    {
        return colliding;
    }
    public void destroyTowere(string nub) {
        Destroy(monkeyUI);
        Destroy(gameObject);
    }
}




//IEnumerator closestTargetting()
//{
//    GameObject closestEnemy = null;
//    float tempRange = stats["Range"];

//    foreach (var keyValuePair in boxData.boxsesOnMap)
//    {
//        if (keyValuePair.Value != null)
//        {

//            float distance = Vector3.Magnitude(keyValuePair.Value.transform.position - transform.position);
//            if (distance <= tempRange)
//            {
//                closestEnemy = keyValuePair.Value;
//                tempRange = distance;
//            }
//        }
//    }
//    //transform.GetChild(4).position
//    if (closestEnemy != null)
//    {
//        gameObject.transform.LookAt(closestEnemy.transform);
//        Vector3 projctileSpawn = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
//        GameObject dartProj = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(projctilePath + projctile + ".prefab");
//        GameObject projctileGO = Instantiate(dartProj, projctileSpawn, Quaternion.identity);
//        projctileGO.GetComponent<dartProj>().setClosestEnemy(closestEnemy);
//        projctileGO.GetComponent<IProjctileOwner>().setProjectileOwner(gameObject);
//    }
//    else if (closestEnemy == null)
//    {
//        yield return new WaitUntil(enemyInRange);
//        StartCoroutine(attackEnemy());
//    }
//    yield return new WaitForSeconds(stats["FireRate"]);
//    StartCoroutine(attackEnemy());
//}