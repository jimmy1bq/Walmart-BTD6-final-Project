using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class towersParent : MonoBehaviour, IHovering, IUNORSelected, IPopToPopCount
{
   
    protected string monkeyModelPath = "Assets/Resources/DartMonkey/";
    protected string monkeyGeneralGUIPath = "Assets/Resources/towerGUI/";
    protected string monkeyGUIPath = "Assets/Resources/towerGUI/dartMonkeyGUi/";

    protected GameObject monkeyUI;
    protected GameObject rangeC;
    protected GameObject projctile;
    protected GameObject dMtowerUI;


    protected Dictionary<string, int> pathToTier;
    protected Dictionary<string, int> stats;

    bool hoveringS;



    protected Vector3 placeTowerRangeCircle(GameObject tower)
    {
        Vector3 rangePos = new Vector3(tower.transform.position.x, tower.transform.position.y, tower.transform.position.z) + new Vector3(0, 0.01f, 0);
        return rangePos;
    }
    //doubley circular linked list 

    protected IEnumerator closestTargetting(GameObject projctile) { 


        yield return null;
    }
    protected void firstTargetting() { }
    protected void lastTargettign() { }
    protected void strongestTargettign() { }
    protected void weakestTargettign() { }
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
                Debug.Log(pTT.Key);
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
            if (restricted && pTT.Value >= 2)
            {
                paths.Add(pTT.Key);
            }
        }
        return paths;
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
                newPreFab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(monkeyGUIPath + h.Value + ".prefab");
            }
            //the 0th child is the frame containnig everything 
            GameObject childToDestroyGO = monkeyUI.transform.GetChild(0).gameObject.transform.Find(h.Key).gameObject;
            GameObject newGO = Instantiate(newPreFab, childToDestroyGO.transform.position, Quaternion.identity);
            newGO.transform.SetParent(monkeyUI.transform.GetChild(0).transform);
            newGO.gameObject.GetComponent<RectTransform>().localScale = childToDestroyGO.GetComponent<RectTransform>().localScale;
            newGO.name = h.Key;
            Destroy(childToDestroyGO);
        }
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
        monkeyUI = Instantiate(dMtowerUI);
        //upgradeGUI frame
        GameObject upgradeGUI = monkeyUI.transform.GetChild(0).gameObject;
        monkeyUI.gameObject.GetComponent<RectTransform>().Translate(2250, 1050, 0);
        monkeyUI.transform.parent = GameObject.Find("Canvas").transform;
        //Gets the unmodifded GUI to get swapped out later
        //if we were not to hardcode these value we can use unity's method findchild or use the findfirstchild method that i've created.
        //GameObject topPathGO = upgradeGUI.transform.GetChild(3).gameObject;
        //GameObject middlePathGO = upgradeGUI.transform.GetChild(4).gameObject;
        //GameObject bottomPathGO = upgradeGUI.transform.GetChild(5).gameObject;
        //I could store the blocked upgrade path beforehand in a variable avoid doing these checks everytime
        updateGUI();
        monkeyUI.SetActive(true);
    }
    protected void checkHovering(bool hovering)
    {
        if (!hovering)
        {
            gameObject.layer = LayerMask.NameToLayer("Tower");
            rangeC.SetActive(false);

            StartCoroutine(spawnattackCD());
        }
        else
        {
            rangeC.SetActive(true);
        }
    }
    public void damageDealt(int popCounts)
    {
        stats["popCount"] += popCounts;
        if (monkeyUI)
        {
            GameObject popText = monkeyUI.GetComponent<RectTransform>().GetChild(findFirstChild("popCount", monkeyUI)).gameObject;
            popText.GetComponent<TextMeshProUGUI>().text = popCounts.ToString();
        }
    }
    protected IEnumerator spawnattackCD()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(closestTargetting(projctile));
    }
    protected void towerUpgrade(string upgradeTier)
    {
        pathToTier[upgradeTier] += 1;
        updateGUI();
        changeModel();
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
    public void towerUnSelected()
    {
        events.towerUpgrade.RemoveListener(towerUpgrade);
        GameManager.instance.monkeyGUIActive = false;
        rangeC.SetActive(false);
        Destroy(monkeyUI);


    }
}
