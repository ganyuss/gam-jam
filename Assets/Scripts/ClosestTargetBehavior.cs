using UnityEngine;

public class ClosestTargetBehavior : MonoBehaviour
{

    public GameObjectSet gameObjectSet;
    public float range = 15f;
    public Transform target;

    void Update()
    {

        UpdateTarget();
        
    }

    void UpdateTarget()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (var enemy in gameObjectSet.EnabledGameObject)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
    
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range )
	    {
            target = nearestEnemy.transform;
        }

        else
        {
            target = null;
        }
    }
}
