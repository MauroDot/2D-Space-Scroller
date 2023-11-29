using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color[] colors; // Array to hold the colors
    public float changeInterval = 1f; // Time in seconds for each color change

    private SpriteRenderer spriteRenderer;
    private float timer;
    private int currentColorIndex = 0;

    void Start()
    {
        // Get the SpriteRenderer component from the GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Check if colors are not set or less than 3
        if (colors == null || colors.Length < 3)
        {
            Debug.LogError("Please assign at least three colors in the inspector.");
        }
    }

    void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if the timer exceeds the interval
        if (timer >= changeInterval)
        {
            // Reset the timer
            timer = 0f;

            // Change the color
            spriteRenderer.color = colors[currentColorIndex];

            // Move to the next color
            currentColorIndex = (currentColorIndex + 1) % colors.Length;
        }
    }

    // Public method to adjust the color changing speed
    public void SetChangeInterval(float newInterval)
    {
        if (newInterval > 0)
        {
            changeInterval = newInterval;
        }
        else
        {
            Debug.LogError("Interval must be greater than 0.");
        }
    }
}
