using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Rendering;

public class WaveManager : MonoBehaviour
{

    static WaveManager instance;
    string enemiesFolder = "Assets/Resources/boxEnemiesWScript/";
    
    Dictionary<string, GameObject> boxTypeToString = new Dictionary<string, GameObject>() {
    };
    List<string> boxName = new List<string>() { 
    "red","blue","green","yellow","pink","black","white","purple","metal","orange","seaGreen","ceramic","blueTank","redTank","zomgTank","blackTank","purpleTank","tankFortThe1ST","tankFortThe2ND","tankFortThe3RD"
    };
    //milestone 7 don't forget to say layer mask change
    List<string> camoBoxName = new List<string>() {
    "camoRed","camoBlue","camoGreen","camoYellow","camoPink","camoBlack","camoWhite","camoPurple","camoMetal","camoOrange","camoSeaGreen","camoCeramic"
    };

    List<waves> listOfWaves = new List<waves>();

    [SerializeField] Transform spawnPoint;

    int index = 0;
    int wave = 1;

    public bool waveOnGoing = false;
    bool alternativeMap = false;
    string pathToGUIs = "Assets/Resources/MiscellaniousGUI/";

    public delegate void waves();
    public static waveStart waveDelegate;

    private void Awake()
    {
        if (GameObject.Find("Base") != null) {
            alternativeMap = true;        
        }
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
        listOfWaves.Add(startWave7);
        listOfWaves.Add(startWave8);
        listOfWaves.Add(startWave9);
        listOfWaves.Add(startWave10);
        listOfWaves.Add(startWave11);
        listOfWaves.Add(startWave12);
        listOfWaves.Add(startWave13);
        listOfWaves.Add(startWave14);
        listOfWaves.Add(startWave15);
        listOfWaves.Add(startWave16);
        listOfWaves.Add(startWave17);
        listOfWaves.Add(startWave18);
        listOfWaves.Add(startWave19);
        listOfWaves.Add(startWave20);
        listOfWaves.Add(startWave21);
        listOfWaves.Add(startWave22);
        listOfWaves.Add(startWave23);
        listOfWaves.Add(startWave24);
        listOfWaves.Add(startWave25);
        listOfWaves.Add(startWave26);
        listOfWaves.Add(startWave27);
        listOfWaves.Add(startWave28);
        listOfWaves.Add(startWave29);
        listOfWaves.Add(startWave30);
        listOfWaves.Add(startWave31);
        listOfWaves.Add(startWave32);
        listOfWaves.Add(startWave33);
        listOfWaves.Add(startWave34);
        listOfWaves.Add(startWave35);
        listOfWaves.Add(startWave36);
        listOfWaves.Add(startWave37);
        listOfWaves.Add(startWave38);
        listOfWaves.Add(startWave39);
        listOfWaves.Add(startWave40);
        listOfWaves.Add(startWave41);
        listOfWaves.Add(startWave42);
        listOfWaves.Add(startWave43);
        listOfWaves.Add(startWave44);
        listOfWaves.Add(startWave45);
        listOfWaves.Add(startWave46);
        listOfWaves.Add(startWave47);
        listOfWaves.Add(startWave48);
        listOfWaves.Add(startWave49);
        listOfWaves.Add(startWave50);
        listOfWaves.Add(startWave51);
        listOfWaves.Add(startWave52);
        listOfWaves.Add(startWave53);
        listOfWaves.Add(startWave54);
        listOfWaves.Add(startWave55);
        listOfWaves.Add(startWave56);
        listOfWaves.Add(startWave57);
        listOfWaves.Add(startWave58);
        listOfWaves.Add(startWave59);
        listOfWaves.Add(startWave60);
    }
    //spawn between z 16.83 to -16.83 y1.19 x-25.35
    void startWave1() {
        waveOnGoing = true;
       // StartCoroutine(spawnTimeInbetween(boxTypeToString["metal"], 20, 1f));
         StartCoroutine(spawnTimeInbetween(boxTypeToString["red"], 10, 1f));
       // StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoCeramic"], 1, 1f),5f));
       // StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["blueTank"], 1, 1f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 20f));
        
    }
    void startWave2()
    {
        waveOnGoing = true;
        StartCoroutine(spawnTimeInbetween(boxTypeToString["red"], 35, 1f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 35f));
    }
    void startWave3()
    {
        waveOnGoing = true;
        StartCoroutine(spawnTimeInbetween(boxTypeToString["blue"], 12, 1f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["green"], 1, 2f), 10f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 20f));
    }

    void startWave4()
    {
        waveOnGoing = true;
        StartCoroutine(spawnTimeInbetween(boxTypeToString["blue"], 10, 1f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["green"], 5, 2f), 10f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 30f));
    }

    void startWave5()
    {

        waveOnGoing = true;
        StartCoroutine(spawnTimeInbetween(boxTypeToString["blue"], 13, 0.5f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["yellow"], 3, 2f), 10f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 24f));
    }
    void startWave6()
    {
        waveOnGoing = true;
        StartCoroutine(spawnTimeInbetween(boxTypeToString["green"], 3, 0.5f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["yellow"], 7, 2f), 10f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 24f));
    }

    void startWave7()
    {
        waveOnGoing = true;
        StartCoroutine(spawnTimeInbetween(boxTypeToString["green"], 5, 0.5f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["pink"], 5, 2f), 10f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 20f));
    }

    void startWave8()
    {
        waveOnGoing = true;
        StartCoroutine(spawnTimeInbetween(boxTypeToString["green"], 5, 0.5f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["green"], 12, 2f), 10f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 34f));
    }

    void startWave9()
    {
        waveOnGoing = true;
        StartCoroutine(spawnTimeInbetween(boxTypeToString["green"], 5, 0.5f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["green"], 12, 2f), 5f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["red"], 12, 2f), 8f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["yellow"], 12, 2f), 10f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 34f));
    }

    void startWave10()
    {
        waveOnGoing = true;
        StartCoroutine(spawnTimeInbetween(boxTypeToString["green"], 5, 0.5f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["green"], 12, 2f), 5f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["red"], 12, 2f), 8f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["yellow"], 12, 2f), 10f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 34f));
    }

    void startWave11()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["green"], 12, 2f), 5f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["blue"], 40, 1f), 8f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["yellow"], 15, 2f), 15f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 48f));
    }
    void startWave12()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["yellow"], 30, 3f), 10f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 100f));
    }

    void startWave13()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoYellow"], 10, 3f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 30f));
    }
    void startWave14()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["pink"], 13, 2f), 2f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoYellow"], 10, 3f), 5f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 35f));
    }

    void startWave15()
    {
        waveOnGoing = true;
        StartCoroutine(spawnTimeInbetween(boxTypeToString["blue"], 30, 2f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["white"], 5, 3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["black"], 5, 3f), 7f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 22f));
    }
    void startWave16()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["yellow"], 15, 3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["green"], 15, 3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["blue"], 10, 3f), 5f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 30f));
    }
    void startWave17()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["red"], 100, 0.5f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 50f));
    }
    void startWave18()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["metal"], 20, 1f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 20f));
    }

    void startWave19()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["metal"], 30, 0.5f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 15f));
    }

    void startWave20()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["metal"], 5, 3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["black"], 5, 3f), 2f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["white"], 5, 3f), 3f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["orange"], 5, 3f), 5f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 20f));
    }
    void startWave21()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoYellow"], 10, 3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoPink"], 10, 1f), 5f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoWhite"], 5, 2f), 7f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 22f));
    }
    void startWave22()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["red"], 10, 2f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["blue"], 10, 4f), 2f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["green"], 10, 3f), 3f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["yellow"], 10, 1f), 4f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["pink"], 10, 5f), 5f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 55f));
    }
    void startWave23()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["seaGreen"], 5, 1f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 5f));
    }
    void startWave24()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["seaGreen"], 10, 1f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["orange"], 10, 1f), 3f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoOrange"], 1, 1f), 5f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 13f));
    }
    void startWave25()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["yellow"], 10, 3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["orange"], 16, 3f), 3f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["white"], 12, 3f), 5f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 41f));
    }
    void startWave26()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["white"], 10, 1.5f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["black"], 10, 2.5f), 3f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["seaGreen"], 5, 3f),20f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["ceramic"], 3, 3f), 30f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 39f));
    }
    void startWave27()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["ceramic"], 10, 2.3f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 23f));
    }
    void startWave28()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["white"], 10, 1.5f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["black"], 10, 2.5f), 3f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["metal"], 10, 5f), 3f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["seaGreen"], 5, 3f), 20f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 53f));
    }
    void startWave29()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["ceramic"], 10, 2.3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["seaGreen"], 5, 3f), 10f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 34f));
    }
    void startWave30()
    {
        waveOnGoing = true;
        if (GameObject.Find("Base") != null)
        {
            events.GainCash.Invoke(3000);
            StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["tankFortThe1ST"], 1, 0f), 10f));
        }
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["blueTank"], 1, 0f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 1f));
    }
    void startWave31()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoYellow"], 10, 3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoWhite"], 10, 3f), 3f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["metal"], 10, 3f), 8f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 38f));
    }
    void startWave32()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["red"], 100, 0.5f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 50f));
    }
    void startWave33()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoRed"], 100, 0.5f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 50f));
    }
    void startWave34()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["blueTank"], 2, 20f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["metal"], 20, 2f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["purple"], 20, 0.5f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 40f));
    }
    void startWave35()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoMetal"], 5, 2f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 10f));
    }
    void startWave36()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoYellow"], 10, 3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoPurple"], 10, 3f), 5f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 34f));
    }
    void startWave37()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["blueTank"], 5, 25f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 100f));
    }
    void startWave38()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoYellow"], 10, 3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoYellow"], 10, 3f), 3f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoYellow"], 10, 3f), 5f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoYellow"], 10, 3f), 6f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 36f));
    }
    void startWave39()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["ceramic"], 10, 3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoCeramic"], 5, 3f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 34f));
    }
    void startWave40()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoSeaGreen"], 10, 3f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 34f));
    }
    void startWave41()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["yellow"], 100, 0.5f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 50f));
    }
    void startWave42()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["blue"], 60, 3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["yellow"],60, 1f),15f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["green"], 60, 1f), 30f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 80f));
    }
    void startWave43()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["seaGreen"], 35, 0.5f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 17.5f));
    }
    void startWave44()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["seaGreen"], 35,0.5f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["seaGreen"], 35, 0.5f), 50f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 67.5f));
    }
    void startWave45()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["redTank"], 1, 3f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 34f));
    }
    void startWave46()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["blueTank"], 8, 10f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 34f));
    }
    void startWave47()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoMetal"], 30, 1f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 30f));
    }
    void startWave48()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoCeramic"], 20, 2f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 40f));
    }
    void startWave49()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoPink"], 10, 3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["pink"], 10, 3f), 10f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoPink"], 10, 3f), 20f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["pink"], 15, 3f), 30f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoPink"], 15, 3f), 45f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["pink"], 15, 3f), 45f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 75f));
    }
    void startWave50()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoYellow"], 10, 3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["yellow"], 10, 3f), 10f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoYellow"], 10, 3f), 20f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["yellow"], 15, 3f), 30f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoYellow"], 15, 3f), 45f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["yellow"], 15, 3f), 45f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 34f));
    }
    void startWave51()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoGreen"], 20, 3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["green"], 20, 3f), 10f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoGreen"], 20, 3f), 20f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["green"], 30, 3f), 30f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoGreen"], 30, 3f), 45f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["green"], 30, 3f), 45f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 75f));
    }
    void startWave52()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoBlue"], 30, 3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["blue"], 30, 3f), 10f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoBlue"], 30, 3f), 20f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["blue"], 40, 3f), 30f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoBlue"], 40, 3f), 45f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["blue"], 40, 3f), 45f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 75f));
    }
    void startWave53()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoRed"], 1, 3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["redTank"], 2, 10f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 1f));
    }
    void startWave54()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["zomgTank"], 1, 3f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 34f));
    }
    void startWave55()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["blueTank"], 10, 10f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 100f));
    }
    void startWave56()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["blueTank"], 2, 10f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["redTank"], 3, 20f), 50f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 110f));
    }
    void startWave57()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoCeramic"], 25, 3f), 0f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoSeaGreen"], 25, 3f), 50f));
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["camoOrange"], 25, 3f), 53f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 128f));
    }
    void startWave58()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["blue"], 300, 0.5f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 150f));
    }
    void startWave59()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["redTank"], 4, 30f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 90f));
    }
    void startWave60()
    {
        waveOnGoing = true;
        StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["zomgTank"], 2, 30f), 0f));
        StartCoroutine(delayedSpawn(onGoingWaveCheck(), 30f));
    }















    IEnumerator spawnTimeInbetween(GameObject boxsToSpawn, int amountToSpawn,float seconds) {

        if (alternativeMap) {
            for (int i = amountToSpawn; i > 0; i--)
            {
                float z=UnityEngine.Random.Range(-16.83f,16.83f); 
                Instantiate(boxsToSpawn, new Vector3(-25.35f,1.19f,z), Quaternion.identity);
                yield return new WaitForSeconds(seconds);

            }
        } 
        else 
        {
            for (int i = amountToSpawn; i > 0; i--)
            {
                Instantiate(boxsToSpawn, spawnPoint.position, Quaternion.identity);
                yield return new WaitForSeconds(seconds);

            }
        }
           
              
    }
    IEnumerator delayedSpawn(IEnumerator coroutine,float timer)
    {
        yield return new WaitForSeconds(timer);
        StartCoroutine(coroutine);
    }
    IEnumerator onGoingWaveCheck() {
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
            if (wave == 60)
            {
                events.gameOverEvent.Invoke(GameManager.instance.totalAccumMonkeyMoney, true);
            }
            wave++;
            Time.timeScale = 1f;
            events.GainCash.Invoke(100);
            events.waveOver.Invoke(false);
            Transform startWaveButtonThing = null;
            Canvas canvasGUI=FindFirstObjectByType<Canvas>();
            int cc = canvasGUI.transform.childCount;
            startWaveButtonThing = canvasGUI.transform.Find("speedUpButton(Clone)");
           
            if (startWaveButtonThing == null) {
                startWaveButtonThing = canvasGUI.transform.Find("speedDownButton(Clone)");
            }
            GameObject speedUpButton = Instantiate(UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(pathToGUIs + "WaveStartButton" + ".prefab"), startWaveButtonThing.transform.position, Quaternion.identity);
            speedUpButton.transform.parent = canvasGUI.transform;
            GameManager.instance.totalAccumMonkeyMoney += 10;
            Destroy(startWaveButtonThing.gameObject);
        }
    }
    bool nextWave() {
        if ((index <= listOfWaves.Count - 1) && !waveOnGoing)
        {
            events.waveOver.Invoke(true);
            listOfWaves[index].Invoke();
            index++;
            return true;
        }
        return false;   
    }

}
//StartCoroutine(spawnTimeInbetween(boxTypeToString["blueTank"], 1, 1f));
//StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["redTank"], 1, 1f), 0f));
//StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["zomgTank"], 1, 1f), 5f));
//StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["blackTank"], 1, 1f), 10f));
//StartCoroutine(delayedSpawn(spawnTimeInbetween(boxTypeToString["purpleTank"], 1, 1f), 0f));