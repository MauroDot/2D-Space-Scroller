using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSizeFluctuator : MonoBehaviour
{
    public int minFontSize = 14; // Minimum font size
    public int maxFontSize = 18; // Maximum font size
    public float fluctuationSpeed = 1.0f; // Speed of the size fluctuation

    private Text textComponent;
    private float timer;

    void Start()
    {
        // Get the Text component
        textComponent = GetComponent<Text>();

        if (textComponent == null)
        {
            Debug.LogError("Text component not found on the GameObject");
            return;
        }
    }

    void Update()
    {
        if (textComponent != null)
        {
            // Calculate font size based on a sine wave for smooth fluctuation
            float fontSize = Mathf.Lerp(minFontSize, maxFontSize, (Mathf.Sin(timer * fluctuationSpeed) + 1) * 0.5f);
            textComponent.fontSize = Mathf.RoundToInt(fontSize);

            // Increment timer
            timer += Time.deltaTime;
        }
    }
}
