using UnityEngine;
using Unity.Mathematics;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
public class dartProjs : projectileParentForStraightLinearProj
{//should be making this into a scriptable object considering im using a lot of public vars and functions

     void Awake()
    {
        damage = 10000;
        pierce = 2;
        projSpeed = 1;
        canHitLead = false;
    }
}
