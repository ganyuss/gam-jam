using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetManager : MonoBehaviour
{

    public GameObjectSet gameObjectSet;

    private void OnEnable()
    {
        gameObjectSet.EnabledGameObject.Add(gameObject);
    }

    private void OnDisable()
    {
        gameObjectSet.EnabledGameObject.Remove(gameObject);
    }

}
