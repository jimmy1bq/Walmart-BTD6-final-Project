using System;
using UnityEngine;

public class tankElimScript : bombProjectileParent
{
    private void Awake()
    {
        explosionToMake = "maulerExplsion";
        damage = 0;
        pierce = 1;
        additionalDamage = 10;
        projSpeed = 0.6f;
        lifespan = 5;
        canHitLead = true;
        isDead = false;
    }
}
