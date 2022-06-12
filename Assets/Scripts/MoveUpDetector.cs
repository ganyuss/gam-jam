using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDetector : MonoBehaviour
{
    public Transform TransformToCheck;
    public GameObjectSet ObjectsToMove;

    [Space] 
    public float ThreshHold;
    public bool CanMoveUp;
    
    void Update()
    {
        var position = transform.position;
        Vector2 signedDistance = TransformToCheck.position - position;
        
        if (signedDistance.y > ThreshHold)
        {
            foreach (var objectToMove in ObjectsToMove.EnabledGameObject)
            {
                objectToMove.transform.position += Vector3.down * (signedDistance.y * 8f * Time.deltaTime);
            }
        }
    }
}
