using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "balloonScriptableObject")]
public class boxscriptableObj : ScriptableObject {
    public int i = 1;
    public GameObject redb;
    public GameObject blueb;
    public GameObject greenb;
    public GameObject yellowb;
    public GameObject pinkb;
    public GameObject blackb;
    public enum boxType
    {
        none, red, blue, green, yellow, pink, black, white, purple, lead, orange, seagreen
    }
    public enum bigBoxType
    {
        ceramic, moab, bfb, zomg, ddt, bad
    }
    public List<GameObject> objects;
    public boxType[] boxArray = ((boxType[])System.Enum.GetValues(typeof(boxType)));
    public Dictionary<boxType, GameObject> boxTypeToGO;

    private void OnEnable()
    {
        boxTypeToGO = new Dictionary<boxType, GameObject>();
        if (boxTypeToGO==null) {
            for (int j = 0; j < objects.Count; j++)
            {
                var balloon = objects[j];
                var type = boxArray[j+1];
                if (!boxTypeToGO.ContainsKey(type))
                {
                    boxTypeToGO.Add(type, balloon);
                }
            }
        }
    }

}
