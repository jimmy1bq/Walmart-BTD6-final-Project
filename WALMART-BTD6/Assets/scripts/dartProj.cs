using UnityEngine;
using Unity.Mathematics;
public class dartProj : MonoBehaviour
{
    GameObject closestEnemy;
    Vector3 ogPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (closestEnemy != null)
        {   
            ogPosition = closestEnemy.transform.position;
            Debug.Log(ogPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ogPosition != null)
        {
            transform.Translate((ogPosition - transform.position) * 3 * Time.deltaTime);
        }
    }

    public void setClosestEnemy(GameObject enemy)
    {
        closestEnemy = enemy;
    }
}
