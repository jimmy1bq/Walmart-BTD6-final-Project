using UnityEngine;

public class recursiveCluster : bombProjectileParent
{
    private void Awake()
    {
        explosionToMake = "sExplosion";
        damage = 0;
        pierce = 1;
        additionalDamage = 0;
        projSpeed = 0.6f;
        lifespan = 5;
        additionalRadius = 0f;
        canHitLead = true;
        isDead = false;
        canHitblack = false;
      
    }
    protected override void explode()
    {
        makeClusterBomb();
        GameObject unityThing = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(expolosionGOPath + explosionToMake + ".prefab");
        GameObject explosionGO = Instantiate(unityThing, transform.position, Quaternion.identity);
        explosionGO.GetComponent<IaddDamage>().addDamage(additionalDamage);
        explosionGO.GetComponent<IaddDamage>().addRadius(additionalRadius);
        explosionGO.GetComponent<IProjctileOwner>().setProjectileOwner(owner);
        isDead = true;
        Destroy(gameObject);
    }
    void makeClusterBomb()
    {
        float deg = 0;
        for (int i = 6; i > 0; i--)
        {
            GameObject unityThing = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Projectile/" + "subClusterBomb" + ".prefab");
            GameObject explosionGO = Instantiate(unityThing, transform.position + new Vector3(Mathf.Cos(deg) * 1, 0, Mathf.Sin(deg) * 1), Quaternion.identity);
            explosionGO.GetComponent<Iexplodeable>().selfDet();
            explosionGO.GetComponent<Iexplodeable>().recursion(1);
            deg += 45;
        }

    }

}
