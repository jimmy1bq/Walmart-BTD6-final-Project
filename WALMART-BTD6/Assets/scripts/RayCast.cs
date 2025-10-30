using TMPro;
using UnityEngine;
public class RayCast : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cantPlaceErrorMessage;

    [SerializeField] TowersSO towerData;

    [SerializeField] GameObject tower1;
    [SerializeField] GameObject brick;

    public LayerMask layerMaskMap;
    public LayerMask layerMaskTower;

    Camera cam;

    Vector3 mousePostionRaycast;

    GameObject currentTower;
    GameObject selectedTower;
    GameObject towerOnMouse;

    // sets the cam up for raycastiing and adds a listener to the tower selected event
    void Start()
    {
        cam = Camera.main;
        events.towerSelected.AddListener(towerSelectedEvent);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousPos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousPos);

        RaycastHit hit;
        if (towerOnMouse != null)
        {   Debug.Log("Moving Tower");
            if (Physics.Raycast(ray, out hit, 999999f, layerMaskMap))
            {
              towerOnMouse.transform.position = hit.point;
            }
            if (Input.GetMouseButtonUp(0)) {
                towerOnMouse.GetComponent<IHovering>().hoveringState(false);
                towerOnMouse = null;
              
            }
        }else if(towerOnMouse == null)
        {
            Debug.Log("Searching");
            if (Physics.Raycast(ray, out hit,9999999f,layerMaskTower)) { 
                Debug.Log(hit.point);

            }

        }
       
       



        //    if (float.IsNaN(mousePostionRaycast.x))
        //    {
        //        if (currentTower != null)
        //        {
        //            selectedTower = currentTower;
        //            selectedTower.transform.GetChild(findFirstChild("RangeCircleThing(Clone)", selectedTower)).gameObject.SetActive(true);

        //        }
        //        else if (currentTower == null)
        //        {
        //            //selectedTower.transform.GetChild(findFirstChild("RangeCircleThing(Clone)", selectedTower)).gameObject.SetActive(false);
        //            //selectedTower = null;
        //            //Debug.Log("Can't Place here");
        //        }
        //    }
        //    else if (mousePostionRaycast.x != float.NaN)
        //    {
        //        //selectedTower.transform.GetChild(findFirstChild("RangeCircleThing(Clone)", selectedTower)).gameObject.SetActive(false);
        //        //selectedTower = null;
        //        Instantiate(tower1, mousePostionRaycast, Quaternion.identity);
        //    }
        //}
    }

    //Find first child is a method that takes a string name and a gameObject to search through to find the name in gameObject
    //returns the index of the child if found otherwise returns -1
    //name is the string name and objectToSearch is the gameObject to search through
    int findFirstChild(string name, GameObject objectToSearch)
    {
        int i = 0;
        foreach (Transform child in objectToSearch.transform)
        {
            Debug.Log(child.name == name);
            if (child.name == name)
            {
                return i;
            }
            else
            {
                i++;
            }
        }
        i++;
        return -1;
    }
    //Once Invoked the event gets a tower and it spawn the tower on the mouse and stop it from attacking because it isn't placed
    //tower is the gameObject of the tower selected
    //IHovering is the interface that passes in if a tower is hovering on the mouse or not

    void towerSelectedEvent(GameObject tower)
    {
        Vector3 mousPos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousPos);
        RaycastHit hit;

        Physics.Raycast(ray, out hit);
        GameObject towerInst = Instantiate(tower, hit.point, Quaternion.identity);

        towerOnMouse = towerInst;
        towerOnMouse.GetComponent<IHovering>().hoveringState(true);
    }

}
//Code blocks used for later
//if (Physics.Raycast(ray, out hit))
//{
//    if (hit.collider.tag == "placeableArea")
//    {
//        mousePostionRaycast = hit.point;
//        currentTower = null;
//    }
//    else if (hit.collider.tag == "Tower")
//    {
//        mousePostionRaycast = new Vector3(float.NaN, float.NaN, float.NaN);
//        currentTower = hit.collider.gameObject;

//    }
//    else
//    {
//        mousePostionRaycast = new Vector3(float.NaN, float.NaN, float.NaN);
//        currentTower = null;
//    }

//}