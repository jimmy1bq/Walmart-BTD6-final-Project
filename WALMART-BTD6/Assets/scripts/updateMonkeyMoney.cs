using TMPro;
using UnityEngine;

public class updateMonkeyMoney : MonoBehaviour
{
    private void Awake()
    {
        
     
      
    }
    private void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = moneytracker.instance.monkeyMoney.ToString();
    }
   
}
