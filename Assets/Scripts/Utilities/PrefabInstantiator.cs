using EditorPlus;
using UnityEngine;

public class PrefabInstantiator : MonoBehaviour
{
    public GameObject PrefabToInstantiate;
    public Vector2 HeadStart;

    public float AngleRandomness;
    
    [Button]
    public void InstantiatePrefab()
    {
        var currentTransform = transform;
        
        bool prefabWasActive = PrefabToInstantiate.activeSelf;
        
        if (prefabWasActive)
            PrefabToInstantiate.SetActive(false);

        var instantiatedObject = Instantiate(PrefabToInstantiate, currentTransform.position, currentTransform.rotation);
        
        if (prefabWasActive)
            PrefabToInstantiate.SetActive(true);

        instantiatedObject.transform.Rotate(instantiatedObject.transform.forward, Random.Range(-AngleRandomness/2, AngleRandomness/2));
        
        instantiatedObject.transform.Translate(HeadStart);
        instantiatedObject.SetActive(true);
    }
}
