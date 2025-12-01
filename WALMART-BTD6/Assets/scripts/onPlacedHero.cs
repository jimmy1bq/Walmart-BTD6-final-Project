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
        Instantiate(replacementGUI, gameObject.transform);
        Destroy(gameObject);
    }
}
