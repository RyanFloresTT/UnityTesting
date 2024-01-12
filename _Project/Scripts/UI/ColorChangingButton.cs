using System.Xml.Serialization;
using UnityEngine;

public class ColorChangingButton : MonoBehaviour {

    [SerializeField] private Color color;
    [SerializeField] private SpriteRenderer spriteToColor;
    public Color Color { get { return color; } set {color = value;} }
        
    public void SetColor() {
        if (spriteToColor == null) return;
        color.a = 1;
        spriteToColor.color = color;
    }
}
