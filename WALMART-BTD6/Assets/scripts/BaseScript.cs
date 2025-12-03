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
        if (hp > 0)
        {
            Debug.Log("HI");
            events.LoseLives.Invoke(damageAmount);
            hp -= damageAmount;
            baseHpDisplay.text = hp.ToString() + "/" + totalHp.ToString();
            float progress = hp / totalHp;

     
            LeanTween.value(baseHp, baseHp.GetComponent<Slider>().value, progress, 0.5f).setOnUpdate((expVal) =>
            {
                baseHp.GetComponent<Slider>().value = expVal;
            });
        }
        //if (hp <= 0)
        //{
        //  events.gameOverEvent.Invoke(GameManager.instance.totalAccumMonkeyMoney, false);
        //}
    }
}
