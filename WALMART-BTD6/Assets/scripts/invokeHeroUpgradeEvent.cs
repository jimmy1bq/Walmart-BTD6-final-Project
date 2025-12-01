using UnityEngine;

public class invokeHeroUpgradeEvent : MonoBehaviour
{
    public void onCall() {
        events.heroUpgrade.Invoke(1);
    
    }
}
