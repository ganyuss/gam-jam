using UnityEngine;
using UnityEngine.Events;

public class BulletTarget : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnBulletHit;

    public void OnCollisionBulletHit()
    {
        OnBulletHit.Invoke();
    }
}
