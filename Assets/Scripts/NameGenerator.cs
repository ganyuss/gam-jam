using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class NameGenerator
{
    private static NameLists Lists;

    [RuntimeInitializeOnLoadMethod]
    private static void OnAppStart()
    {
        LoadAsync();
    }
    
    private static AsyncOperationHandle<NameLists> LoadAsync()
    {
        AsyncOperationHandle<NameLists> operationHandle = Addressables.LoadAssetAsync<NameLists>("NameLists");

        operationHandle.Completed += handle =>
        {
            Lists = handle.Result;
        };

        return operationHandle;
    }
    
    private static void LoadLists()
    {
        LoadAsync().Task.Wait();
    }

    public static string GetNewFullName()
    {
        if (Lists == null) LoadLists();

        int firstNameIndex = Random.Range(0, Lists.FirstNames.Count);
        int lastNameIndex = Random.Range(0, Lists.LastNames.Count);

        return $"{Lists.FirstNames[firstNameIndex]} {Lists.LastNames[lastNameIndex]}";
    }
}
