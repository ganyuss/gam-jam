using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootingBehaviour : MonoBehaviour
{
    public Animator animator;
    public PrefabInstantiator prefabInstantiator;
    
    public UnityEvent ShotFired;

    public void Shoot()
    {
        animator.SetTrigger("shoot");
    }

    void AfterAnimationShoot()
    {
        prefabInstantiator.InstantiatePrefab();
        ShotFired.Invoke();
    }
}
