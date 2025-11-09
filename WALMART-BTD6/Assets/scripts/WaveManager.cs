using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject redbox;
    [SerializeField] GameObject pinkbox;
    [SerializeField] GameObject blueBox;
    [SerializeField] GameObject greenBox;
    [SerializeField] GameObject yellowBox;

    [SerializeField] GameObject blackbox;
    [SerializeField] GameObject whitebox;
    [SerializeField] GameObject metalBox;
    [SerializeField] GameObject purpleBox;
    [SerializeField] GameObject orangeBox;
    [SerializeField] GameObject seaGreenBox;
    [SerializeField] GameObject ceramucBox;


    [SerializeField] Transform spawnPoint;


    bool waveOnGoing = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        waveOnGoing = true;
        startWave1();
     //   StartCoroutine(spawnPink());
    }

    // Update is called once per frame
    void Update()
    { 
    }
    void startWave1()
    {
        Instantiate(pinkbox, spawnPoint.position, Quaternion.identity);
        Instantiate(redbox, spawnPoint.position, Quaternion.identity);
        Instantiate(greenBox, spawnPoint.position, Quaternion.identity);
        Instantiate(blueBox, spawnPoint.position, Quaternion.identity);
        Instantiate(yellowBox, spawnPoint.position, Quaternion.identity);
        Instantiate(whitebox, spawnPoint.position, Quaternion.identity);

        Instantiate(blackbox, spawnPoint.position, Quaternion.identity);
        Instantiate(orangeBox, spawnPoint.position, Quaternion.identity);
        Instantiate(purpleBox, spawnPoint.position, Quaternion.identity);
        Instantiate(seaGreenBox, spawnPoint.position, Quaternion.identity);
        Instantiate(metalBox, spawnPoint.position, Quaternion.identity);
        Instantiate(ceramucBox, spawnPoint.position, Quaternion.identity);
    }
    IEnumerator spawnPink() {

        yield return new WaitForSeconds(1);
        Instantiate(pinkbox, spawnPoint.position, Quaternion.identity);
        StartCoroutine(spawnPink());
       
    }
}
