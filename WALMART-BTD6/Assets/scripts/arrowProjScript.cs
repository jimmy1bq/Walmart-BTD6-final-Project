using UnityEngine;

public class arrowProjctile : projectileParentForStraightLinearProj
{
    private void Awake()
    {
        pierce = 5;
        damage = 3;
        projSpeed = 2;
        canHitLead = false;
    }
}
