using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DeadBodyHeightLimit : MonoBehaviour
{
    public float HeightLimit;

    public void Update()
    {
        if (transform.position.y < HeightLimit)
            Destroy(gameObject);
    }
}
