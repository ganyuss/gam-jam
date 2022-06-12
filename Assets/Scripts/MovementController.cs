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
        var parent = transform.parent;
        var position = parent.position;
        position += (Vector3.up * _verticalMovement);
        position += (Vector3.right * _horizontalMovement);

        float xLimit = WorldUtilities.TerrainWidth / 2 - 0.8f;
        float yLimit = WorldUtilities.CameraHeight / 2 - 0.8f;
        position.x = Mathf.Clamp(position.x, -xLimit, xLimit);
        position.y = Mathf.Clamp(position.y, -yLimit, yLimit);
            
        parent.position = position;
    }
}
