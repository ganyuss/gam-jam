using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    private Transform target;
    private ClosestTargetBehavior ClosestTargetBehavior;

    private void Start()
    {
        ClosestTargetBehavior = GetComponent<ClosestTargetBehavior>();
    }

    void Update()
    {
        target = ClosestTargetBehavior.target;

        if (target)
        {
            Vector3 diff = target.position - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        }
    }
}
