using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerRespawner : MonoBehaviour
{
    public GameObject PlayerPrefab;

    public GameObjectSet AllySet;

    private GameObject Player;
        
    private void Awake()
    {
        Player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (! Player)
        {
            Debug.Log("Player lose, creating new player");
            var randomAlly = AllySet.EnabledGameObject[Random.Range(0, AllySet.EnabledGameObject.Count)];
            Player = Instantiate(PlayerPrefab, randomAlly.transform);
        }
    }
}
