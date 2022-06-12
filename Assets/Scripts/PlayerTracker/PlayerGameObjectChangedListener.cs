using System;
using UnityEngine;

public class PlayerGameObjectChangedListener : MonoBehaviour
{
    public static event Action<GameObject> OnNewPlayerGameObject;
    public static GameObject CurrentPlayerGameObject;

    private void Awake()
    {
        CurrentPlayerGameObject = transform.parent.gameObject;
    }

    public void OnEnable()
    {
        var newParent = transform.parent.gameObject;
        CurrentPlayerGameObject = newParent;
        OnNewPlayerGameObject?.Invoke(newParent);
    }
}
