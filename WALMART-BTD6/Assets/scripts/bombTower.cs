using System.Collections.Generic;
using UnityEngine;

public class bombTower : towersParent 
{
    [SerializeField] LayerMask enemyOnly;
    [SerializeField] GameObject rangeCirclePF;
    Vector3 castOrigin;

    private void Awake()
    {
        towerName = "bombShooter";
        projctile = "bomb";
        rangeCircle = rangeCirclePF;
        stats = new Dictionary<string, float>() {
          {"Range", 5},
          {"FireRate",3},
          {"ProjctileSpeed",1},
          {"AddtionalDamage",1},
          {"pierce",1},
          {"popCount",0}
       };
        pathToTier = new Dictionary<string, int>() {
            {"top",0},
            {"mid",0},
            {"bot",0}
       };
        Vector3 rangePos = placeTowerRangeCircle(gameObject);
        rangeC = Instantiate(rangeCircle, rangePos, Quaternion.identity);
        rangeC.transform.parent = null;
        rangeC.transform.localScale = new Vector3(stats["Range"] * 2, 0, stats["Range"] * 2);
        rangeC.transform.parent = gameObject.transform;
        rangeC.SetActive(false);
        price = 300;
    }
    
  

}
