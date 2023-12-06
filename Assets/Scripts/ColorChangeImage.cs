using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChangeImage : MonoBehaviour
{
    public Image targetImage;
    public float transitionDuration = 2.0f;

    private Color targetColor;
    private Color currentColor;
    private float transitionTimer;

    void Start()
    {
        if (targetImage == null)
        {
            targetImage = GetComponent<Image>();
        }

        targetColor = targetImage.color;
        currentColor = targetColor;
    }

    void Update()
    {
        if (targetImage == null) return;

        if (transitionTimer < transitionDuration)
        {
            targetImage.color = Color.Lerp(currentColor, targetColor, transitionTimer / transitionDuration);
            transitionTimer += Time.deltaTime;
        }
        else
        {
            transitionTimer = 0f;
            currentColor = targetImage.color;
            targetColor = new Color(Random.value, Random.value, Random.value);
        }
    }
}
