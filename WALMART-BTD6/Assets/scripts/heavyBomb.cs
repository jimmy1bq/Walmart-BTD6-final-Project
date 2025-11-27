using UnityEngine;

public class heavyBombScript : bombProjectileParent
{
    private void Awake()
    {
        explosionToMake = "sExplosion";
        damage = 0;
        pierce = 1;
        projSpeed = 0.6f;
        lifespan = 5;
        additionalRadius = 3f;
        canHitLead = true;
        isDead = false;
    }
}
