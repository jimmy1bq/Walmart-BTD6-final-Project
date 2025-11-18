using UnityEngine;

public class VoidBallScript : projectileParentForStraightLinearProj
{
    private void Awake()
    {
        damage = 10;
        pierce = 30;
        projSpeed = 3;
        lifespan = 10;
    }
}
