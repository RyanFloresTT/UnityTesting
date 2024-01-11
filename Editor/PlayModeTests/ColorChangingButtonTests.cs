using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using System.Collections;

public class ColorChangingButtonTests {
    [UnityTest]
    public IEnumerator ButtonClick_TriggersColorChange() {
        // Arrange
        var buttonObject = CreateButton();
        ColorChangingButton colorChangingButton = buttonObject.AddComponent<ColorChangingButton>();
        Color initialColor = colorChangingButton.Color;

        var spriteObject = new GameObject("Sprite");
        var spriteObjectRenderer = spriteObject.AddComponent<SpriteRenderer>();
        colorChangingButton.SpriteToColor = spriteObjectRenderer;

        // Act
        buttonObject.GetComponent<Button>().onClick.AddListener(colorChangingButton.SetColor);
        buttonObject.GetComponent<Button>().onClick.Invoke();

        yield return null;

        // Assert
        Assert.AreNotEqual(initialColor, spriteObjectRenderer.color, "Color should change after button click.");
    }

    public GameObject CreateButton() {
        GameObject canvasObject = new GameObject("Canvas");
        Canvas canvas = canvasObject.AddComponent<Canvas>();

        GameObject buttonObject = new GameObject("TestButton");
        buttonObject.transform.SetParent(canvasObject.transform);
        buttonObject.AddComponent<Button>();

        return buttonObject;
    }
}
