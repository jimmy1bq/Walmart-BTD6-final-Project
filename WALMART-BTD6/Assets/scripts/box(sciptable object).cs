using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "balloonScriptableObject")]
public class boxSO : ScriptableObject {
    public int i = 1;
  
    public enum boxType
    {
        none, red, blue, green, yellow, pink, black, white, purple, lead, orange, seagreen,
        ceramic, moab, bfb, zomg, ddt, bad
    }
    public List<GameObject> objects;
    public boxSO.boxType[] boxArray = ((boxSO.boxType[])System.Enum.GetValues(typeof(boxSO.boxType)));
    public Dictionary<boxSO.boxType, GameObject> boxTypeToGO;
    public Dictionary<int,GameObject> boxsesOnMap = new Dictionary<int,GameObject>();
   
    public int ID = 0;
    private void OnEnable()
    {
      
        if (boxTypeToGO==null) {
            boxTypeToGO = new Dictionary<boxSO.boxType, GameObject>();
            for (int j = 0; j < objects.Count; j++)
            {
                var balloon = objects[j];
                var type = boxArray[j];
                if (!boxTypeToGO.ContainsKey(type))
                {
                    boxTypeToGO.Add(type, balloon);
                }
            }
        }
    }
    private void OnDisable()
    {
        ID = 0;   
        boxsesOnMap.Clear();   
    }

}
