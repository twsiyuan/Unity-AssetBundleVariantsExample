#if UNITY_EDITOR
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Build
{
    [MenuItem("Tools/Build")]
	static void PlatformBuild()
    {
        // Clean all loaded assetbundles
        Caching.CleanCache();

        // TODO: use AssetDatabase.GetAllAssetPaths to build AssetBundleBuilds
        var assetBundleBuilds = new List<AssetBundleBuild>();
        assetBundleBuilds.Add(new AssetBundleBuild()
        {
            assetBundleName = "Level",
            assetBundleVariant = "",
            assetNames = new string[] {
                "Assets/Level.unity",
            },
        });

        assetBundleBuilds.Add(new AssetBundleBuild()
        {
            assetBundleName = "Data",
            assetBundleVariant = "Spring",
            assetNames = new string[] {
                "Assets/Data/Spring/Main.jpg",
                "Assets/Data/Spring/Text.prefab",
                "Assets/Data/Spring/String.txt",
                "Assets/Data/Spring/Color.asset",
            },
        });

        assetBundleBuilds.Add(new AssetBundleBuild()
        {
            assetBundleName = "Data",
            assetBundleVariant = "Fall",
            assetNames = new string[] {
               "Assets/Data/Fall/Text.prefab",
               "Assets/Data/Fall/Main.jpg",
               "Assets/Data/Fall/String.txt",
               "Assets/Data/Fall/Color.asset",
            },
        });

        var path = Path.GetFullPath(Application.dataPath + "/../Build");
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        BuildPipeline.BuildAssetBundles(path,
            assetBundleBuilds.ToArray(), 
            BuildAssetBundleOptions.ForceRebuildAssetBundle,
            BuildTarget.StandaloneWindows64);

        if (!UnityEditorInternal.InternalEditorUtility.inBatchMode)
        {
            System.Diagnostics.Process.Start(path);
        }
    }
}

#endif