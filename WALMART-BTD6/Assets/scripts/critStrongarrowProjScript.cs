using UnityEngine;

public class critStrongestarrowProjctile : projectileParentForStraightLinearProj
{
    private void Awake()
    {
        Debug.Log("CRIT2");
        pierce = 80;
        damage = 9;
        projSpeed = 5;
        canHitLead = true;
    }
}
