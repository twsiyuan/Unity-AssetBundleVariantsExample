using UnityEngine;

[CreateAssetMenu]
public class ColorAsset : ScriptableObject {

    [SerializeField]
    Color mainColor;
    
    public Color MainColor
    {
        get
        {
            return this.mainColor;
        }

        set
        {
            this.mainColor = value;
        }
    }
}
