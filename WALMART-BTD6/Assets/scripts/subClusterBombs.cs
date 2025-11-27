using UnityEngine;

public class subClusterBombs : bombProjectileParent, Iexplodeable
{

    private void Awake()
    {
        explosionToMake = "sExplosion";
        damage = 0;
        pierce = 1;
        additionalDamage = -0.5f;
        projSpeed = 0.6f;
        lifespan = 5;
        additionalRadius = 0f;
        canHitLead = true;
        isDead = false;
    }
    public void selfDet() {
    
    base.explode();

    }
}
