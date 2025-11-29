using UnityEngine;

public class enemyCannonRound : bombProjectileParent
    {
    private void Awake()
    {
        explosionToMake = "enemyTankExplosion";
        damage = 0;
        pierce = 1;
        additionalDamage = 0;
        projSpeed = 0.6f;
        lifespan = 5;
        boxLayerToHit = 1 << 8;
    }

}
