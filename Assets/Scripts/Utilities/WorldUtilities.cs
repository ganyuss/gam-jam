using UnityEngine;

public class WorldUtilities : MonoBehaviour
{
    public const float CameraHeight = 22;
    public const float TerrainWidth = 46;
    
    public static bool IsInCamera(Transform transform)
        => IsInCamera(transform.position);

    public static bool IsInCamera(Vector3 transformPosition)
    {
        var cameraPos = Camera.main.transform.position;

        return transformPosition.y >= cameraPos.y - CameraHeight/2 && transformPosition.y <= cameraPos.y + CameraHeight/2;
    }

    public static Vector3 GenerateNewPositionOutsideCamera(RelativePosition position)
    {
        var output = new Vector3(Random.Range(-TerrainWidth / 2, TerrainWidth / 2), 0, 0);

        switch (position)
        {
            case RelativePosition.Above:
                output.y = CameraHeight / 2 + 2;
                break;
            case RelativePosition.Below:
                output.y = -CameraHeight / 2 - 2;
                break;
        }

        return output;
    }
}

public enum RelativePosition
{
    Above, Below
}
