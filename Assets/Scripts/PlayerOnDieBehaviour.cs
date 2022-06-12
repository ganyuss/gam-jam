using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerOnDieBehaviour : MonoBehaviour
{
    public GameObjectSet AllySet;
    public float DeathAnimationCutoutSize;

    private void Start()
    {
        DeathPanelAnimator.Instance.OnAnimationEnd += FindNewAlly;
    }

    private void OnTransformParentChanged()
    {
        if (transform.parent != null)
            transform.parent.gameObject.GetComponent<UnitDieBehaviour>().OnDie.AddListener(OnDie);
    }

    private void OnDie()
    {
        DeathPanelAnimator.Instance.StartAnimationAt(transform.position, DeathAnimationCutoutSize);
        gameObject.SetActive(false);
        transform.parent = null;
    }

    private void FindNewAlly()
    {
        transform.parent = AllySet.EnabledGameObject[Random.Range(0, AllySet.EnabledGameObject.Count)].transform;
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {

        DeathPanelAnimator.Instance.OnAnimationEnd -= FindNewAlly;
    }
}
