using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChaser : MonoBehaviour
{
    public Transform TransformToChase;

    public float FreeWidth;
    public float FreeHeight;
    public bool CanGoForward;

    void Update()
    {
        var position = transform.position;
        Vector2 signedDistance = TransformToChase.position - position;
        
        if (Mathf.Abs(signedDistance.x) > FreeWidth)
        {
            position += Vector3.right * (signedDistance.x * 0.7f * Time.deltaTime);
        }

        if (signedDistance.y > FreeHeight && CanGoForward)
        {
            position += Vector3.up * (signedDistance.y * 0.7f * Time.deltaTime);
        }
        
        transform.position = position;
    }
}
