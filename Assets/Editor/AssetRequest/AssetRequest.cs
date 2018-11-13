using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ImportAssets : EditorWindow
{
    [MenuItem("Window/AssetsRequest/Import assets from the list")]
    static void Open()
    {
        GetWindow<ImportAssets>();
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Import Assets");
    }
}

public class MakeList : EditorWindow
{
    [MenuItem("Window/AssetsRequest/Make request list")]
    static void Open()
    {
        GetWindow<MakeList>();
    }
    private void OnGUI()
    {
        EditorGUILayout.LabelField("Make the request list");
    }

}