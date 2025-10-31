using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DartMonke : towersParent, IHovering, IUNORSelected, IPopToPopCount
{
    [SerializeField] projectileSO projctileData;
    [SerializeField] boxSO boxData;

    [SerializeField] GameObject dMtowerUI;
    [SerializeField] GameObject rangeCircle;
    [SerializeField] int fireRate;

    float range = 5;
    int popCount;
    
    bool hoveringS = false;
    GameObject monkeyUI;
    GameObject rangeC;


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
    IEnumerator attackEnemy()
    {
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
    /// <summary>
    /// Use SphereCasting later
    /// </summary>
    /// <returns></returns>
    bool enemyInRange()
    {
        foreach (var keyValuePair in boxData.boxsesOnMap)
        {
            if (keyValuePair.Value != null)
            {
                float distance = Vector3.Magnitude(keyValuePair.Value.transform.position - transform.position);
                // Debug.Log("checking:"+ distance + ": " + keyValuePair  );

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
        if (rangeCircle != null)
        {
            checkHovering(hoveringS);
        }
        else if (rangeCircle == null)
        {
            checkHovering(hoveringS);
        }
    }
    void checkHovering(bool hovering) {
        if (!hovering)
        {
            rangeC.SetActive(false);
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
    monkeyUI = Instantiate(dMtowerUI);
    monkeyUI.gameObject.GetComponent<RectTransform>().Translate(965,550, 0);
    monkeyUI.transform.parent = GameObject.Find("Canvas").transform;
    monkeyUI.SetActive(true);
    }
    public void towerUnSelected() {
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
            findFirstChild("popCount", monkeyUI);  
        }
    }
    int findFirstChild(string name, GameObject objectToSearch)
    {
        int i = 0;
        foreach (Transform child in objectToSearch.transform)
        {
            Debug.Log(child.name == name);
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
}
