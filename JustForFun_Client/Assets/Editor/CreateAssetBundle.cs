using UnityEngine;
using System.Collections;
using UnityEditor;
public class CreateAssetBundle {
    [MenuItem("Assets/BuildBundles")]
    static void BuildAllAssetBundles()
    {
        string target = Application.dataPath + "/StreamingAssets";
        BuildPipeline.BuildAssetBundles(target, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
