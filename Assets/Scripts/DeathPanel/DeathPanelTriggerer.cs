using System.Collections;
using System.Collections.Generic;
using EditorPlus;
using UnityEngine;

public class DeathPanelTriggerer : MonoBehaviour
{
    public float ObjectSize;
    
    [Button]
    public void TriggerDeathPanelOnCurrent()
    {
        DeathPanelAnimator.Instance.StartAnimationAt(transform.position, ObjectSize);
    }
}
