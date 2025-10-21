using UnityEngine;
using static TowersSO;
public class RayCast : MonoBehaviour
{
    Camera cam;
    Vector3 mousePostionRaycast;
   [SerializeField]  GameObject tower1;

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
        RaycastHit hit;
      
        if (Physics.Raycast(ray, out hit)) {
           //don't do transform.position get the ray hit poistion
            mousePostionRaycast = hit.point;
             Debug.Log(mousePostionRaycast);
        }
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (mousePostionRaycast != null)
            {
                
                Instantiate(tower1, mousePostionRaycast, Quaternion.identity);

            }
        
        } 
    }
    
}
