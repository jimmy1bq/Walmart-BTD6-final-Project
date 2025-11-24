using UnityEngine;

public class tripleDartProjectileScript : projectileParentForStraightLinearProj
{
    [SerializeField] GameObject dartProjctile;
    private void Awake()
    {
        damage = 1;
        pierce = 2;
        projSpeed = 1;
        canHitLead = false;
    }
    protected override void Start()
    {
        base.Start();
        GameObject leftDartGO = Instantiate(dartProjctile, transform.position, Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, 0));
        GameObject rightDartGO = Instantiate(dartProjctile, transform.position, Quaternion.Euler(gameObject.transform.eulerAngles.x, gameObject.transform.eulerAngles.y, 0));
        leftDartGO.GetComponent<IGiveEnemy>().setEnemy(targetEnemy);
        rightDartGO.GetComponent<IGiveEnemy>().setEnemy(targetEnemy);
    }
}
