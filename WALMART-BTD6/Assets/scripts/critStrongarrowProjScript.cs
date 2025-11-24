using UnityEngine;

public class critStrongestarrowProjctile : projectileParentForStraightLinearProj
{
    private void Awake()
    {
        Debug.Log("CRIT2");
        pierce = 10;
        damage = 90;
        projSpeed = 5;
        canHitLead = true;
    }
}
