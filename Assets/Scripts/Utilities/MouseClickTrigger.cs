using UnityEngine;
using UnityEngine.Events;

public class MouseClickTrigger : MonoBehaviour
{
    public UnityEvent LeftMouseTrigger;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            LeftMouseTrigger.Invoke();
        }
    }
}
