using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothRandomTextColorChanger : MonoBehaviour
{
    public Text text;
    public float duration = 1.0f;

    private float timeElapsed;
    private Color currentColor;
    private Color targetColor;

    void Start()
    {
        timeElapsed = 0.0f;
        currentColor = text.color;
        SetTargetColor();
    }

    void SetTargetColor()
    {
        targetColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;

        float lerpValue = Mathf.Clamp01(timeElapsed / duration);
        text.color = Color.Lerp(currentColor, targetColor, lerpValue);

        if (lerpValue == 1.0f)
        {
            currentColor = targetColor;
            timeElapsed = 0.0f;
            SetTargetColor();
        }
    }
}
