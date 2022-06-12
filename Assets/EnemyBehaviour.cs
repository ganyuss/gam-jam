using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public ShootingBehaviour ShootingBehaviour;
    
    [Space]
    public float MaxCooldown;
    public float Cooldown;

    void Update()
    {
        if (Cooldown > 0)
        {
            Cooldown -= Time.deltaTime;
            return;
        }
        
        ShootingBehaviour.Shoot();
        Cooldown = MaxCooldown;
    }
}
