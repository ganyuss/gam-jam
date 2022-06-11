using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DeathPanelMaterialSizeSetter : MonoBehaviour
{
    public float Size;
    private float ActualSize;
    
    public Image DeathPanelImage;

    private Material DeathPanelMaterial;
    
    
    private static readonly int CutoutSize = Shader.PropertyToID("_CutoutSize");
    
    private void Start()
    {
        DeathPanelMaterial = DeathPanelImage.material;
        ActualSize = DeathPanelMaterial.GetFloat(CutoutSize);
        Size = ActualSize;
    }
    
    private void Update()
    {
        if (Size != ActualSize)
        {
            DeathPanelMaterial.SetFloat(CutoutSize, Size);
            ActualSize = Size;
        }
        else
        {
            ActualSize = DeathPanelMaterial.GetFloat(CutoutSize);
            Size = ActualSize;
        }
    }

    public void StartTransitionTo(float targetValue, float duration)
    {
        StartCoroutine(TransitionCoroutine(Size, targetValue, duration, s => Size = s));
    }
    
    
    private IEnumerator TransitionCoroutine(float origin, float target, float duration, Action<float> Setter)
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
    }
}
