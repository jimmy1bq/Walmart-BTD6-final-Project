using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Collections;
using System.Linq;
using Unity.Mathematics;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;
public class heroScript : towersParent
{
    [SerializeField] GameObject rangeCirclePF;
    //totalBuff so incase if the tower gets destroyed we can just subtract the float to decrease their stat back to normal
    Dictionary<string, float> totalBuffs = new Dictionary<string, float> {
                    {"Range", .1f},
                    { "FireRate",-0.01f},
                    { "ProjctileSpeed",0f},
                    { "AddtionalDamage",0f},
                    { "pierce",0f}
             };
    Dictionary<string, float> buffs = new Dictionary<string, float> {
                    {"Range", .1f},
                    { "FireRate",-0.01f},
                    { "ProjctileSpeed",0f},
                    { "AddtionalDamage",0f},
                    { "pierce",0f}
             };
    List<GameObject> buffedTowers = new List<GameObject>();

    int cost = 100;
    int totalExp = 100;
    int currentExp = 0;
    int currentLevel = 0;
    bool camo = false;

    private void Awake()
    {
        rangeCircle = rangeCirclePF;
        stats = new Dictionary<string, float>() {
          {"Range", 14},
          {"FireRate",0},
          {"ProjctileSpeed",0},
          {"AddtionalDamage",0},
          {"pierce",0},
          {"popCount",0}
       };
        hp = 10;
        Vector3 rangePos = placeTowerRangeCircle(gameObject);
        rangeC = Instantiate(rangeCircle, rangePos, Quaternion.identity);
        rangeC.transform.parent = null;
        rangeC.transform.localScale = new Vector3(stats["Range"] * 2, 0, stats["Range"] * 2);
        rangeC.transform.parent = gameObject.transform;
        rangeC.SetActive(false);
        price = 500;
        events.waveOver.AddListener(waveOvers);
    }
  
    protected override void updateGUI()
    {
        GameObject textMesh = monkeyUI.transform.Find("xpBar").gameObject;
        textMesh.GetComponent<Slider>().value = currentExp / totalExp;
        textMesh.transform.Find("xpbar").GetComponent<TextMeshProUGUI>().text =currentExp + "/" + totalExp.ToString();

    }
    public override void towerSelected()
    {
        rangeC.SetActive(true);
        GameManager.instance.monkeyGUIActive = true;
        events.towerUpgrade.AddListener(towerUpgrade);
        events.destroyTower.AddListener(destroyTowere);
        Debug.Log("hi");
        GameObject genUI = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(monkeyGeneralGUIPath + "generalHeroGUI" + ".prefab");

        monkeyUI = Instantiate(genUI);
        monkeyUI.gameObject.GetComponent<RectTransform>().Translate(1300, 610, 0);
        monkeyUI.transform.parent = GameObject.Find("Canvas").transform;
        updateGUI();

        monkeyUI.SetActive(true);
    }
    public override void towerUnSelected()
    {
        events.destroyTower.RemoveListener(destroyTowere);
        events.towerUpgrade.RemoveListener(towerUpgrade);
        GameManager.instance.monkeyGUIActive = false;
        rangeC.SetActive(false);
        monkeyUI = FindAnyObjectByType<Canvas>().gameObject.transform.Find(" generalHeroGUI(Clone)").gameObject;
        Debug.Log(monkeyUI);
        Destroy(monkeyUI);
    }

    protected override void checkHovering(bool hovering)
    {
        if (!hovering)
        {
            gameObject.layer = LayerMask.NameToLayer("Tower");
            rangeC.SetActive(false);
            rangeC.GetComponent<Renderer>().material.color = new Color(255 / 255, 255 / 255, 255 / 255, 0.3f);
            gameObject.GetComponent<BoxCollider>().enabled = true;
            StartCoroutine(buffFriendlies());
            events.GainCash.Invoke(-price);
        }
        else
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            rangeC.SetActive(true);
        }
    }
    public void towerButtonUpgrade()
    {
        if (GameManager.instance.coins >= cost)
        {
            towerUpgrade();
        }
    }
    void towerUpgrade()
    {
        if (currentLevel < 10)
        {
            buffs = new Dictionary<string, float> {
                    {"Range", 0.1f},
                    { "FireRate",-0.01f},
                    { "ProjctileSpeed",0f},
                    { "AddtionalDamage",0f},
                    { "pierce",0f}
             };
            totalBuffs["Range"] += 0.10f;
            totalBuffs["FireRate"] -= 0.01f;
        }
        else if (currentLevel > 10 && currentLevel < 20)
        {
            buffs = new Dictionary<string, float> {
                    {"Range", 0.2f},
                    { "FireRate",-0.03f},
                    { "ProjctileSpeed",0f},
                    { "AddtionalDamage",0f},
                    { "pierce",0f}
             };
            totalBuffs["Range"] -= 0.2f;
            totalBuffs["FireRate"] += 0.03f;
            camo = true;
        }
        else if (currentLevel == 20)
        {
            buffs = new Dictionary<string, float> {
                    {"Range", 0.15f},
                    { "FireRate",-0.02f},
                    { "ProjctileSpeed",0f},
                    { "AddtionalDamage",0f},
                    { "pierce",0f}
             };
            totalBuffs["Range"] -= 0.15f;
            totalBuffs["FireRate"] += 0.02f;
            camo = true;
            //gain ability

        }
        foreach (GameObject towers in buffedTowers)
        {
            if (towers != null)
            {
                if (!camo) {towers.GetComponent<IbuffTower>().updateBuffTower(buffs,1<<8);}
                if (camo) { towers.GetComponent<IbuffTower>().updateBuffTower(buffs, (1 << 8 | 1 << 9));}
            }
        }
    }

    IEnumerator buffFriendlies()
    {
        Collider[] friendlies = Physics.OverlapSphere(transform.position, stats["Range"], 1 << 8);
        foreach (Collider friendly in friendlies)
        {
            Debug.Log(friendly.gameObject);           
            if (!(buffedTowers.Contains(friendly.gameObject)) && friendly.gameObject.tag!="Base" && gameObject.GetComponent<IbuffTower>() != null)
            {       
                    if (!camo) { friendly.gameObject.GetComponent<IbuffTower>().buffTower(totalBuffs, 1 << 8);}
                    if (camo) { friendly.gameObject.GetComponent<IbuffTower>().buffTower(totalBuffs, (1 << 8 | 1 << 9)); }
                    buffedTowers.Add(friendly.gameObject);                
            }
        }
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(buffFriendlies());
    }
    public override void destroyTowere(string nub)
    {
        foreach (GameObject h in buffedTowers)
        {
            if (h != null)
            {
                h.GetComponent<IbuffTower>().removeBuffTower();
            }
        }
        Destroy(monkeyUI);
        Destroy(gameObject);
    }
    void waveOvers(int buh) {
        currentExp += 100;
        if (currentExp >= totalExp) {
            currentExp -= totalExp;
            currentLevel += 1;
            towerUpgrade();
            cost += 100;
        }
        if (monkeyUI != null) {
            updateGUI();
        }

    
    }
}
