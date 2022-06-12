using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerOnDieBehaviour : MonoBehaviour
{
    public GameObjectSet AllySet;
    public float DeathAnimationCutoutSize;

    private void Start()
    {
        DeathPanelAnimator.Instance.OnAnimationEnd += OnDeathAnimationEnd;
    }

    private void OnDeathAnimationEnd()
    {
        DeathPanelAnimator.Instance.OnAnimationEnd -= OnDeathAnimationEnd;
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
        UpdateOnDieListener();
    }

    private void UpdateOnDieListener()
    {
        if (transform.parent != null)
            transform.parent.gameObject.GetComponent<UnitDieBehaviour>().OnDie.AddListener(OnDie);
    }

    private void OnDisable()
    {
        if (transform.parent != null)
            transform.parent.gameObject.GetComponent<UnitDieBehaviour>().OnDie.RemoveListener(OnDie);
    }

    private void OnDie()
    {
        DeathPanelAnimator.Instance.StartAnimationAt(transform.position, DeathAnimationCutoutSize);
        gameObject.SetActive(false);
        transform.parent = null;
    }

    private void FindNewAlly()
    {
        Transform myTransform = transform;
        myTransform.parent = AllySet.EnabledGameObject[Random.Range(0, AllySet.EnabledGameObject.Count)].transform;
        myTransform.localPosition = Vector3.zero;
        myTransform.localRotation = Quaternion.identity;
        
        gameObject.SetActive(true);
    }
}
