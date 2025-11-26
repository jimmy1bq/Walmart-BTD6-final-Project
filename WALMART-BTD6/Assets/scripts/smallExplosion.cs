using UnityEngine;

public class smallExplosion :  explosiveParent
{
    private void Awake()
    {
        explosiveRadius = 2.5f;
        damage = 1;
        pierce = 10;

    }
}
