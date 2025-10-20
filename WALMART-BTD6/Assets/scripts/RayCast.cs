using UnityEngine;

public class RayCast : MonoBehaviour
{
    Camera cam;
    Vector3 mousePostionRaycast;
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
            mousePostionRaycast = hit.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Q)) { 
        
        
        
        
        } 
    }
    
}
