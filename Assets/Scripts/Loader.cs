using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {

    public enum Theme
    {
        Spring,
        Fall,
    }

    public Theme loadTheme = Theme.Spring;

    IEnumerator Start()
    {
        var root = Application.dataPath + "/../Build";
        var themePath = root + "/data." + loadTheme.ToString().ToLower();
        var levelPath = root + "/level";

        var ab = AssetBundle.LoadFromFile(themePath);
        foreach (var assetName in ab.GetAllAssetNames())
        {
            Debug.LogFormat("Assets: {0}", assetName);
        }

        AssetBundle.LoadFromFile(levelPath);
        yield return SceneManager.LoadSceneAsync("Level", LoadSceneMode.Additive);
    }
	
}
