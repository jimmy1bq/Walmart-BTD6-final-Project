using UnityEngine;

public class critStrongestarrowProjctile : projectileParentForStraightLinearProj
{
    private void Awake()
    {
        pierce = 10;
        damage = 9000;
        projSpeed = 5;
        canHitLead = true;
    }
}
