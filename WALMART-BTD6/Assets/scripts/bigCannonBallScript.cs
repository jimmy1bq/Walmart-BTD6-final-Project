using UnityEngine;

public class bigCannonBallScript : projectileParentForStraightLinearProj
{
    private void Awake()
    {
        damage = 5;
        pierce = 20;
        projSpeed = 0.8f;
        lifespan = 5;
        canHitLead = true;
    }
}
