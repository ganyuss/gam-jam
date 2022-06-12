using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChaser : MonoBehaviour
{
    public Transform TransformToChase;

    public float FreeWidth;

    void Update()
    {
        var position = transform.position;
        Vector2 signedDistance = TransformToChase.position - position;
        
        if (Mathf.Abs(signedDistance.x) > FreeWidth)
        {
            position += Vector3.right * (signedDistance.x * 0.7f * Time.deltaTime);
        }
        
        transform.position = position;
    }
}
