using System;
using UnityEngine;

public class tankElimScript : bombProjectileParent
{
    private void Awake()
    {
        explosionToMake = "maulerExplsion";
        damage = 10;
        pierce = 1;
        projSpeed = 0.6f;
        lifespan = 5;
        canHitLead = true;
        isDead = false;
    }
}
