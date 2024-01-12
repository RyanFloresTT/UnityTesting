using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Drawing;

public class ColorChangingButtonTests {
    [SetUp] public void SetUp() {
        SceneManager.LoadScene("Main");
    }

    [UnityTest]
    public IEnumerator UICanvasExistsTest() {
        var canvas = GameObject.Find("Canvas");
        Assert.IsNotNull(canvas);
        yield return null;
    }


    [UnityTest]
    public IEnumerator ColorButtonExistsTest() {
        var canvas = GameObject.Find("Canvas");
        Assert.That(canvas, Is.Not.Null, "UI canvas not found.");
        var button = canvas.transform.Find("ColorButton").GetComponent<ColorChangingButton>();
        Assert.That(button, Is.Not.Null, "ColorButton button not found.");
        yield return null;
    }

    [UnityTest]
    public IEnumerator ColorButtonChangesSpriteColorTest() {
        var canvas = GameObject.Find("Canvas");
        var colorButton = canvas.transform.Find("ColorButton").GetComponent<ColorChangingButton>();
        var spriteToBeColored = GameObject.Find("Square").GetComponent<SpriteRenderer>();
        var colorWithAlpha = colorButton.Color;
        colorWithAlpha.a = 1;
        colorButton.GetComponent<Button>().onClick.Invoke();
        Assert.That(spriteToBeColored.color, Is.EqualTo(colorWithAlpha));
        yield return null;
    }
}
