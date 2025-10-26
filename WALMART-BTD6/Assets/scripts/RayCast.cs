using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static TowersSO;
public class RayCast : MonoBehaviour
{
    Camera cam;
    Vector3 mousePostionRaycast;
    [SerializeField]  GameObject tower1;
    [SerializeField] TextMeshProUGUI cantPlaceErrorMessage;
    GameObject currentTower;
    [SerializeField] TowersSO towerData;
    [SerializeField] GameObject brick;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        cam = Camera.main;
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousPos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousPos);
        Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);

        RaycastHit hit;
       
        if (Physics.Raycast(ray, out hit)) {
            Debug.Log(hit.collider.gameObject.name);
            
            if (hit.collider.tag == "placeableArea")
            {
                mousePostionRaycast = hit.point;
                currentTower = null;
            }
            else if (hit.collider.tag == "Tower") {             
                mousePostionRaycast = new Vector3(float.NaN, float.NaN, float.NaN);
                currentTower = hit.collider.gameObject;

            }
            else
            {
                mousePostionRaycast = new Vector3(float.NaN, float.NaN, float.NaN);
                currentTower = null;
            }
            
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (float.IsNaN(mousePostionRaycast.x))
            {
                cantPlaceErrorMessage.enabled = true;
            }
            else if (mousePostionRaycast.x != float.NaN)
            {
                Debug.Log("+1");
                Instantiate(tower1, mousePostionRaycast, Quaternion.identity);

            }
            else if (currentTower != null) {
                Debug.Log(currentTower);
           
            
            }
        
        } 
    }
    
}
