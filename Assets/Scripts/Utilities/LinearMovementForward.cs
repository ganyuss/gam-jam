using UnityEngine;

public class LinearMovementForward : MonoBehaviour
{
    public float Speed;

    void FixedUpdate()
    {
        var currentTransform = transform;
        currentTransform.position += currentTransform.up * Speed / Time.fixedDeltaTime;
    }
}
