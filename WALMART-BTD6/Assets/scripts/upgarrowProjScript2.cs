using UnityEngine;

public class upgradedarrowProjctile : projectileParentForStraightLinearProj
{
    private void Awake()
    {
        pierce = 5;
        damage = 5;
        projSpeed = 2;
        canHitLead = false;
    }
}
