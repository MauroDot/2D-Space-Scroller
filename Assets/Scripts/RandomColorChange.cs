using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorChange : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public float changeInterval = 2.0f; // Time in seconds between color changes

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(ChangeColorPeriodically());
    }

    IEnumerator ChangeColorPeriodically()
    {
        while (true)
        {
            Color newColor = GetRandomColor();
            yield return StartCoroutine(ChangeColorSmoothly(newColor, changeInterval));
        }
    }

    IEnumerator ChangeColorSmoothly(Color targetColor, float duration)
    {
        Color startColor = spriteRenderer.color;
        float time = 0;

        while (time < duration)
        {
            spriteRenderer.color = Color.Lerp(startColor, targetColor, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        spriteRenderer.color = targetColor; // Ensure the final color is set
    }

    Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}
