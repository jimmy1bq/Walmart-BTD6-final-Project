using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "balloonScriptableObject")]
public class boxSO : ScriptableObject {
    public int i = 1;

  
    public int ID = 0;

    private void OnDisable()
    {
        ID = 0;
    }

}
