using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime;
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

    List<string> camoBoxName = new List<string>() {
    "camoRed","camoBlue","camoGreen","camoYellow","camoPink","camoBlack","camoWhite","camoPurple","camoMetal","camoOrange","camoSeaGreen","camoCeramic"
    };

    List<waves> listOfWaves = new List<waves>();

    [SerializeField] Transform spawnPoint;

    int index = 0;

    bool waveOnGoing = false;
    string pathToGUIs = "Assets/Resources/MiscellaniousGUI/";

    public delegate void waves();
    public static waveStart waveDelegate;

    private void Awake()
    {
        waveDelegate += nextWave;
        foreach (string bn in boxName)
        {
            GameObject boxToInsert = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemiesFolder + bn + ".prefab");
            boxTypeToString.Add(bn, boxToInsert);
        }
        foreach (string bn in camoBoxName)
        {
            GameObject boxToInsert = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(enemiesFolder + bn + ".prefab");
            boxTypeToString.Add(bn, boxToInsert);
        }
    }
    void Start()
    {
        listOfWaves.Add(startWave1);
        listOfWaves.Add(startWave2);
        listOfWaves.Add(startWave3);
        listOfWaves.Add(startWave4);
        listOfWaves.Add(startWave5);
        listOfWaves.Add(startWave6);
    }
    void startWave1() {
        waveOnGoing = true;
        StartCoroutine(spawnTimeInbetween(boxTypeToString["metal"], 20, 1f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoMetal"], 20, 1f), 10f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 20f));
    }
    void startWave2()
    {
        waveOnGoing = true;
        StartCoroutine(spawnTimeInbetween(boxTypeToString["red"], 35, 1f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["blue"], 5, 2f),10f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 25f));
    }
    void startWave3()
    {
        waveOnGoing = true;
        StartCoroutine(spawnTimeInbetween(boxTypeToString["blue"], 10, 1f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["green"], 5, 2f), 10f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 30f));
    }

    void startWave4()
    {
        waveOnGoing = true;
        StartCoroutine(spawnTimeInbetween(boxTypeToString["blue"], 10, 1f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["green"], 10, 2f), 10f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 30f));
    }

    void startWave5()
    {

        waveOnGoing = true;
        StartCoroutine(spawnTimeInbetween(boxTypeToString["blue"], 15, 0.5f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["yellow"], 7, 2f), 10f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 27.5f));
    }
    void startWave6()
    {

        waveOnGoing = true;
        StartCoroutine(spawnTimeInbetween(boxTypeToString["metal"], 15, 0.5f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["yellow"], 7, 2f), 10f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 27.5f));
    }
















    IEnumerator spawnTimeInbetween(GameObject boxsToSpawn, int amountToSpawn,float seconds) {
    if(amountToSpawn != 0) 

        {
            Instantiate(boxsToSpawn, spawnPoint.position,Quaternion.identity);
            yield return new WaitForSeconds(seconds);
            StartCoroutine(spawnTimeInbetween(boxsToSpawn, amountToSpawn - 1, seconds));
        }      
    }
    IEnumerator delayedSpawn(IEnumerator coroutine,float timer)
    {
        yield return new WaitForSeconds(timer);
        StartCoroutine(coroutine);
    }
    IEnumerator onGoingWaveCheck() {
        Debug.Log("Checking");
        if (waveOnGoing) {
            Collider[] balloonsOnMap = Physics.OverlapSphere(gameObject.transform.position, 1000, (1 << 9));
            if (balloonsOnMap.Length == 0) {
                waveOnGoing = false;
            }
        }
        if (waveOnGoing)
        {
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(onGoingWaveCheck());
        }
        else {
            Canvas canvasGUI=FindFirstObjectByType<Canvas>();
            int cc = canvasGUI.transform.childCount;
            GameObject startWaveButtonThing = canvasGUI.transform.GetChild(cc-1).gameObject;
            GameObject speedUpButton = Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(pathToGUIs + "WaveStartButton" + ".prefab"), startWaveButtonThing.transform.position, Quaternion.identity);
            speedUpButton.transform.parent = canvasGUI.transform;
            Destroy(startWaveButtonThing);
        }
    }
    bool nextWave() {
        if ((index <= listOfWaves.Count - 1) && !waveOnGoing)
        {
            listOfWaves[index].Invoke();
            index++;
            return true;
        }
        return false;   
    }

}
