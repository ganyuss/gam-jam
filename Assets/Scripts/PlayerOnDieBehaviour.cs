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

    private void OnEnable()
    {
        UpdateOnDieListener();
    }

    private void UpdateOnDieListener()
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
        Transform myTransform = transform;
        myTransform.parent = AllySet.EnabledGameObject[Random.Range(0, AllySet.EnabledGameObject.Count)].transform;
        myTransform.localPosition = Vector3.zero;
        myTransform.localRotation = Quaternion.identity;
        
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {

        DeathPanelAnimator.Instance.OnAnimationEnd -= FindNewAlly;
    }
}
