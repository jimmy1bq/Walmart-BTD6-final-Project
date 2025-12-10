using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.UI.GridLayoutGroup;
using UnityEngine.UIElements;
using Unity.Mathematics;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using System;
using Unity.Mathematics.Geometry;

public class explosiveParent : MonoBehaviour, IProjctileOwner, IGiveEnemy, IGiveProptieres, IaddDamage
{
    protected GameObject owner;

    protected float explosiveRadius;
    protected float damage;
    protected float pierce;

    protected bool canHitLead = true;
    protected bool isDead = false;

    protected LayerMask boxLayerToHit = 1 << 9;

    protected List<GameObject> listOfGO = new List<GameObject>();
    protected List<int> idOfNotToDamage = new List<int>();

    protected void Start()
    {
        
        domainExpansion();
    }

    protected virtual void domainExpansion() {
        gameObject.LeanScale(new Vector3(explosiveRadius,explosiveRadius,explosiveRadius),0.5f);
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
                  
                    hits[i].gameObject.GetComponent<IDamageTaken>().damageTaken((int)damage, gameObject);
                    idOfNotToDamage.Add(idGO2);
                    if (owner !=null) { owner.GetComponent<IPopToPopCount>().damageDealt((int)damage); }                  
                    pierce--;
                }
                StartCoroutine(killExplosion(0.7f,gameObject));
            }
        }

    }
    public void setProjectileOwner(GameObject trackstar)
    {
        owner = trackstar;
    }
    public void getParentLayerMask(LayerMask layerToHit)
    {
        boxLayerToHit = layerToHit;
    }
    public bool returnCanHitLead()
    {
        return canHitLead;
    }
    public void addDamage(float additionalDamage)
    {
        damage += additionalDamage;
    }
    public void addRadius(float rad) {
        explosiveRadius += rad;
    }
    protected IEnumerator killExplosion(float time,GameObject woenfw) { 
    yield return new WaitForSeconds(time);
    Destroy(woenfw);
    Debug.Log("dead");
    Destroy(gameObject);
    }
    public bool returnCanHitBlack() {
        return false;
    
    }
}
