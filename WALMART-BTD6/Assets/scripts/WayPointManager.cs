using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{   public static WayPointManager instance;
    public List<Transform> wayPoints = new List<Transform>();
    private void Awake()
    {   instance = this;
        foreach (GameObject h in GameObject.FindGameObjectsWithTag("WayPoints"))
        {  
            wayPoints.Add(h.transform);
        }
        wayPoints.Sort((a, b) => a.name.CompareTo(b.name));
     
    }
   
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
