using EditorPlus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObjectSet EnemySet;
    public GameObject EnemyPrefab;

    [Space, MinMaxSlider(0.5f, 7)]
    public MinMaxFloat RespawnDelay;
    public int MaxEnemyCount;

    private float currentCooldown;

    private void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
            return;
        }

        int enemyCount = EnemySet.EnabledGameObject.Count;
        if (enemyCount < MaxEnemyCount)
        {
            SpawnNewAlly();
            currentCooldown = Mathf.Lerp(RespawnDelay.Min, RespawnDelay.Max, enemyCount / (float)MaxEnemyCount);
        }
    }

    private void SpawnNewAlly()
    {
        Instantiate(EnemyPrefab, WorldUtilities.GenerateNewPositionOutsideCamera(RelativePosition.Above),
            Quaternion.identity);
    }
}
