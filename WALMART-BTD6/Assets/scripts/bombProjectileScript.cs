using UnityEngine;

public class bombProjectileScript : projectileParentForStraightLinearProj
{
    private void Awake()
    {
        //Only does damage with explosion
        damage = 0;
        pierce = 1;
        projSpeed = 0.6f;
        lifespan = 5;
        canHitLead = true;
    }
}
