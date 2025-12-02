using UnityEngine;

public class onTowerSold : MonoBehaviour
{
    [SerializeField] GameObject replacementGUI;
    private void Awake()
    {
        events.heroSold.AddListener(heroSolds);
    }

    void heroSolds(int nothing)
    {
        gameObject.SetActive(false);
        replacementGUI.SetActive(true);
    }
}
