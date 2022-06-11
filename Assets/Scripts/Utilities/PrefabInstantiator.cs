using EditorPlus;
using UnityEngine;

public class PrefabInstantiator : MonoBehaviour
{
    public GameObject PrefabToInstantiate;
    public float HeadStart;

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

        instantiatedObject.transform.position += currentTransform.up * HeadStart;
        instantiatedObject.SetActive(true);
    }
}
