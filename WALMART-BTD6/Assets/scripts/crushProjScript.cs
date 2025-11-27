using UnityEngine;

public class crushProjScript : bombProjectileParent
{
    private void Awake()
    {
        explosionToMake = "crushExplosion";
        damage = 0;
        pierce = 1;
        projSpeed = 0.6f;
        lifespan = 5;
        additionalRadius = 3f;
        canHitLead = true;
        isDead = false;
    }
}
