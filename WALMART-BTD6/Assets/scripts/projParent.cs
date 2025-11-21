using UnityEngine;
using UnityEngine.UIElements;
using Unity.Mathematics;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Unity.VisualScripting;
using System;
using Unity.Mathematics.Geometry;

public class projectileParentForStraightLinearProj : MonoBehaviour, IProjctileOwner, IGiveEnemy, IStatChange
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected GameObject owner;
    protected GameObject targetEnemy;
    protected Vector3 orgEnemyPosition;

    protected int damage;

    protected float pierce;
    protected float projSpeed;
    protected float lifespan = 3;

    

    protected bool mutipleOverLappingCollider = false;
    protected bool isDead =false;
    protected List<GameObject> listOfGO = new List<GameObject>();
    protected List<int> idOfNotToDamage = new List<int>();

    protected Vector3 lastPoistion;


    protected void Start()
    {
        if (targetEnemy != null)
        {
            orgEnemyPosition = targetEnemy.transform.position;
        }
        StartCoroutine(selfDest());
    }

    // Update is called once per frame
    protected void Update()
    {
        
        if (orgEnemyPosition != null)
        {
            lastPoistion = gameObject.transform.position;
            transform.Translate(new Vector3(0, orgEnemyPosition.y * 5 * Time.deltaTime * projSpeed, 0));
            safetyCheckForCollisionBackWards();
            safetyCheckForCollisionForward();
        }
        //if (mutipleOverLappingCollider && !isDead) {
        //    for (int i = 0; i < pierce; i++) {
        //        listOfGO[i].GetComponent<IDamageTaken>().damageTaken(damage);
        //        isDead = true;
        //    }
        //    Destroy(gameObject);
        //}
    }

    protected IEnumerator selfDest()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }
    //for mutiple collision during a frame going over an projectile priece limit we can do raycast but get an array back limiting
    //protected void OnTriggerEnter(Collider other)
    //{
    //    listOfGO = new List<GameObject>();
    //    IDamageTaken enemyDamage = other.GetComponent<IDamageTaken>();
    //    if (enemyDamage != null && other.gameObject.tag == "enemy")
    //    {
    //        //ok so added some lines of code to account for 5 collision in the same frame
    //        //adds the gameobject onto a list
            
    //        listOfGO.Add(other.gameObject);
           
    //        //isDead is here because destory only gets rid of the GameObject at end of frame
    //        //this works lmao
    //        if (listOfGO.Count>pierce)
    //        {
    //            mutipleOverLappingCollider = true;
    //        }
    //        if (isDead == false) 
    //        {
    //            enemyDamage.damageTaken(damage);
    //            owner.GetComponent<IPopToPopCount>().damageDealt(1);
    //            pierce--;
    //        }

    //        if (pierce == 0)
    //        {
    //            isDead = true;
    //            Destroy(gameObject);
    //        }
    //    }
    //}
    //basically use raycast to detect collision by shooting a ray forward and backwards by using the difference of position and normalizing the position to get direction. Backward shoots a raybackwards from the current to last position to check if it missed anything

    protected void safetyCheckForCollisionBackWards() {
        RaycastHit[] hit = new RaycastHit[(int)pierce];
        if (lastPoistion != null) {
            Debug.DrawRay(gameObject.transform.position, -Vector3.Normalize(gameObject.transform.position - lastPoistion), Color.rebeccaPurple,999f);
            hit = Physics.RaycastAll(gameObject.transform.position, -Vector3.Normalize(gameObject.transform.position-lastPoistion),Vector3.Magnitude(gameObject.transform.position - lastPoistion)*1.5f,1<<9);
            if (hit.Length > 0) {
        
                for (int i = 0; i < hit.Length; i++)
                {
                    
                    int idGO = hit[i].collider.gameObject.GetComponent<IGetSetID>().GetID();
                    if (isDead == false && i<hit.Length && !idOfNotToDamage.Contains(idGO))
                    {                
                        hit[i].collider.gameObject.GetComponent<IDamageTaken>().damageTaken(damage);
                        idOfNotToDamage.Add(idGO);
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
    protected void safetyCheckForCollisionForward()
    {
        RaycastHit[] hit = new RaycastHit[(int)pierce];
        if (!isDead)
        {
            Debug.DrawRay(gameObject.transform.position, Vector3.Normalize(gameObject.transform.position - lastPoistion), Color.rebeccaPurple, 0.5f);
            hit = Physics.RaycastAll(gameObject.transform.position, Vector3.Normalize(gameObject.transform.position - lastPoistion), gameObject.transform.localScale.y*.75f, 1 << 9);
            if (hit.Length > 0)
            {
               
                for (int i = 0; i < hit.Length; i++)
                {
                  
                    int idGO = hit[i].collider.gameObject.GetComponent<IGetSetID>().GetID();
                    if (isDead == false && i < hit.Length && !idOfNotToDamage.Contains(idGO))
                    {
                        hit[i].collider.gameObject.GetComponent<IDamageTaken>().damageTaken(damage);
                        idOfNotToDamage.Add(idGO);
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
    public void setProjectileOwner(GameObject trackstar)
    {
        owner = trackstar;
    }
    public void setEnemy(GameObject enemy) {
       
        targetEnemy = enemy;
    }
    public void statChangePierce(float addedpierce) {
        pierce *= addedpierce;
        math.floor(pierce);
    }
    public void statChangeProjSpeed(float speed) {
       projSpeed *= speed;
    }
}
