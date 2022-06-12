using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvincibility : MonoBehaviour
{
    public float InvincibilityDuration;
    
    void OnEnable()
    {
        StartInvincibility();
        StartCoroutine(EndInvincibilityAfter(InvincibilityDuration));
    }

    private IEnumerator EndInvincibilityAfter(float value)
    {
        yield return new WaitForSeconds(value);
        EndInvincibility();
    }

    private void StartInvincibility()
    {
        foreach (var collider in transform.parent.GetComponents<Collider2D>())
            collider.enabled = false;
    }
    private void EndInvincibility()
    {
        foreach (var collider in transform.parent.GetComponents<Collider2D>())
            collider.enabled = true;
    }
} 
