using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ClosestTargetBehavior))]
public class IAShootingBehavior : MonoBehaviour
{
    private ClosestTargetBehavior GetClosestTarget;
    private Transform closestTarget;
    private float timer;

    public Animator animator;
    public bool isRifleReady => timer <= 0;
    public PrefabInstantiator prefabInstantiator;

    public UnityEvent ShotFired;

    public float coolDown = 2.5f;
    public float range = 15.0f;

    void Start()
    {
        timer = 0;

        GetClosestTarget = GetComponent<ClosestTargetBehavior>();
    }

    void Update()
    {
        closestTarget = GetClosestTarget.target;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        var distanceToClosestTarget = Vector2.Distance(transform.position, closestTarget.position); 

        if(isRifleReady && distanceToClosestTarget<=range)
        {
            timer = coolDown;
            EnnemyShoot();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void EnnemyShoot()
    {
        animator.SetTrigger("shoot");
    }

    void AfterAnimationShoot()
    {
        prefabInstantiator.InstantiatePrefab();
        ShotFired.Invoke();
    }

}
