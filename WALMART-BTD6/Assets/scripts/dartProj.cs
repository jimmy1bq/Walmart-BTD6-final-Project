using UnityEngine;
using Unity.Mathematics;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
public class dartProj : MonoBehaviour
{//should be making this into a scriptable object considering im using a lot of public vars and functions
    [SerializeField] GameObject lastPosition;
    [SerializeField] projectileSO projectileData;
   
    GameObject closestEnemy;
    Vector3 ogPosition;
    int damage = 1;
    int pierce = 2;
   
     void Awake()
    {
        

    }
    void Start()
    {
        if (closestEnemy != null)
        {
            ogPosition = closestEnemy.transform.position;
           
        }
        StartCoroutine(selfDest());
    }

    // Update is called once per frame
    void Update()
    {   
        if (ogPosition != null)
        {
            transform.Translate(new Vector3(0, ogPosition.y * 5 * Time.deltaTime,0));
            
        }
        
    }

    public void setClosestEnemy(GameObject enemy)
    {
        closestEnemy = enemy;
    }
    
    IEnumerator selfDest() {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        IDamageTaken enemyDamage = other.GetComponent<IDamageTaken>();
        if (enemyDamage != null && other.gameObject.tag == "enemy")
        {
            enemyDamage.damageTaken(damage);
            pierce--;
            if (pierce <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
