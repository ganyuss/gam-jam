using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChaser : MonoBehaviour
{
    public GameObject GameObjectToChase { get; set; }

    public float FreeWidth;

    void Update()
    {
        if (!GameObjectToChase)
            return;
        
        var position = transform.position;
        Vector2 signedDistance = GameObjectToChase.transform.position - position;
        
        if (Mathf.Abs(signedDistance.x) > FreeWidth)
        {
            position += Vector3.right * (signedDistance.x * 0.7f * Time.deltaTime);
        }
        
        transform.position = position;
    }
}
