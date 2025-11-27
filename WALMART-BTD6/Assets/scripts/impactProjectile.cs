using System;
using UnityEngine;

public class impactProjectile : bombProjectileParent
{
    private void Awake()
    {
        explosionToMake = "impactExplosion";
        damage = 0;
        pierce = 1;
        projSpeed = 0.6f;
        lifespan = 5;
        additionalRadius = 2f;
        canHitLead = true;
        isDead = false;
    }
}
