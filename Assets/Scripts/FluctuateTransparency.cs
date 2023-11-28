using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class FluctuateTransparency : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float interval = 2.0f; // Time in seconds for a complete fade in and out cycle

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FluctuateAlphaPeriodically());
    }

    IEnumerator FluctuateAlphaPeriodically()
    {
        while (true)
        {
            // Fade out
            yield return StartCoroutine(FadeAlpha(1.0f, 0.0f, interval / 2));
            // Fade in
            yield return StartCoroutine(FadeAlpha(0.0f, 1.0f, interval / 2));
        }
    }

    IEnumerator FadeAlpha(float startAlpha, float endAlpha, float duration)
    {
        float time = 0;
        Color color = spriteRenderer.color;

        while (time < duration)
        {
            float alpha = Mathf.Lerp(startAlpha, endAlpha, time / duration);
            spriteRenderer.color = new Color(color.r, color.g, color.b, alpha);
            time += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = new Color(color.r, color.g, color.b, endAlpha); // Ensure final alpha is set
    }
}
