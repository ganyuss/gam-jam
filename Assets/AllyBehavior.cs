using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBehavior : MonoBehaviour
{

    public float maxDistanceBattlefield;
    public GameObject player;
    public ClosestTargetBehavior closestTarget;

    private float movementTimer;
    private float randomWeight = 50.0f;
    private int decision;
    void Start()
    {
        movementTimer = NewRandom(randomWeight);
    }


    void Update()
    {
        maxDistanceBattlefield = player.transform.position.y;

        movementTimer -= Time.deltaTime;

        if(movementTimer < 0)
        {
            movementTimer = NewRandom(randomWeight);
            decision = NewDecision();
        }

        if (decision == 0)
        {
            MoveToFront();
        }

    }

    void MoveToFront()
    {
        float x = Random.Range(-10.0f, 10.0f);
        float y = Random.Range(0, 10.0f);

        if (y < maxDistanceBattlefield + NewRandom(2))
            transform.position += new Vector3(x , y, 0) * Time.deltaTime;
        else
        {
            transform.position += new Vector3(x, 0, 0) * Time.deltaTime;
        }
    }

    private float NewRandom(float weight)
    {
        return Random.value * weight;
    }

    private int NewDecision()
    {
        if(closestTarget.target == null)
        {
            //bouger vers ligne de front
            return 0;
        }
        else
        {
            //tirer sur ennemie et bouger un peu
            return 1;
        }

    }
}
