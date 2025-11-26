using TMPro;
using UnityEngine;

public class updateMonkeyMoney : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("hi");
        events.onLoad.AddListener(updateGUI);
    }
   void updateGUI(int money)
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = money.ToString();
    }
}
