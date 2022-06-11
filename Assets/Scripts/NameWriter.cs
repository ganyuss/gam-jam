using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class NameWriter : MonoBehaviour
{
    public TMP_Text Text;
    public int CurrentYear = 2022;
    public float TextDuration;

    public UnityEvent OnTextWritten;

    public void Awake()
    {
        Reset();
    }

    public void WriteName()
    {
        Text.gameObject.transform.position = DeathPanelAnimator.Instance.ScreenPosition +
                                             Vector2.down * DeathPanelAnimator.Instance.ObjectSize;

        Text.text = string.Empty;
        Text.gameObject.SetActive(true);

        string deathName = NameGenerator.GetNewFullName();
        StartCoroutine(WriteText(deathName, $"{Random.Range(CurrentYear-30, CurrentYear-17)} - {CurrentYear}"));
    }

    private IEnumerator WriteText(string deathName, string date)
    {
        for (int i = 0; i < deathName.Length+1; i++)
        {
            Text.text = deathName.Substring(0, i);
            yield return new WaitForSecondsRealtime(0.1f);
        }
        
        yield return new WaitForSecondsRealtime(0.5f);

        Text.text = $"{deathName}\n{date}";

        yield return new WaitForSecondsRealtime(TextDuration);

        Reset();
        OnTextWritten.Invoke();
    }

    private void Reset()
    {
        Text.text = string.Empty;
        Text.gameObject.SetActive(false);
    }
}
