using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static TowersSO;
public class RayCast : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cantPlaceErrorMessage;

    [SerializeField] TowersSO towerData;

    [SerializeField] GameObject tower1;
    [SerializeField] GameObject brick;

    Camera cam;

    Vector3 mousePostionRaycast;

    GameObject currentTower;
    GameObject selectedTower;
    GameObject towerOnMouse;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

        if (Physics.Raycast(ray, out hit))
        {


            if (hit.collider.tag == "placeableArea")
            {
                mousePostionRaycast = hit.point;
                currentTower = null;
            }
            else if (hit.collider.tag == "Tower")
            {
                mousePostionRaycast = new Vector3(float.NaN, float.NaN, float.NaN);
                currentTower = hit.collider.gameObject;

            }
            else
            {
                mousePostionRaycast = new Vector3(float.NaN, float.NaN, float.NaN);
                currentTower = null;
            }

        }
        if (towerOnMouse) { 
        
        
        }
        if (Input.GetMouseButtonDown(0))
        {


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
    void towerSelectedEvent(GameObject tower)
    {
        Vector3 mousPos = Input.mousePosition;
        Ray ray = cam.ScreenPointToRay(mousPos);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        towerOnMouse = tower;
        Instantiate(towerOnMouse, hit.point , Quaternion.identity);
    }
}
