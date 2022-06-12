using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed;

    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        MovePlayer(horizontalMovement, verticalMovement);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        transform.parent.position += (Vector3.up * _verticalMovement);
        transform.parent.position += (Vector3.right * _horizontalMovement);
    }
}
