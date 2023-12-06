using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutlineColorChanger : MonoBehaviour
{
    private Outline outlineComponent;
    private Color currentColor;
    private Color targetColor;

    public float colorChangeDuration = 2.0f; // Duration for each color change

    void Start()
    {
        // Get the Outline component
        outlineComponent = GetComponent<Outline>();

        if (outlineComponent == null)
        {
            Debug.LogError("Outline component not found on the GameObject");
            return;
        }

        currentColor = outlineComponent.effectColor;
        StartCoroutine(ChangeColorRoutine());
    }

    IEnumerator ChangeColorRoutine()
    {
        while (true)
        {
            targetColor = GetRandomColor();
            float timer = 0;

            while (timer < colorChangeDuration)
            {
                timer += Time.deltaTime;
                outlineComponent.effectColor = Color.Lerp(currentColor, targetColor, timer / colorChangeDuration);
                yield return null;
            }

            currentColor = targetColor;
        }
    }

    Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}
