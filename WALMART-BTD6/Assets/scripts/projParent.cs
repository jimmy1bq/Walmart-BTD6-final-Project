using UnityEngine;
using UnityEngine.UIElements;
using Unity.Mathematics;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using System;
using Unity.Mathematics.Geometry;

public class projectileParentForStraightLinearProj : MonoBehaviour, IProjctileOwner, IGiveEnemy, IStatChange, IGiveProptieres
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected GameObject owner;
    protected GameObject targetEnemy;
    protected Vector3 orgEnemyPosition;

    protected int damage;

    protected float pierce;
    protected float projSpeed;
    protected float lifespan = 3;


    protected bool canHitLead;
    protected bool canHitblack = true;
    protected bool mutipleOverLappingCollider = false;
    protected bool isDead =false;
    protected List<GameObject> listOfGO = new List<GameObject>();
    protected List<int> idOfNotToDamage = new List<int>();
    protected int collisioncounter = 0;

    protected Vector3 lastPoistion;

    protected LayerMask boxLayerToHit = 1 << 9;



    protected virtual void Start()
    {
        if (targetEnemy != null)
        {         
            orgEnemyPosition = targetEnemy.transform.position;
          
        }
        StartCoroutine(selfDest());
    }

  
    protected void Update()
    {
        
        if (orgEnemyPosition != null)
        {
            lastPoistion = gameObject.transform.position;
            transform.Translate(new Vector3(0, orgEnemyPosition.y * 5 * Time.deltaTime * projSpeed, 0));
            safetyCheckForCollisionBackWards();
            safetyCheckForCollisionForward();
        }
       
    }

    protected IEnumerator selfDest()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }
    #region raycast
    //bug the is that some balloons share the same id not a raycast bug
    //raycast from last position to current
    protected virtual void safetyCheckForCollisionBackWards() {
        RaycastHit[] hit = new RaycastHit[(int)pierce];
        if (lastPoistion != null) {
            Debug.DrawRay(gameObject.transform.position, -Vector3.Normalize(gameObject.transform.position - lastPoistion)* Vector3.Magnitude(gameObject.transform.position - lastPoistion) , Color.rebeccaPurple,0.01f);
            hit = Physics.RaycastAll(lastPoistion,Vector3.Normalize(gameObject.transform.position-lastPoistion),Vector3.Magnitude(gameObject.transform.position - lastPoistion),boxLayerToHit);
            if (hit.Length > 0) {
        
                for (int i = 0; i < hit.Length; i++)
                {
                    int idGO = hit[i].collider.gameObject.GetComponent<IGetSetID>().parentGetID();
                    int idGO2 = hit[i].collider.gameObject.GetComponent<IGetSetID>().personalGetID();
                    Debug.Log(!idOfNotToDamage.Contains(idGO));
                    Debug.Log(!idOfNotToDamage.Contains(idGO2));
                    if (isDead == false && i<hit.Length && !idOfNotToDamage.Contains(idGO) && !idOfNotToDamage.Contains(idGO2))
                    {                
                        hit[i].collider.gameObject.GetComponent<IDamageTaken>().damageTaken(damage,gameObject);
                        idOfNotToDamage.Add(idGO2);
                        if (owner != null)
                        {
                            owner.GetComponent<IPopToPopCount>().damageDealt(damage);
                        }
                        pierce--;
                    }
                    if (pierce == 0)
                    {
                        Destroy(gameObject);
                        isDead = true;
                    }
                }            
            }              
        }
    }
    //raycast forwards
    protected virtual void safetyCheckForCollisionForward()
    {
        RaycastHit[] hit = new RaycastHit[(int)pierce];
        if (!isDead)
        {
            Debug.DrawRay(gameObject.transform.position, Vector3.Normalize(gameObject.transform.position - lastPoistion)* gameObject.transform.localScale.y * .5f, Color.rebeccaPurple,0.01f);
            hit = Physics.RaycastAll(gameObject.transform.position, Vector3.Normalize(gameObject.transform.position - lastPoistion), gameObject.transform.localScale.y*.5f, boxLayerToHit);
            if (hit.Length > 0)
            {               
                for (int i = 0; i < hit.Length; i++)
                {                    
                    int idGO = hit[i].collider.gameObject.GetComponent<IGetSetID>().parentGetID();
                    int idGO2 = hit[i].collider.gameObject.GetComponent<IGetSetID>().personalGetID();
                    if (isDead == false && i < hit.Length && !idOfNotToDamage.Contains(idGO) && !idOfNotToDamage.Contains(idGO2))
                    {
                        hit[i].collider.gameObject.GetComponent<IDamageTaken>().damageTaken(damage,gameObject);
                        idOfNotToDamage.Add(idGO2);
                        if (owner != null) { owner.GetComponent<IPopToPopCount>().damageDealt(damage); }
                        
                        pierce--;
                    }
                    if (pierce == 0)
                    {
                        Destroy(gameObject);
                        isDead = true;
                    }
                }
            }
        }
            
    }
    #endregion
    #region Interfaces

    //sets the owner or tower that spawned it
    public void setProjectileOwner(GameObject trackstar)
    {
        owner = trackstar;
    }
    //sets the targetted enemy for translate
    public void setEnemy(GameObject enemy) {       
        targetEnemy = enemy;
    }
    //stat change for pierce
    public void statChangePierce(float addedpierce) {
        pierce *= addedpierce;
        math.floor(pierce);
    }
    //stat change for Projectile Speed
    public void statChangeProjSpeed(float speed) {
       projSpeed *= speed;
    }
    //Gets the tower that spawn it's layermask
    public void getParentLayerMask(LayerMask layerToHit) {
        boxLayerToHit = layerToHit;    
    }
    //return if the projectile can hit lead enemies
    public bool returnCanHitLead() {
        return canHitLead;    
    }
    //return if the projectile can hit black box enemies
    public bool returnCanHitBlack() {
        return true;
    }

    #endregion

}
