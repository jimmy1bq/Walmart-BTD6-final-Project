using UnityEngine;
using UnityEngine.UIElements;
using Unity.Mathematics;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

public class projectileParentForStraightLinearProj : MonoBehaviour, IProjctileOwner, IGiveEnemy, IStatChange
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected GameObject owner;
    protected GameObject targetEnemy;
    protected Vector3 orgEnemyPosition;

    protected int damage;

    protected float pierce;
    protected float projSpeed;

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
            transform.Translate(new Vector3(0, orgEnemyPosition.y * 5 * Time.deltaTime * projSpeed, 0));
        }

    }

    protected IEnumerator selfDest()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }

    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLIDED");
        IDamageTaken enemyDamage = other.GetComponent<IDamageTaken>();
        if (enemyDamage != null && other.gameObject.tag == "enemy")
        {
            if (pierce <= 0)
            {
                Destroy(gameObject);
            }
            enemyDamage.damageTaken(damage);
            owner.GetComponent<IPopToPopCount>().damageDealt(1);
            pierce--;
            
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
