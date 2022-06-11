using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var target = otherCollider.gameObject.GetComponent<BulletTarget>();
        
        if (target != null)
            target.OnCollisionBulletHit();
        
        Destroy(gameObject);
    }
}
