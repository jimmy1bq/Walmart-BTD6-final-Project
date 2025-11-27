using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class crushSCript : explosiveParent 
{ 
    private void Awake()
    {
        damage = 30;
        explosiveRadius = 3;
        pierce = 15;
    }
    protected override void domainExpansion()
    {
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
                    hits[i].gameObject.GetComponent<IStun>().stunEnemy(3f);
                    hits[i].gameObject.GetComponent<IDamageTaken>().damageTaken((int)damage, gameObject);
                 
                    idOfNotToDamage.Add(idGO2);
                    if (owner != null) { owner.GetComponent<IPopToPopCount>().damageDealt((int)damage); }
                 
                    pierce--;
                }
                StartCoroutine(killExplosion(0.3f, VFXGO));
                 
            }
        }

    }
}
