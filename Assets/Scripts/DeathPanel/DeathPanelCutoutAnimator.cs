using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DeathPanelCutoutAnimator : MonoBehaviour
{
    public Image DeathPanelImage;
    public float AnimationDuration;
    public float TimeScaleToZeroDuration;

    [Space] 
    public UnityEvent OnAnimationInFinished;
    public UnityEvent OnAnimationOutFinished;

    private Material DeathPanelMaterial;
    private float MaxCutoutSize => Screen.width * 2;
    
    private static readonly int CutoutCenterX = Shader.PropertyToID("_CutoutCenterX");
    private static readonly int CutoutCenterY = Shader.PropertyToID("_CutoutCenterY");
    private static readonly int CutoutSize = Shader.PropertyToID("_CutoutSize");

    private void Start()
    {
        DeathPanelMaterial = DeathPanelImage.material;
    }
    
    public void AnimationIn()
    {
        Vector3 cutoutTarget = Camera.main.ScreenToViewportPoint(DeathPanelAnimator.Instance.ScreenPosition);
        DeathPanelMaterial.SetFloat(CutoutCenterX, cutoutTarget.x);
        DeathPanelMaterial.SetFloat(CutoutCenterY, cutoutTarget.y);
        
        
        StartCoroutine(TransitionCoroutineEaseOut(Time.timeScale, 0.1f, TimeScaleToZeroDuration, t => Time.timeScale = t));
        StartCoroutine(TransitionCoroutineEaseOut(MaxCutoutSize, DeathPanelAnimator.Instance.ObjectSize, AnimationDuration,
            s => DeathPanelMaterial.SetFloat(CutoutSize, s), OnAnimationInFinished.Invoke));
    }

    public void AnimationOut()
    {
        float currentCutoutSize = DeathPanelMaterial.GetFloat(CutoutSize);
        
        StartCoroutine(TransitionCoroutineEaseIn(Time.timeScale, 1, TimeScaleToZeroDuration, t => Time.timeScale = t));
            StartCoroutine(TransitionCoroutineEaseIn(currentCutoutSize, MaxCutoutSize, AnimationDuration,
                s => DeathPanelMaterial.SetFloat(CutoutSize, s), OnAnimationOutFinished.Invoke));
    }
    
    private IEnumerator TransitionCoroutineEaseIn(float origin, float target, float duration, Action<float> Setter, Action after = null)
    {
        float time = 0;

        float EaseInCubic(float start, float end, float value)
        {
            end -= start;
            return end * value * value * value + start;
        }
        
        while (time < duration)
        {
            var currentValue = EaseInCubic(origin, target, time / duration);
            
            Setter.Invoke(currentValue);

            time += Time.unscaledDeltaTime;
            yield return null;
        }
        
        after?.Invoke();
    }

    private IEnumerator TransitionCoroutineEaseOut(float origin, float target, float duration, Action<float> Setter, Action after = null)
    {
        float time = 0;

        float EaseOutCubic(float start, float end, float value)
        {
            value--;
            end -= start;
            return end * (value * value * value + 1) + start;
        }
        
        while (time < duration)
        {
            var currentValue = EaseOutCubic(origin, target, time / duration);
            
            Setter.Invoke(currentValue);

            time += Time.unscaledDeltaTime;
            yield return null;
        }
        
        after?.Invoke();
    }
}
