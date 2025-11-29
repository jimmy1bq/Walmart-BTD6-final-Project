using UnityEngine;

public class enemyExplosion : explosiveParent
{
    private void Awake()
    {
        explosiveRadius = 5f;
        damage = 20;
        pierce = 10;
        boxLayerToHit = 1 << 8;
    }
    protected override void domainExpansion()
    {
        gameObject.LeanScale(new Vector3(explosiveRadius, explosiveRadius, explosiveRadius), 0.2f);
        Collider[] hits = new Collider[(int)pierce];
        Debug.Log("hi");
        hits = Physics.OverlapSphere(transform.position, explosiveRadius, boxLayerToHit);
        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {

                hits[i].gameObject.GetComponent<IDamageTaken>().damageTaken((int)damage, gameObject);
                StartCoroutine(killExplosion(0.3f, gameObject));
            }
        }
    }
}
    
