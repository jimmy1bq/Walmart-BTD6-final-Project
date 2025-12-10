using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class xpGained : MonoBehaviour
{
   int levelRightNow = 0;
   int curXp = 0;
   int curXpNeeded = 100;
    private void Awake()
    {
      //  Object.DontDestroyOnLoad(this.gameObject);
        events.gainExp.AddListener(gainEXPs);
    }
    private void Start()
    {
       
    }
    void levelUp() { 
        curXpNeeded += 10+(levelRightNow/2);
        curXp = 0;
        LeanTween.value(gameObject, gameObject.GetComponent<Slider>().value, curXp, 2f);
    }
    void gainEXPs(int expVal) { 
    curXp += expVal;
        if (curXp >= curXpNeeded) { 
            levelRightNow++;
            curXp = curXp-curXpNeeded;
            events.levelUp.Invoke(levelRightNow);
            levelUp();
            gameObject.transform.Find("level").GetComponent<TextMeshProUGUI>().text = "Level "+levelRightNow;
        }
        float progress = (float)curXp / (float)curXpNeeded;
        //ty to claude or chatgpt for showing me how to use LeanTween.Value
        LeanTween.value(gameObject, gameObject.GetComponent<Slider>().value, progress, 0.5f).setOnUpdate((expVal) =>
        {
            gameObject.GetComponent<Slider>().value = expVal;
        });

    }
}
