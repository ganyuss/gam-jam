using System.Collections.Generic;
using System.Linq;
using EditorPlus;
using UnityEditor;
using UnityEngine;

public class NameLists : ScriptableObject
{
    [HideInInspector]
    public List<string> FirstNames;
    [HideInInspector]
    public List<string> LastNames;
    
    #if UNITY_EDITOR
    [OnEditorGUI]
    public void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("First name count:", FirstNames.Count.ToString());
        EditorGUILayout.LabelField("Examples:", string.Join(", ", FirstNames.Take(Mathf.Min(FirstNames.Count, 4))) + (FirstNames.Count > 4 ? "..." : ""));
        
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Last name count:", LastNames.Count.ToString());
        EditorGUILayout.LabelField("Examples:", string.Join(", ", LastNames.Take(Mathf.Min(LastNames.Count, 4))) + (LastNames.Count > 4 ? "..." : ""));
    }
    #endif
}
