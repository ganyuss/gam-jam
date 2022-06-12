using UnityEngine;

public class LookMouseParent : MonoBehaviour
{
    private float offset = 90.0f;

    private void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.AngleAxis(angle - offset, Vector3.forward);
    }

}
