using UnityEngine;

public class bombProjectileParent : projectileParentForStraightLinearProj
{
    protected string expolosionGOPath = "Assets/Resources/explosions/";
    protected string explosionToMake;
    protected float additionalDamage;
    protected float additionalRadius;

    protected override void safetyCheckForCollisionBackWards()
    {
        RaycastHit[] hit = new RaycastHit[(int)pierce];
        if (lastPoistion != null)
        {
            Debug.DrawRay(gameObject.transform.position, -Vector3.Normalize(gameObject.transform.position - lastPoistion) * Vector3.Magnitude(gameObject.transform.position - lastPoistion), Color.rebeccaPurple, 0.01f);
            hit = Physics.RaycastAll(lastPoistion, Vector3.Normalize(gameObject.transform.position - lastPoistion), Vector3.Magnitude(gameObject.transform.position - lastPoistion), boxLayerToHit);
            if (hit.Length > 0 && !isDead)
            {
                explode();               
            }
        }
    }
    protected override void safetyCheckForCollisionForward()
    {
        RaycastHit[] hit = new RaycastHit[(int)pierce];
        if (!isDead)
        {
            Debug.DrawRay(gameObject.transform.position, Vector3.Normalize(gameObject.transform.position - lastPoistion) * gameObject.transform.localScale.y * .5f, Color.rebeccaPurple, 0.01f);
            hit = Physics.RaycastAll(gameObject.transform.position, Vector3.Normalize(gameObject.transform.position - lastPoistion), gameObject.transform.localScale.y * .5f, boxLayerToHit);
            if (hit.Length > 0 && !isDead)
            {
               explode();
             
            }
        }

    }
    protected virtual void explode() { 
      GameObject unityThing = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(expolosionGOPath + explosionToMake + ".prefab");
      GameObject explosionGO = Instantiate(unityThing, transform.position, Quaternion.identity);
        explosionGO.GetComponent<IaddDamage>().addDamage(additionalDamage);
        explosionGO.GetComponent<IaddDamage>().addRadius(additionalRadius);
        explosionGO.GetComponent<IProjctileOwner>().setProjectileOwner(owner);
        isDead = true;
        Destroy(gameObject);

    }
}
