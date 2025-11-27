using UnityEngine;

public class leftnrightTargetScript : MonoBehaviour
{
    public void leftTarget()
    {
       
        events.changeTarget.Invoke(-1);
    }
    public void rightTarget()
    {
      
        events.changeTarget.Invoke(1);
    }
}
