using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.3f;

    public int _drawDepth = -1000;
    

    private float alpha = 1.0f;

    private float fadeDir = -1;

    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        color = GUI.color;
    }

    private void OnGUI()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        color.a = alpha;
        GUI.color = color;

        GUI.depth = _drawDepth;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }
    

    private void FadeIn()
    {
        fadeDir = -1;
    }
    

    private void FadeOut()
    {
        fadeDir = 1;
    }
}
