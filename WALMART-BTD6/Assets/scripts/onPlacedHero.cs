using UnityEngine;

public class onPlacedHero : MonoBehaviour
{
    [SerializeField] GameObject replacementGUI;
    private void Awake()
    {
        events.heroPlaced.AddListener(heroPlaceds);
    }

    void heroPlaceds(int nothing)
    {
        gameObject.SetActive(false);
        replacementGUI.SetActive(true);
    }
}
