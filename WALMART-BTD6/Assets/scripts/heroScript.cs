using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Collections;
using System.Linq;
using Unity.Mathematics;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;
using System.Threading.Tasks;
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
    int totalCost = 100;
    int cost = 100;
    int totalExp = 100;
    int currentExp = 0;
    int currentLevel = 0;
    bool camo = false;
    bool onGoingWave = false;

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
        events.waveOver.AddListener(onGoingWaveEvent);

    }
  
    protected override void updateGUI()
    {
        GameObject xpBar = monkeyUI.transform.Find("xpBar").gameObject;        
        GameObject textMesh = monkeyUI.transform.Find("UpgradeButton").gameObject;  
        xpBar.GetComponent<UnityEngine.UI.Slider>().value = currentExp / totalExp;
        if (currentLevel != 20)
        {
            textMesh.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Upgrade:" + cost;
            xpBar.transform.Find("xpbar").GetComponent<TextMeshProUGUI>().text = currentExp + "/" + totalExp.ToString();
        }
        else {
            textMesh.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "MAXLEVEL";
            xpBar.transform.Find("xpbar").GetComponent<TextMeshProUGUI>().text = "MAXLEVEL";
            monkeyUI.transform.Find("radarAbilityButton").gameObject.SetActive(true);
        }


    }
   
    public override void towerSelected()
    {
        rangeC.SetActive(true);
        
        events.destroyTower.AddListener(destroyTowere);
        events.heroUpgrade.AddListener(towerButtonUpgrade);
        events.abilityActivate.AddListener(towerButtonUpgrade);
        GameObject genUI = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(monkeyGeneralGUIPath + "generalHeroGUI" + ".prefab");
        monkeyUI = Instantiate(genUI);
        monkeyUI.gameObject.GetComponent<RectTransform>().Translate(1300, 610, 0);
        monkeyUI.transform.parent = GameObject.Find("Canvas").transform;  
        monkeyUI.SetActive(true);
        updateGUI();
        Debug.Log(monkeyUI);
    }

    public override void towerUnSelected()
    {
        Debug.Log(monkeyUI);
        events.destroyTower.RemoveListener(destroyTowere);
        events.heroUpgrade.RemoveListener(towerButtonUpgrade);
        events.abilityActivate.RemoveListener(towerButtonUpgrade);
        rangeC.SetActive(false);
      //  monkeyUI = FindAnyObjectByType<Canvas>().gameObject.transform.Find("generalHeroGUI(Clone)").gameObject;       
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
   void towerButtonUpgrade(int bunz) {

        if (GameManager.instance.coins >= cost) {
      
        currentExp = 0;
        
        events.GainCash.Invoke(-cost);
       
        towerUpgrade();
        
    }
}
    void towerUpgrade()
    {
        currentLevel += 1;
        totalExp += 100;

    

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
        else if (currentLevel >= 10 && currentLevel < 20)
        {
            buffs = new Dictionary<string, float> {
                    {"Range", 0.2f},
                    { "FireRate",-0.03f},
                    { "ProjctileSpeed",0f},
                    { "AddtionalDamage",0f},
                    { "pierce",0f}
             };
            totalBuffs["Range"] += 0.2f;
            totalBuffs["FireRate"] -= 0.03f;
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
            totalBuffs["Range"] += 0.15f;
            totalBuffs["FireRate"] -= 0.02f;
            camo = true;
            events.abilityActivate.AddListener(radarAbilityAcivated);
        }
     
        foreach (GameObject towers in buffedTowers)
        {
           
            if (towers != null)
            {
                //update the buffs 
                if (!camo) {towers.GetComponent<IbuffTower>().updateBuffTower(buffs,false);}
                if (camo) { towers.GetComponent<IbuffTower>().updateBuffTower(buffs, true);}
            }
        }
        if (monkeyUI != null)
        {
            cost = (1 - currentExp / totalExp) * totalCost * currentLevel;
            updateGUI();
        }

    }
    IEnumerator radarAbilityCD(int coolDown) {
        events.abilityActivate.RemoveListener(radarAbilityAcivated);
        for (int i=coolDown; i>0;i--) {
            if (onGoingWave)
            {
                yield return new WaitForSeconds(1f);
                if (monkeyUI != null) {
                    monkeyUI.transform.Find("radarAbilityButton").GetChild(0).GetComponent<TextMeshProUGUI>().text = i.ToString();                
                }
            }
            else {
                yield return new WaitUntil(checkForOngoingWave);            
            }        
        }
        events.abilityActivate.AddListener(radarAbilityAcivated);
    }
    void radarAbilityAcivated(int yesorno) { 
    
    
    }
    bool checkForOngoingWave() {
        if (onGoingWave)
        {
            return true;
        }
        return false;
    }

    //checks for any unbuffed towers then buff them
    IEnumerator buffFriendlies()
    {
        Collider[] friendlies = Physics.OverlapSphere(transform.position, stats["Range"], 1 << 8);
        foreach (Collider friendly in friendlies)
        {
           
            if (!(buffedTowers.Contains(friendly.gameObject)) && friendly.gameObject.tag!="Base" && gameObject.GetComponent<IbuffTower>() != null)
            {
              
                    if (!camo) { friendly.gameObject.GetComponent<IbuffTower>().buffTower(totalBuffs,false);}
                    if (camo) { friendly.gameObject.GetComponent<IbuffTower>().buffTower(totalBuffs, true); }
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
    //if wave is over==false else started = true
    void waveOvers(bool buh) {
        if (!buh)
        {
            currentExp += 10;

            if (currentExp >= totalExp)
            {
                currentExp -= totalExp;
                towerUpgrade();
            }
            else if (monkeyUI != null)
            {
                updateGUI();
            }
            cost = (1 - currentExp / totalExp) * totalCost * currentLevel;
        }
    }
    void onGoingWaveEvent(bool onGoing) { 
    onGoingWave=onGoing;
    }
}
