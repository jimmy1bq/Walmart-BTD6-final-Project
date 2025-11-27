using UnityEngine;

public class maulerExplsoin : explosiveParent
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        damage = 1;
        explosiveRadius = 3;
        pierce = 15;
    }
    protected override void domainExpansion()
    {
        Debug.Log(damage);
        gameObject.LeanScale(new Vector3(explosiveRadius, explosiveRadius, explosiveRadius), 0.05f);
        GameObject VFXPath = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Resources/VFX/explosionVFX.prefab");
        GameObject VFXGO = Instantiate(VFXPath, transform.position, Quaternion.identity);
        ParticleSystem particleSystems = VFXGO.GetComponent<ParticleSystem>();
        VFXGO.transform.localScale = new Vector3(explosiveRadius, explosiveRadius, explosiveRadius);
        particleSystems.Play();
        Collider[] hits = new Collider[(int)pierce];
        hits = Physics.OverlapSphere(transform.position, explosiveRadius, boxLayerToHit);
        if (hits.Length > 0)
        {
            for (int i = 0; i < hits.Length; i++)
            {
                int idGO = hits[i].gameObject.GetComponent<IGetSetID>().parentGetID();
                int idGO2 = hits[i].gameObject.GetComponent<IGetSetID>().personalGetID();
                if (isDead == false && i < hits.Length && !idOfNotToDamage.Contains(idGO) && !idOfNotToDamage.Contains(idGO2))
                {
                    if (hits[i].gameObject.GetComponent<IreturnIndexNum>().returnIfTank())
                    {
                        hits[i].gameObject.GetComponent<IDamageTaken>().damageTaken((int)damage * 10, gameObject);
                    }
                    else { hits[i].gameObject.GetComponent<IDamageTaken>().damageTaken((int)damage, gameObject); }                    
                    idOfNotToDamage.Add(idGO2);
                    if (owner != null) {owner.GetComponent<IPopToPopCount>().damageDealt((int)damage);}
                    
                    pierce--;
                }
                StartCoroutine(killExplosion(0.1f, VFXGO));

            }
        }

    }
}
