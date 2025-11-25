using UnityEngine;

public class leftnrightTargetScript : MonoBehaviour
{
    public void leftTarget()
    {
        Debug.Log("INVOEKD");
        events.changeTarget.Invoke(-1);
    }
    public void rightTarget()
    {
        Debug.Log("INVOEKD");
        events.changeTarget.Invoke(1);
    }
}
