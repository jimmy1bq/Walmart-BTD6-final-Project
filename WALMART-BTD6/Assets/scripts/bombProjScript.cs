using UnityEngine;

public class bombProjScript : bombProjectileParent
{
    private void Awake()
    {
        //Only does damage with explosion
        explosionToMake = "sExplosion";
        damage = 0;
        pierce = 1;
        projSpeed = 0.6f;
        lifespan = 5;
        canHitLead = true;
        isDead = false;
    }
}
