using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUtilities : MonoBehaviour
{
    public static bool IsInCamera(Transform transform)
        => IsInCamera(transform.position);

    private static bool IsInCamera(Vector3 transformPosition)
    {
        var cameraPos = Camera.main.transform.position;

        return transformPosition.y >= cameraPos.y - 11 && transformPosition.y <= cameraPos.y + 11;
    }
}
