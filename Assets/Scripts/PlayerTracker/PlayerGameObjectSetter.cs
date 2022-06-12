using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerGameObjectSetter : MonoBehaviour
{
    public UnityEvent<GameObject> OnPlayerGameObjectChanged;

    private void Start()
    {
        OnPlayerGameObjectChanged.Invoke(PlayerGameObjectChangedListener.CurrentPlayerGameObject);
    }

    private void OnDisable()
    {
        PlayerGameObjectChangedListener.OnNewPlayerGameObject -= OnPlayerGameObjectChanged.Invoke;
    }
}
