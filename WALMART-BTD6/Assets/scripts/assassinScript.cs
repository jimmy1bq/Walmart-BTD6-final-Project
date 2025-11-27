using System;
using UnityEngine;

public class assassinScript : bombProjectileParent
{
    private void Awake()
    {
        explosionToMake = "maulerExplsion";
        damage = 0;
        additionalDamage = 1;
        pierce = 1;
        projSpeed = 0.6f;
        lifespan = 5;
        canHitLead = true;
        isDead = false;
    }
}
