using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShadowColorChanger : MonoBehaviour
{
    private Shadow shadowComponent;
    private Color currentColor;
    private Color targetColor;

    public float colorChangeDuration = 2.0f; // Duration for each color change

    void Start()
    {
        // Get the Shadow component
        shadowComponent = GetComponent<Shadow>();

        if (shadowComponent == null)
        {
            Debug.LogError("Shadow component not found on the GameObject");
            return;
        }

        currentColor = shadowComponent.effectColor;
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
                shadowComponent.effectColor = Color.Lerp(currentColor, targetColor, timer / colorChangeDuration);
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
