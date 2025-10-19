using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "balloonScriptableObject")]
public class boxscriptableObj : ScriptableObject {

    public GameObject redb;
    public GameObject blueb;
    public GameObject greenb;
    public GameObject yellowb;
    public GameObject pinkb;
   


    //I guess I could run balloon hp on this but yap
    private void OnEnable()
    {
        
    }
}
