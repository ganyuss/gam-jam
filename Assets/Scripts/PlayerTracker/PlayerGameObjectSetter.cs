using UnityEngine;
using UnityEngine.Events;

public class PlayerGameObjectSetter : MonoBehaviour
{
    public UnityEvent<GameObject> OnPlayerGameObjectChanged;

    private void Start()
    {
        OnPlayerGameObjectChanged.Invoke(PlayerGameObjectChangedListener.CurrentPlayerGameObject);
        PlayerGameObjectChangedListener.OnNewPlayerGameObject += OnPlayerGameObjectChanged.Invoke;
    }

    private void OnDisable()
    {
        PlayerGameObjectChangedListener.OnNewPlayerGameObject -= OnPlayerGameObjectChanged.Invoke;
    }
}
