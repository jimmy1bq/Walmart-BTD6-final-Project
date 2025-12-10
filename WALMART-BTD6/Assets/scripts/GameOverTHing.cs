using NUnit.Framework.Internal.Execution;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTHing : MonoBehaviour
{
    private void Awake()
    {
        events.gameOverEvent.AddListener(gameOverMethod);
    }
    void gameOverMethod(int moneyEarned,bool WorL) {       
        if (WorL) {
            Image statusGUI = gameObject.transform.Find("loseImage").GetComponent<Image>();
            statusGUI.sprite = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Resources/MiscellaniousGUI/winSprite.png");
        } 
        gameObject.LeanMove(new Vector3(830, 550, 0), 1f);
        gameObject.transform.Find("mmearned").GetComponent<TextMeshProUGUI>().text = "+"+GameManager.instance.totalAccumMonkeyMoney.ToString();
        StartCoroutine(waitForfuncton());
      
        //works only if you go from scene 0->this      
        moneytracker.instance.addMonkeyMoney(moneyEarned);


    }
    IEnumerator waitForfuncton() {

        yield return new WaitForSeconds(2f);
        Time.timeScale = 0f;
    }

    
    

}
