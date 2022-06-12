using System;
using UnityEngine;
using UnityEngine.Events;

public class ShootController : MonoBehaviour
{

    public float rifleCooldown = 1.0f;
    public bool isRifleReady => timer <= 0;

    public ShootingBehaviour ShootingBehaviour;

    public UnityEvent ShotFired;
    public UnityEvent EmptyMagazine;

    private float timer;
    
    void Start()
    {
        timer = 0;
        UpdateShootingBehaviour();
    }

    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (!isRifleReady)
        {
            EmptyMagazine.Invoke();
        }
        else
        {
            ShotFired.Invoke();
            ShootingBehaviour.Shoot();
            timer = rifleCooldown;
        }
    }

    private void OnEnable()
    {
        UpdateShootingBehaviour();
    }

    private void UpdateShootingBehaviour()
    {
        ShootingBehaviour = transform.parent.GetComponent<ShootingBehaviour>();
    }
}
