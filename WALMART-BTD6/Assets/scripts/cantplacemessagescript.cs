using System.Collections;

using UnityEngine;


public class cantplacemessagescript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnEnable()
    {
        StartCoroutine(selfDestroy());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator  selfDestroy() {


        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
