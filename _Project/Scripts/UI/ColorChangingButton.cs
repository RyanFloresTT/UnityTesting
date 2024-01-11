using System.Xml.Serialization;
using UnityEngine;

public class ColorChangingButton : MonoBehaviour {

    [SerializeField] private Color color;
    public Color Color { get { return color; } set {color = value;} }

    public SpriteRenderer SpriteToColor { get; set; }
    
    public void SetColor() {
        if (SpriteToColor == null) return; 
        Color newColor = color;
        newColor.a = SpriteToColor.color.a;
        SpriteToColor.color = newColor;
    }
}
