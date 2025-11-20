using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class WaveManager : MonoBehaviour
{
    string enemiesFolder = "Assets/Resources/boxEnemiesWScript/";
    
    Dictionary<string, GameObject> boxTypeToString = new Dictionary<string, GameObject>() {
    };
    List<string> boxName = new List<string>() { 
    "red","blue","green","yellow","pink","black","white","purple","metal","orange","seaGreen","ceramic"
    };
   

    [SerializeField] Transform spawnPoint;

    bool waveOnGoing = false;

    private void Awake()
    {
        foreach (string bn in boxName) {
            GameObject boxToInsert = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemiesFolder + bn + ".prefab");
            boxTypeToString.Add(bn,boxToInsert);
        }
    }

    void Start()
    {
        startWave1();
    }
    void startWave1() {
        StartCoroutine(spawnTimeInbetween(boxTypeToString["red"], 20, 1f));
    }

   
    IEnumerator spawnTimeInbetween(GameObject boxsToSpawn, int amountToSpawn,float seconds) {
    if(amountToSpawn != 0) 
        {
            Instantiate(boxsToSpawn, spawnPoint.position,Quaternion.identity);
            yield return new WaitForSeconds(seconds);
            StartCoroutine(spawnTimeInbetween(boxsToSpawn, amountToSpawn - 1, seconds));
        }      
    }
}
