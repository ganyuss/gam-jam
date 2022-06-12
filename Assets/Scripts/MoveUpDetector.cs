using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpDetector : MonoBehaviour
{
    public GameObject GameObjectToCheck { get; set; }
    public GameObjectSet ObjectsToMove;

    [Space] 
    public float Threshold;
    public bool CanMoveUp;
    
    void Update()
    {
        if (!GameObjectToCheck || !CanMoveUp)
            return;
        
        Vector2 signedDistance = GameObjectToCheck.transform.position - transform.position;
        
        if (signedDistance.y > Threshold)
        {
            Debug.Log(signedDistance.y);
            foreach (var objectToMove in ObjectsToMove.EnabledGameObject)
            {
                objectToMove.transform.position += Vector3.down * ((signedDistance.y - Threshold) * 8f * Time.deltaTime);
            }
        }
    }
}
