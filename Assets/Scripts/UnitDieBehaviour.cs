using System.Collections;
using System.Collections.Generic;
using EditorPlus;
using UnityEngine;
using UnityEngine.Events;

public class UnitDieBehaviour : MonoBehaviour
{
    public GameObject DiePropPrefab;
    public UnityEvent OnDie;

    [Button("Kill")]
    public void Die()
    {
        var myTransform = transform;
        Instantiate(DiePropPrefab, myTransform.position, myTransform.rotation);
        OnDie.Invoke();
        Destroy(gameObject);
    }
}
