using UnityEngine;

public class strongestarrowProjctile : projectileParentForStraightLinearProj
{
    private void Awake()
    {
        pierce = 10;
        damage = 9;
        projSpeed = 5;
        canHitLead = true;
    }
}
