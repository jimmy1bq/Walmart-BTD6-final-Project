using UnityEngine;
using UnityEngine.Rendering;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject redbox;
    [SerializeField] GameObject pinkbox;
    [SerializeField] GameObject blueBox;
    [SerializeField] GameObject greenBox;
    [SerializeField] GameObject yellowBox;
  
    [SerializeField] Transform spawnPoint;


    bool waveOnGoing = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        waveOnGoing = true;
        startWave1();
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
    }
}
