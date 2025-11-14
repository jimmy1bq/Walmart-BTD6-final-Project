using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class RayCast : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cantPlaceErrorMessage;

    [SerializeField] TowersSO towerData;

    [SerializeField] GameObject tower1;
    [SerializeField] GameObject brick;


    public LayerMask layerMaskTowerHover;

    Camera cam;

    Vector3 mousePostionRaycast;


    GameObject selectedTower;
    GameObject towerOnMouse;

    // sets the cam up for raycastiing and adds a listener to the tower selected event
    void Start()
    {
        cam = Camera.main;
        events.towerSelected.AddListener(towerSelectedEvent);
    }


    //changed remember to record this on milestone 4
    // made the code more readable and adding layermasking
    //hover is masking for when theres a tower on the mouse
    //hover not is masking for when theres no tower on the mouse
    void Update()
    {
        Vector3 mousPos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousPos);

        RaycastHit hit;
        if (towerOnMouse != null)
        {
            if (Physics.Raycast(ray, out hit, 999999f, layerMaskTowerHover))
            {
                towerOnMouse.transform.position = hit.point;

            }
            if (Input.GetKeyUp(KeyCode.P))
            {

                if (hit.collider.gameObject.tag == "placeableArea")
                {

                    towerOnMouse.GetComponent<IHovering>().hoveringState(false);
                    towerOnMouse = null;
                }
            }
        }
        else if (towerOnMouse == null && Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit) && !EventSystem.current.IsPointerOverGameObject())
        {
                if (hit.collider.gameObject.tag == "Tower")
                {
                  
                    if (selectedTower)
                    {
                        selectedTower.GetComponent<IUNORSelected>().towerUnSelected();
                    }
                    selectedTower = hit.collider.gameObject;
                    selectedTower.GetComponent<IUNORSelected>().towerSelected();
                }
                else
                {
                    if (selectedTower)
                    {
                        selectedTower.GetComponent<IUNORSelected>().towerUnSelected();
                        selectedTower = null;
                    }
            }
        }
    }


    //Find first child is a method that takes a string name and a gameObject to search through to find the name in gameObject
    //returns the index of the child if found otherwise returns -1
    //name is the string name and objectToSearch is the gameObject to search through
    //here because of some previous script but clearly I don't need it anymore since Interface exist but might as well save it for the future
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
//{
//    //if theres no tower on mouse then check if its a tower or just another object getting clicked
//    //if its a tower select and unselect the other tower if there is one selected
//    //if its not a tower then unselect the selected tower if there is one selected
//    //Can this have lower if ststaments?
//    //maybe a corotuine fix? Like use a corotuine waitUntil mouseButtonDown then do the raycast
//    //then since clicking anywhere deselects the tower then check if we are clicking another tower or not
//    if (Physics.Raycast(ray, out hit))
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            Debug.Log("HitNPressed");
//            if (hit.collider.gameObject.tag == "Tower")
//            { 
//                if (selectedTower)
//                {
//                    selectedTower.GetComponent<IUNORSelected>().towerUnSelected();
//                }
//                selectedTower = hit.collider.gameObject;
//                selectedTower.GetComponent<IUNORSelected>().towerSelected();
//            }
//            else
//            {
//                if (selectedTower)
//                {
//                    selectedTower.GetComponent<IUNORSelected>().towerUnSelected();
//                    selectedTower = null;
//                }
//            }
//        }
//    }
//}