using UnityEngine;
using UnityEngine.Rendering;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject redbox;
    [SerializeField] GameObject pinkbox;
    [SerializeField] Transform spawnPoint;


    bool waveOnGoing = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   Debug.Log("Wave starting....");
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
    }
}
