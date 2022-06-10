using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public static class NameListGenerator
{
    [MenuItem("Utilities/Generate Name List")]
    public static void Generate()
    {
        string webPageFilePath = EditorUtility.OpenFilePanel("RandomLists page file", ".", "html");

        if (string.IsNullOrEmpty(webPageFilePath))
            return;

        string fileContent = File.ReadAllText(webPageFilePath);

        var nameMatches = Regex.Matches(fileContent, "<div class=\"rand_large\">(?<fullName>[a-zA-Z ]*?)<\\/div>");
        var names = nameMatches.Select(match => match.Groups["fullName"].Captures[0].Value);

        HashSet<string> firstNames = new HashSet<string>(10000);
        HashSet<string> lastNames = new HashSet<string>(10000);
        
        foreach (var name in names)
        {
            var splitName = name.Split(' ');

            if (splitName.Length > 2)
            {
                Debug.Log(name);
                continue;
            }
            
            firstNames.Add(splitName[0]);
            lastNames.Add(splitName[1]);
        }

        NameLists listAsset = ScriptableObject.CreateInstance<NameLists>();
        listAsset.FirstNames = firstNames.ToList();
        listAsset.LastNames = lastNames.ToList();
        
        AssetDatabase.CreateAsset(listAsset, "Assets/NameLists.asset");
        AssetDatabase.Refresh();
    }
}
