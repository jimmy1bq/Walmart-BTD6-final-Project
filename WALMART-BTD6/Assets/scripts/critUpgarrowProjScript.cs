using UnityEngine;

public class critUpgradedarrowProjctile : projectileParentForStraightLinearProj
{
    private void Awake()
    {
        Debug.Log("CRIT");
        pierce = 5;
        damage = 50;
        projSpeed = 2;
        canHitLead = false;
    }
}
