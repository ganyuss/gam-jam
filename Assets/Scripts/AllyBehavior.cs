using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AllyBehavior : MonoBehaviour
{

    public float maxDistanceBattlefield;
    public GameObject player { get; set; }
    public ClosestTargetBehavior closestTarget;
    public GameObjectSet enemySet;
    public float speed;
    public ShootingBehaviour shootingBehavior;

    public float movementTimer;
    public int decision;
    public GameObject nearestEnemy = null;
    public Vector2 newPosition;


    void Start()
    {
        movementTimer = 1.0f;
    }


    void Update()
    {
        if (player)
            maxDistanceBattlefield = player.transform.position.y;


        if(movementTimer > 0)
        {
            movementTimer -= Time.deltaTime;

            if (movementTimer <= 0)
                decision = NewDecision();
            
            return;
        }

        switch(decision)
        {
            case 0:
                MoveToTarget(newPosition);
                break;

            case 1:
                shootingBehavior.Shoot();
                movementTimer = 2.0f;
                break;

            case 2:
                MoveTowardEnemy(nearestEnemy);
                break;
        }

    }

    void MoveToTarget(Vector2 targetToReach)
    {
        transform.position += ((Vector3)targetToReach - transform.position).normalized * speed * Time.deltaTime;

        if(Vector2.Distance(transform.position, targetToReach) < 0.3f)
        {
            decision = NewDecision();
        }
    }


    void MoveTowardEnemy(GameObject enemy)
    {
        if (enemy == null || closestTarget.target != null)
            decision = NewDecision();

        var position = Vector2.zero;

        position.x = (position.x > enemy.transform.position.x ? -1 : 1) * Time.deltaTime * speed;

        transform.position += (Vector3)position;
    }

    private float NewRandom(float weight)
    {
        return Random.value * weight;
    }

    private int NewDecision()
    {
        if (transform.position.y <= maxDistanceBattlefield - 0.5f)
        {

            newPosition = new Vector2(transform.position.x + Random.Range(-5f, 5f), maxDistanceBattlefield + Random.Range(-5f, 5f));
            if (newPosition.x < -WorldUtilities.TerrainWidth / 2)
            {
                newPosition.x += 4;
            }
            if (newPosition.x > WorldUtilities.TerrainWidth / 2)
            {
                newPosition.x -= 4;
            }
            return 0;
        }
        
        if (closestTarget.target != null)
            return 1;

        var enemiesInCamera = enemySet.EnabledGameObject.Where(enemy => WorldUtilities.IsInCamera(enemy.transform)).ToList();

        if (enemiesInCamera.Count > 0)
        {
            float shortestDistance = Mathf.Infinity;
            nearestEnemy = enemiesInCamera.First();

            foreach (var enemy in enemiesInCamera)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

                if (distanceToEnemy < shortestDistance)
                {
                    shortestDistance = distanceToEnemy;
                    nearestEnemy = enemy;
                }
            }

            return 2;
        }
        else
        {
            movementTimer = 1.0f;
            return 2;
        }

    }
}
