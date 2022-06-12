using UnityEngine;

public class MoveUpDetector : MonoBehaviour
{
    public GameObject GameObjectToCheck { get; set; }
    public GameObjectSet ObjectsToMove;
    public GameObjectSet EnemySet;

    [Space] 
    public float Threshold;
    public float EnemyThreshold;
    public bool CanMoveUp;
    
    void Update()
    {

        foreach(var enemy in EnemySet.EnabledGameObject)
        {
            Vector2 signedDistanceEnemy = enemy.transform.position - transform.position;

            if (signedDistanceEnemy.y < EnemyThreshold)
            {
                CanMoveUp = false;
                return;
            }
        }
        CanMoveUp = true;
        
        if (!GameObjectToCheck || !CanMoveUp)
            return;
        
        Vector2 signedDistance = GameObjectToCheck.transform.position - transform.position;
        
        if (signedDistance.y > Threshold)
        {
            foreach (var objectToMove in ObjectsToMove.EnabledGameObject)
            {
                objectToMove.transform.position += Vector3.down * ((signedDistance.y - Threshold) * 8f * Time.deltaTime);
            }
        }
    }
}
