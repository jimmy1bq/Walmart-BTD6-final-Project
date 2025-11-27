using UnityEngine;

public class missileScript :    bombProjectileParent
{
    private void Awake()
    {
        //Only does damage with explosion
        explosionToMake = "sExplosion";
        damage = 0;
        pierce = 1;
        projSpeed = 2f;
        lifespan = 5;
        canHitLead = true;
        isDead = false;
    }

}
