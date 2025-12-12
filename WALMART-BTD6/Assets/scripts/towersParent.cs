using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.Mathematics;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SocialPlatforms;


public class towersParent : MonoBehaviour, IHovering, IUNORSelected, IPopToPopCount, ICollidingWithTowers,IDamageTaken, IbuffTower
{

    //for targetting I probabley should I used a swtich statment since I already have the string
    [SerializeField] protected LayerMask enemy;
    protected enum gameMode {regular , alternate }

    #region FilePathWays
    protected string monkeyModelPath = "Assets/Resources/DartMonkey/";
    protected string monkeyGeneralGUIPath = "Assets/Resources/towerGUI/";
    protected string monkeyGUIPath = "Assets/Resources/towerGUI/";
    protected string projctilePath = "Assets/Resources/Projectile/";
    #endregion

   

    [SerializeField] protected GameObject monkeyUI;
    protected string towerName;
    protected GameObject rangeC;
    protected GameObject rangeCircle;
    protected string projctile;
    protected bool colliding;
    protected bool hiddenDec;
    protected bool beenBuffed = false;
   
    protected LayerMask boxLayerToHit = 1 << 9;
    protected LayerMask oldBoxLayerToHit;

    protected int testID = 0;
    protected int price;
    protected int targettingNum;
    protected int hp;

    protected Dictionary<string, int> pathToTier;
    protected Dictionary<string, float> stats = new Dictionary<string, float>();
    protected Dictionary<string, float> oldStats = new Dictionary<string, float>();

    public delegate IEnumerator TargettingDelegate();

    bool hoveringS = false;

    protected List<TargettingDelegate> targgetingList = new List<TargettingDelegate>();
    protected List<string> targettingListNames = new List<string> { "first", "closest", "last", "strongest", "random" };

    protected gameMode currentGM;
    protected void Start()
    {
       
        //turn them into "function" so you don't lose the coroutine when you call it for the first time
   
        oldBoxLayerToHit = boxLayerToHit;

        //credits to cluade for telling me to do ()=> instead of just putting in the function(the reason was Im storing an Ienumrator type and once its called the functoin go bye bye. So thats why I need to do ()=> to store it as a function)
        //yes before you ask switch cases would of worked better and cleaner.
        targgetingList.Add(() => firstTargetting());
        targgetingList.Add(() => closestTargetting());
        targgetingList.Add(() => lastTargettign());
        targgetingList.Add(() => strongestTargettign());
        targgetingList.Add(() => randomTargettign());
        oldStats = new Dictionary<string, float>(stats);
        if (GameObject.Find("Base") != null) { 
        currentGM  = gameMode.alternate;
       
        }

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
    //checks for collision with other tower or objects
    protected bool checkForCollisionWithTower()
    {
        Collider[] colliders = Physics.OverlapBox(gameObject.transform.position, new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z) * .75f, quaternion.identity, (1 << 8 | 1 << 10));
        if (colliders.Length > 0)
        {
          
            return true;
        }
        return false;
    }

    protected Vector3 placeTowerRangeCircle(GameObject tower)
    {
        Vector3 rangePos = new Vector3(tower.transform.position.x, tower.transform.position.y, tower.transform.position.z) + new Vector3(0, 0.01f, 0);
        return rangePos;
    }
    #region targetting
    protected IEnumerator closestTargetting()
    {
        GameObject closestEnemy = null;
      
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
      
        StartCoroutine(targgetingList[targettingNum].Invoke());

    }
   
    //first targetting or switch case closest to base
    protected IEnumerator firstTargetting()
    {
        GameObject firstEnemy = null;
        float distance = 99999f;
        int indexHighest = 0;
        Collider[] enemyCollider = Physics.OverlapSphere(gameObject.transform.position, stats["Range"], boxLayerToHit);
        switch (currentGM) {
            case gameMode.regular:
                foreach (var enemies in enemyCollider)
                {
                    IreturnIndexNum ei = enemies.gameObject.GetComponent<IreturnIndexNum>();

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

                            firstEnemy = enemies.gameObject;
                            distance = enemies.gameObject.GetComponent<IreturnIndexNum>().returnDistanceFromWayPoint();
                        }
                    }
                }
                break;

            case gameMode.alternate:
                  float oldDistance = distance;
                    foreach (var enemies in enemyCollider)
                    {
                     distance = Vector3.Magnitude(GameObject.Find("Base").transform.position - enemies.transform.position);
                    if (distance < oldDistance) { 
                        oldDistance = distance;
                        firstEnemy = enemies.gameObject;
                    }
                }
                    break;        
        }
      
        if (firstEnemy != null)
        {  
            attackEnemy(firstEnemy);
            yield return new WaitForSeconds(stats["FireRate"]);
        }
        else { yield return new WaitUntil(enemyInRange); }
        StartCoroutine(targgetingList[targettingNum].Invoke());
    }

    //milestone 7
    //last targetting=furthest
    protected IEnumerator lastTargettign()
    {
        GameObject lastEnemy = null;
        float distance = 0f;
        int indexLowest = 0;
        Collider[] enemyCollider = Physics.OverlapSphere(gameObject.transform.position, stats["Range"], boxLayerToHit);
        switch (currentGM) { 
        case gameMode.regular:
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
                break;
        case gameMode.alternate:
                float oldDistance = distance;
                foreach (var enemies in enemyCollider)
                {
                    distance = Vector3.Magnitude(GameObject.Find("Base").transform.position - enemies.transform.position);
                    if (distance > oldDistance)
                    {
                        oldDistance = distance;
                        lastEnemy = enemies.gameObject;
                    }
                }
                break;
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
    #endregion
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
    #region upgrade tower logic section
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
        string modelPath = "Assets/Resources/"+towerName + modelName + ".prefab";
        GameObject newModelPrefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(modelPath);
        GameObject newModel = Instantiate(newModelPrefab, gameObject.transform.position, Quaternion.identity);
        newModel.transform.parent = gameObject.transform;
        newModel.GetComponent<BoxCollider>().enabled = false;    
        rangeC.transform.parent = null;
        rangeC.transform.localScale = new Vector3(stats["Range"] * 2, .0001f, stats["Range"] * 2);
        rangeC.transform.parent = gameObject.transform;

    }
   
    protected virtual void towerUpgrade(string upgradeTier, string projectile, Dictionary<string, float> statsUpgrade, bool hiddenDec)
    {

        foreach (var statBuff in statsUpgrade)
        {
           
            float buffValue= oldStats[statBuff.Key] * statBuff.Value - oldStats[statBuff.Key];
            stats[statBuff.Key] += buffValue;
            Debug.Log(gameObject + ":" + stats[statBuff.Key]);
            oldStats[statBuff.Key] *= statBuff.Value;
            hp += (int)(statBuff.Value * 10);
        }
        if (projectile != "")
        {
            if (!checkForThirdTiers() || pathToTier[upgradeTier] >=3) { projctile = projectile; }          
        }
        if (hiddenDec)
        {         
            boxLayerToHit = (1 << 9 | 1 << 11);
            oldBoxLayerToHit = boxLayerToHit;
        }
        pathToTier[upgradeTier] += 1;
        updateGUI();
        changeModel();
    }

    bool checkForThirdTiers() { 
    foreach(var pTT in pathToTier) {
            if (pTT.Value >=3) {
                return true;
            }
        }
        return false;
    }
    //credits to cluade for helping me debug this annyoing bug(the bug was somehow updateTargetGUI being in the loop breaking the GUIS)
    protected virtual void updateGUI()
    {
       
        Dictionary<string, string> tiersOnEachPath = new Dictionary<string, string>();
        tiersOnEachPath.Add("top", (pathToTier["top"] + 1) + "00");
        tiersOnEachPath.Add("mid", "0" + (pathToTier["mid"] + 1) + "0");
        tiersOnEachPath.Add("bot", "0" + "0" + (pathToTier["bot"] + 1));
        GameObject newPreFab = null;
        string blockedPath = checkForBlockedPaths();
        List<string> maxPaths = addmaxPaths();
        List<GameObject> childernsTODestroy = new List<GameObject>();
        foreach (var h in tiersOnEachPath)
        {
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
                newPreFab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(monkeyGUIPath + towerName + h.Value + ".prefab");
                
            }
           

            GameObject childToDestroyGO = monkeyUI.transform.Find("upgradeGUI").gameObject.transform.Find(h.Key).gameObject;
            childernsTODestroy.Add(childToDestroyGO);
            GameObject newGO = Instantiate(newPreFab, childToDestroyGO.transform.position, Quaternion.identity);
          
            GameObject popCountGO = monkeyUI.transform.Find("popCount").gameObject;
            newGO.transform.SetParent(monkeyUI.transform.GetChild(0).transform);
            newGO.gameObject.GetComponent<RectTransform>().localScale = childToDestroyGO.GetComponent<RectTransform>().localScale;
            newGO.name = h.Key;           
            popCountGO.GetComponent<TextMeshProUGUI>().text = stats["popCount"].ToString();     
        }
        foreach (GameObject h in childernsTODestroy) {
            Destroy(h);
        }
        updateTargetGUI();
    }
    protected void updateTargetGUI()
    {
        Debug.Log(transform.position);
        GameObject text = null;
       
        text = monkeyUI.transform.Find("curTarget").gameObject;
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
    #endregion



   
    protected virtual void checkHovering(bool hovering)
    {
        if (!hovering)
        {
            gameObject.layer = LayerMask.NameToLayer("Tower");
            rangeC.SetActive(false);
            rangeC.GetComponent<Renderer>().material.color = new Color(255 / 255, 255 / 255, 255 / 255, 0.3f);
            gameObject.GetComponent<BoxCollider>().enabled = true;
            events.GainCash.Invoke(-price);
           
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
  
    public void hoveringState(bool hovering)
    {
        hoveringS = hovering;
        checkHovering(hovering);
    }
    //in reflection im never hardcording values in because it jsut makes inhertinace pain the in the butt to work with
    public virtual void towerSelected()
    {
       
        rangeC.SetActive(true);
        events.changeTarget.AddListener(changeTarget);
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
    public virtual void towerUnSelected()
    {
        events.changeTarget.RemoveListener(changeTarget);
        events.destroyTower.RemoveListener(destroyTowere);
        events.towerUpgrade.RemoveListener(towerUpgrade);
        Debug.Log("removed");
        rangeC.SetActive(false);
        monkeyUI = FindAnyObjectByType<Canvas>().gameObject.transform.Find("generalGUI(Clone)").gameObject;
        
        Destroy(monkeyUI);
    }

    public bool collidingwithOtherObject()
    {
        return colliding;
    }
    public virtual void destroyTowere(string nub) {
        Destroy(monkeyUI);
        Destroy(gameObject);
    }

    public void damageTaken(int damageAmount, GameObject balloonDamage)
    {       
        hp -= damageAmount;

        if (hp <= 0) {
          
            Destroy(monkeyUI);
            Destroy(gameObject);
        }
    }
    
    public void buffTower(Dictionary<string,float> buffs, bool camo)
    {
        
        if (beenBuffed == false)
        {
            if (camo)
            {
                boxLayerToHit = 1 << 9 | 1 << 11;
            }
            foreach (var buff in buffs)
            {
                stats[buff.Key] += buff.Value;
            }
        }
        rangeC.transform.parent = null;
        rangeC.transform.localScale = new Vector3(stats["Range"] * 2, .0001f, stats["Range"] * 2);
        rangeC.transform.parent = gameObject.transform;
        
    }
    public void updateBuffTower(Dictionary<string, float> buff, bool camo)
    {

        if (camo)
        {
            boxLayerToHit = 1 << 9 | 1 << 11;
        }
            foreach (var buffs in buff)
            {
                stats[buffs.Key] += buffs.Value;

            }
        rangeC.transform.parent = null;
        rangeC.transform.localScale = new Vector3(stats["Range"] * 2, .0001f, stats["Range"] * 2);
        rangeC.transform.parent = gameObject.transform;
        Debug.Log("HI");
    }

    public void removeBuffTower()
    {
        Debug.Log(oldStats["Range"]);
        stats = new Dictionary<string, float>(oldStats);
        rangeC.transform.parent = null;
        rangeC.transform.localScale = new Vector3(stats["Range"] * 2, .0001f, stats["Range"] * 2);
        rangeC.transform.parent = gameObject.transform;
        boxLayerToHit = oldBoxLayerToHit;
        
    } 
}




