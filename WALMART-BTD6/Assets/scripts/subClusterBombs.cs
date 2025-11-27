using UnityEngine;

public class subClusterBombs : bombProjectileParent, Iexplodeable
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
    }

    public void selfDet() {
    
    base.explode();

    }
    public void recursion(int amount) {
        float deg = 0;
        if (amount != 0)
        {
            //what I called "Interface recursion"(you can see I attempted in the ceramic/seagreen/orange box script)
            for (int i = 6; i > 0; i--)
            {
                GameObject unityThing = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/Projectile/" + "subClusterBomb" + ".prefab");
                GameObject explosionGO = Instantiate(unityThing, transform.position + new Vector3(Mathf.Cos(deg) * 1, 0, Mathf.Sin(deg) * 1), Quaternion.identity);
                explosionGO.GetComponent<Iexplodeable>().selfDet();
                explosionGO.GetComponent<Iexplodeable>().recursion(amount - 1);
                deg += 45;
            }
        }
    }
}
