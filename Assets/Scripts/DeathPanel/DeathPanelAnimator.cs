using System;
using UnityEngine;
using UnityEngine.Events;

public class DeathPanelAnimator : MonoBehaviour
{
    public static DeathPanelAnimator Instance;

    public Vector2 ScreenPosition { get; private set; }
    public float ObjectSize { get; private set; }

    public UnityEvent StartAnimation;
    public event Action OnAnimationEnd;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    public void StartAnimationAt(Vector3 worldPosition, float objectSize)
    {
        if (Camera.main != null) 
            StartAnimationAt((Vector2) Camera.main.WorldToScreenPoint(worldPosition), objectSize);
    }

    public void StartAnimationAt(Vector2 screenPosition, float objectSize)
    {
        ScreenPosition = screenPosition;
        ObjectSize = objectSize;
        
        StartAnimation.Invoke();
    }

    public void AnimationEnd()
    {
        OnAnimationEnd?.Invoke();
    }

    private void OnDestroy()
    {
        if (Instance == this)
           Instance = null;
    }
}
