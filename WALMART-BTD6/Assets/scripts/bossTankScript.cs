using System.Collections;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class bossTankScript : Box
{
    private void Awake()
    {
        tankOrNot = true;
        balloonSpeedValue = 1.5f;
        range = 10f;
        outerProtectiveLayer = 150;
        if (WayPointManager.instance != null) { totalWayPoints = WayPointManager.instance.wayPoints.Count - 1; }
        personalId = boxData.ID;
        boxData.ID++;
    }
    
    protected override IEnumerator attackEnemy(GameObject enemy)
    {
        GameObject turret=gameObject.transform.GetChild(0).gameObject;
        turret.transform.LookAt(enemy.transform);
        shoot(enemy,turret);
        yield return new WaitForSeconds(5f);
        if (enemy == null)
        {

            currentState = state.moving;
            switchStates(null);
            attackCoroutine = null;
        }
        else
        {
            StartCoroutine(attackEnemy(enemy));
        }
    }
    void shoot(GameObject enemyToShoot,GameObject turret) {
        Debug.Log(enemyToShoot);
        string projctilePath = "Assets/Resources/Projectile/";
        Vector3 projctileSpawn = new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z);
        GameObject proj = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(projctilePath + "tankRound" + ".prefab");
        GameObject projctileGO = Instantiate(proj, projctileSpawn, Quaternion.Euler(turret.transform.eulerAngles.x + 90, turret.transform.eulerAngles.y, 0));
        projctileGO.GetComponent<IGiveEnemy>().setEnemy(enemyToShoot);
    }
}
