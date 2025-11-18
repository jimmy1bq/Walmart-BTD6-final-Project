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
            //cast a ray up to the future position and if it collides with anything do stuff ig
            transform.Translate(new Vector3(0, orgEnemyPosition.y * 5 * Time.deltaTime * projSpeed, 0));
        }
        if (mutipleOverLappingCollider && !isDead) {
            for (int i = 0; i < pierce; i++) {
                listOfGO[i].GetComponent<IDamageTaken>().damageTaken(damage);
                isDead = true;
            }
            Destroy(gameObject);
        }
    }

    protected IEnumerator selfDest()
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(gameObject);
    }

    protected void OnTriggerEnter(Collider other)
    {
        listOfGO = new List<GameObject>();
        IDamageTaken enemyDamage = other.GetComponent<IDamageTaken>();
        if (enemyDamage != null && other.gameObject.tag == "enemy")
        {
            //ok so added some lines of code to account for 5 collision in the same frame
            //adds the gameobject onto a list
            
            listOfGO.Add(other.gameObject);
           
            //isDead is here because destory only gets rid of the GameObject at end of frame
            //this works lmao
            if (listOfGO.Count>pierce)
            {
                mutipleOverLappingCollider = true;
            }
            if (isDead == false) 
            {
                enemyDamage.damageTaken(damage);
                owner.GetComponent<IPopToPopCount>().damageDealt(1);
                pierce--;
            }

            if (pierce == 0)
            {
                isDead = true;
                Destroy(gameObject);
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
