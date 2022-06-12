using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MarkerController : MonoBehaviour
{
    public Animator Animator;
    public float AnimOutDuration;
    private static readonly int OnOut = Animator.StringToHash("OnOut");

    public void OnEnable()
    {
        var unit = transform.parent.parent;
        if (!unit)
            return;
        
        unit.GetComponent<UnitDieBehaviour>().OnDie.AddListener(OnDie);
    }

    private void OnDie()
    {
        transform.parent = null;
        Animator.SetTrigger(OnOut);
        Destroy(gameObject, AnimOutDuration);
    }
}
