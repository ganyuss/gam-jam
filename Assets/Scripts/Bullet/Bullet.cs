using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObjectSet TargetSet;
    
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var targetObject = otherCollider.gameObject;

        if (! TargetSet.EnabledGameObject.Contains(targetObject))
            return;
        
        var target = targetObject.GetComponent<BulletTarget>();
        
        if (target != null)
            target.OnCollisionBulletHit();
        
        Destroy(gameObject);
    }
}
