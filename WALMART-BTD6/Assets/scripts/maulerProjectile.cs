using System;
using UnityEngine;

public class maulerProjectile : bombProjectileParent
{
    private void Awake()
    {
        explosionToMake = "maulerExplsion";
        damage = 0;
        pierce = 1;
        projSpeed = 0.6f;
        lifespan = 5;
        canHitLead = true;
        isDead = false;
    }
}
