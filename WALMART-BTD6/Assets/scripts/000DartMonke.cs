using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

public class DartMonke : towersParent, IHovering, IUNORSelected, IPopToPopCount
{
    [SerializeField] projectileSO projctileData;
    [SerializeField] boxSO boxData;

    [SerializeField] GameObject dMtowerUI;
    [SerializeField] GameObject rangeCircle;

    [SerializeField] LayerMask enemyOnly;

    [SerializeField] int fireRate;


    float range = 5;
    int popCount;
    string upgrades = "000";
    
    bool hoveringS;
    GameObject monkeyUI;
    GameObject rangeC;
    Vector3 castOrigin;

  

    private void Awake()
    {
       
        Vector3 rangePos = placeTowerRangeCircle(gameObject);
        rangeC = Instantiate(rangeCircle, rangePos, Quaternion.identity);
        rangeC.transform.parent = gameObject.transform;
        rangeC.SetActive(false);

    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }
    //changed this to not use SOs anymore milestone 4
    // spherecast to check enemy in range if theres no enemy in range we can use the corotine to wait until there is one and insta attack the enemy
    //why use corotuine instead of update? because its cleaner so there isn't a gaint block of code. 
    //as of right now corotuine only serves as a better way to yield a functoin.
    IEnumerator attackEnemy() {
            GameObject closestEnemy = null;
            range = 5;

            foreach (var keyValuePair in boxData.boxsesOnMap)
            {
                if (keyValuePair.Value != null)
                {

                    float distance = Vector3.Magnitude(keyValuePair.Value.transform.position - transform.position);
                    if (distance <= range)
                    {
                        closestEnemy = keyValuePair.Value;
                        range = distance;
                    }
                }
            }
            //transform.GetChild(4).position
            if (closestEnemy != null)
            {
                //   Debug.Log("Throw");
                gameObject.transform.LookAt(closestEnemy.transform);
                Vector3 projctileSpawn = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
                //   Debug.Log(projctileData.dartProjctile);
                GameObject dart = Instantiate(projctileData.dartProjctile, projctileSpawn, transform.GetChild(4).rotation);
                dart.GetComponent<dartProj>().setClosestEnemy(closestEnemy);
                dart.GetComponent<IProjctileOwner>().setProjectileOwner(gameObject);
            }
            else if (closestEnemy == null)
            {
                //if theres no enemy in range waait until theres one in range
                yield return new WaitUntil(enemyInRange);
                StartCoroutine(attackEnemy());
            }
            yield return new WaitForSeconds(fireRate);
            StartCoroutine(attackEnemy());       
    }

    IEnumerator spawnattackCD()
    {
       yield return new WaitForSeconds(1);
       StartCoroutine(attackEnemy());
    }
    //milestone 4 
    //changed this to be much more cleaner and better. 
    //Also no more reliance on SOs. 
    //the nested if statment is to check if the hit acutally hit something
    bool enemyInRange()
    {
        foreach (var keyValuePair in boxData.boxsesOnMap)
        {
            if (keyValuePair.Value != null)
            {
                float distance = Vector3.Magnitude(keyValuePair.Value.transform.position - transform.position);
                if (distance <= range) { return true; }
            }
        }
        return false;
    }
    /// <summary>
    /// If the tower is hovering show the range cicrle and if its not diisable the range circle and start the attack coroutine
    /// </summary>
    /// <param name="hovering">bool whether is the tower is selected and hovering over the mouse for placement </param>
    public void hoveringState(bool hovering)
    {
        hoveringS = hovering;
        checkHovering(hovering);
    }
    //changed added layer change remember to record this on milestone 4
    void checkHovering(bool hovering) {
        if (!hovering)
        {
            gameObject.layer = LayerMask.NameToLayer("Tower");
            rangeC.SetActive(false);
            Debug.Log("Starting Attack Coroutine");
            StartCoroutine(spawnattackCD());
        }
        else
        {
            rangeC.SetActive(true);
        }
    }
    /// <summary>
    /// Interface method for when the tower is selected
    /// </summary>
    public void towerSelected() { 
        rangeC.SetActive(true);

        events.towerUpgrade.AddListener(towerUpgrade);
        monkeyUI = Instantiate(dMtowerUI);
        GameObject upgradeGUI = monkeyUI.transform.GetChild(0).gameObject;
        monkeyUI.gameObject.GetComponent<RectTransform>().Translate(965,550, 0);
        monkeyUI.transform.parent = GameObject.Find("Canvas").transform;
        if (pathBlocked(upgrades) != 0)
        {
        //if theres a blocked path then instead of having the upgrade button on that path destroy the object and replace it with a imahge of blockpath
            GameObject blockPath = upgradeGUI.transform.GetChild(pathBlocked(upgrades)).gameObject;
            Vector3 ogPos = blockPath.transform.position;
            Destroy(blockPath);
          // Instantiate the  block path and the other 2 upgrade GUI by taking the monkeys cross path
          //  Instantiate(blockPathGUI,ogPos,Quaternion.identity);
            
        }
        //elseif theres no blocked path then instantaite the 3 path
        monkeyUI.SetActive(true);
    }
    int pathBlocked(string crossPath) {
        string firstPath = crossPath.Substring(0);
        string secondPath = crossPath.Substring(1);
        string thirdPath = crossPath.Substring(3);
   
        if ((firstPath == "0" && secondPath == "0") || (firstPath == "0" && thirdPath == "0") || (thirdPath == "0" && secondPath == "0")) {
            return 0;
        } else {
            if (firstPath == "0")
            {
                return 3;
            }
            else if (secondPath == "0") 
            {
                return 4;
            }
            else if (thirdPath == "0")
            {
                return 5;
            }
        }
        return 0;
    }
    public void towerUnSelected() {
        events.towerUpgrade.RemoveListener(towerUpgrade);
        rangeC.SetActive(false);
        Destroy(monkeyUI);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="popCounts">Recevies a damage(int) from the projctile it shot</param>
    public void damageDealt(int popCounts)
    {
        popCount += popCounts;

        if (monkeyUI) {
          GameObject popText= monkeyUI.GetComponent<RectTransform>().GetChild(findFirstChild("popCount", monkeyUI)).gameObject;
          popText.GetComponent<TextMeshProUGUI>().text = popCounts.ToString();
        }
    }
    int findFirstChild(string name, GameObject objectToSearch)
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
    private void OnDrawGizmosSelected()
    {
        Vector3 castOrigin = gameObject.transform.position + new Vector3(0, 0.8f, 0);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(castOrigin, range);
    }
    //since unity doesn't like front 0s im replacing it with a 9
    void towerUpgrade(string upgradeNum) {

    }
}
//unused code incase I somehow need it again
//also comparsion code to before
//IEnumerator attackEnemy()
//{
//    GameObject closestEnemy = null;
//    range = 5;

//    foreach (var keyValuePair in boxData.boxsesOnMap)
//    {
//        if (keyValuePair.Value != null)
//        {

//            float distance = Vector3.Magnitude(keyValuePair.Value.transform.position - transform.position);
//            if (distance <= range)
//            {
//                closestEnemy = keyValuePair.Value;
//                range = distance;
//            }
//        }
//    }
//    //transform.GetChild(4).position
//    if (closestEnemy != null)
//    {
//        //   Debug.Log("Throw");
//        gameObject.transform.LookAt(closestEnemy.transform);
//        Vector3 projctileSpawn = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
//        //   Debug.Log(projctileData.dartProjctile);
//        GameObject dart = Instantiate(projctileData.dartProjctile, projctileSpawn, transform.GetChild(4).rotation);
//        dart.GetComponent<dartProj>().setClosestEnemy(closestEnemy);
//        dart.GetComponent<IProjctileOwner>().setProjectileOwner(gameObject);
//    }
//    else if (closestEnemy == null)
//    {
//        //if theres no enemy in range waait until theres one in range
//        yield return new WaitUntil(enemyInRange);
//        StartCoroutine(attackEnemy());
//    }
//    yield return new WaitForSeconds(fireRate);
//    StartCoroutine(attackEnemy());
//}

//if (hits.Length != 0) {
//    foreach (RaycastHit objectHit in hits) { 
//        if(objectHit.collider.gameObject.tag == "enemy")
//        {
//            float distance = Vector3.Magnitude(objectHit.collider.gameObject.transform.position - transform.position);
//            if(distance <= range)
//            {
//                closestEnemy = objectHit.collider.gameObject;
//                range = distance;
//            }
//        }
//    }  
//}
//push
//bool enemyInRange() {
//foreach (var keyValuePair in boxData.boxsesOnMap)
//{
//    if (keyValuePair.Value != null)
//    {
//        float distance = Vector3.Magnitude(keyValuePair.Value.transform.position - transform.position);
//        if (distance <= range) { return true; }
//    }
//}
//  return false;
//   }


//}















//future targetting system:
//RaycastHit hit;
//range = 5;
//Vector3 castOrigin = gameObject.transform.position + new Vector3(0, 0.8f, 0);
//Debug.Log(Physics.SphereCast(castOrigin, range, transform.forward, out hit, 20f));
//if (Physics.SphereCast(castOrigin, range, transform.forward , out hit,20f)) {
//    Debug.Log("HI1");
//    Debug.Log(hit);
//    if (hit.collider.gameObject != null)
//    {
//        Vector3 projctileSpawn = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
//        GameObject dart = Instantiate(projctileData.dartProjctile, projctileSpawn, transform.GetChild(4).rotation);
//        gameObject.transform.LookAt(hit.collider.gameObject.transform);
//        dart.GetComponent<dartProj>().setClosestEnemy(hit.collider.gameObject);
//        dart.GetComponent<IProjctileOwner>().setProjectileOwner(gameObject);
//    }
//    else 
//    {
//        Debug.Log("HI2");
//        yield return new WaitUntil(enemyInRange); 
//        StartCoroutine(attackEnemy());
//    }
//}
//Debug.Log("HI4");
//yield return new WaitForSeconds(fireRate);
//StartCoroutine(attackEnemy());

//range = 5;
//RaycastHit hit;
//Vector3 castOrigin = gameObject.transform.position + new Vector3(0, 0.8f, 0);
//if (Physics.SphereCast(castOrigin, range, Vector3.forward, out hit))
//{
//    if (hit.collider.gameObject != null) { 
//        return true; 
//    }
//}
//return false;

//Grabs an asset by path.
//string modelPath = "Assets/Resources/DartMonkey/" + upgradeName;
//GameObject newModelPrefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(modelPath);
//Instantiate(newModelPrefab, gameObject.transform.position, Quaternion.identity);