using UnityEngine;

public class cannonBallScript : projectileParentForStraightLinearProj
{
    private void Awake()
    {
        damage = 2;
        pierce = 10;
        projSpeed = 2;
    }
}
