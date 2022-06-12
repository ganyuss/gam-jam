using EditorPlus;
using UnityEngine;

public class AllySpawner : MonoBehaviour
{
    public GameObjectSet AllySet;
    public GameObject AllyPrefab;

    [Space, MinMaxSlider(0.5f, 7)]
    public MinMaxFloat RespawnDelay;
    public int MaxAllyCount;

    private float currentCooldown;
    
    private void Update()
    {
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
            return;
        }

        int allyCount = AllySet.EnabledGameObject.Count;
        if (allyCount < MaxAllyCount)
        {
            SpawnNewAlly();
            currentCooldown = Mathf.Lerp(RespawnDelay.Min, RespawnDelay.Max, allyCount/(float)MaxAllyCount);
        }
    }

    private void SpawnNewAlly()
    {
        Instantiate(AllyPrefab, WorldUtilities.GenerateNewPositionOutsideCamera(RelativePosition.Below),
            Quaternion.identity);
    }
}
