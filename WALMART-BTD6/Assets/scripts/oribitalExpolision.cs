using System;
using UnityEngine;

public class oribitalExpolision : explosiveParent
{
    private void Awake()
    {
        explosiveRadius = 30f;
        damage = 500f;
        pierce = 20000f;
    }
}
