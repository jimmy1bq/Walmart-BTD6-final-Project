using System.Collections.Generic;
using UnityEngine;

public class towerParentCS : MonoBehaviour
{
    public static towerParentCS instance;
    Dictionary<int, GameObject> dartMonkeyPathToModel = new Dictionary<int, GameObject>();

    [SerializeField] List<int> dartMonkeylistOfUpgrades;
    [SerializeField] List<GameObject> dartMonkeylistOfModels;

    int index = 0;
    //added this script for milestone 4:
    //the serializefield list will map the upgradepath to model with 9=0 since i can't type in 010 so i have to settle for 910
    private void Awake()
    {
        foreach (int crosspath in dartMonkeylistOfUpgrades) { 
        dartMonkeyPathToModel.Add(crosspath, dartMonkeylistOfModels[index]);
        index++;
        }
        foreach (var h in dartMonkeyPathToModel) {
            Debug.Log(h.Key);
            Debug.Log(h.Value);
        }
       
    
       
        
    }
}
//Code for updating tower model 
//GameObject dartMonkey = Instantiate(dartMonkeyPathToModel[0], gameObject.transform.position, Quaternion.identity);
//for (int i = dartMonkey.transform.childCount-1; i >= 0; i--)
//{
//    Debug.Log(i);
//    Destroy(dartMonkey.transform.GetChild(i).gameObject);
//}
//GameObject newdartMonkey = Instantiate(dartMonkeyPathToModel[0], gameObject.transform.position, Quaternion.identity);
//newdartMonkey.transform.parent = dartMonkey.transform;

