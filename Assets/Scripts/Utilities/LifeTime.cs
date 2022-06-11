using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public float Value;

    void Start()
    {
        Destroy(gameObject, Value);
    }
}
