using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class BaseScript : MonoBehaviour, IDamageTaken
{
    float hp = 200;
    float totalHp = 200;
    [SerializeField] GameObject baseHp;
    [SerializeField] TextMeshProUGUI baseHpDisplay;
    public void damageTaken(int damageAmount, GameObject balloonDamage)
    {

        hp -= damageAmount;
        baseHpDisplay.text = hp.ToString() + "/" + totalHp.ToString();
        float progress = hp / totalHp;
        Debug.Log(baseHp.GetComponent<Slider>());
        LeanTween.value(baseHp, baseHp.GetComponent<Slider>().value, progress, 0.5f).setOnUpdate((expVal) =>
        {
           baseHp.GetComponent<Slider>().value = expVal;
        });
        if (hp <= 0)
        {
          events.gameOverEvent.Invoke(GameManager.instance.totalAccumMonkeyMoney, false);
        }
    }
}
