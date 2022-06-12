using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyHijacker : MonoBehaviour
{
    private List<Type> ComponentsToDisable = new List<Type>
    {
        typeof(ClosestTargetBehavior),
        typeof(LookAtTarget),
        typeof(AllyBehavior),
        
    };

    void Awake()
    {
        Hijack();
    }

    void OnEnable()
    {
        Hijack();
    }

    private void Hijack()
    {
        var parent = transform.parent.gameObject;
        foreach (var componentType in ComponentsToDisable)
        {
            ((MonoBehaviour)parent.GetComponent(componentType)).enabled = false;
        }
    }
}
