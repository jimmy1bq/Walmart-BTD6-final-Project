using UnityEngine;

public class critStrongestarrowProjctile : projectileParentForStraightLinearProj
{
    private void Awake()
    {
        pierce = 10;
        damage = 90;
        projSpeed = 5;
        canHitLead = true;
    }
}
