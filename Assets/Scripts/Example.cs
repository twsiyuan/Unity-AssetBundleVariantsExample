using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour {

    [Header("Assets")]
    [SerializeField]
    TextAsset textAsset = null;

    [SerializeField]
    ColorAsset colorAsset = null;

    [SerializeField]
    GameObject prefab = null;

    [Header("Main")]
    [SerializeField]
    Text uiText = null;

    void Start ()
    {
        this.uiText.color = colorAsset.MainColor;
        this.uiText.text = textAsset.text;

        // Reference failed? Prefab is not compatible for assetbundle variant..
        GameObject.Instantiate(this.prefab, this.transform, false);
	}
}
