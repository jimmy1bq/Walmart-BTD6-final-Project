using UnityEngine;
using NUnit.Framework.Internal.Execution;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class gamePaused : MonoBehaviour
{
    private void Awake()
    {
        events.gamePaused.AddListener(gameOverMethod);
    }
    void gameOverMethod(int moneyEarned)
    {
        gameObject.LeanMove(new Vector3(830, 550, 0), 1f);
        StartCoroutine(waitForfuncton());
        //works only if you go from scene 1->this
        //   moneytracker.instance.monkeyMoney += moneyEarned;


    }
    IEnumerator waitForfuncton()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0f;
    }

}
