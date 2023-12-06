using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class CameraBackgroundColorChanger : MonoBehaviour
{
    private Camera _camera;
    private float _changeInterval = 5.0f; // Time in seconds over which color will change
    private float _elapsedTime = 0.0f; // Elapsed time since last color change
    private Color _currentColor;
    private Color _targetColor;

    void Start()
    {
        _camera = GetComponent<Camera>();
        _currentColor = _camera.backgroundColor;
        _targetColor = GetRandomColor();
        StartCoroutine(ChangeBackgroundColor());
    }

    private IEnumerator ChangeBackgroundColor()
    {
        while (true)
        {
            _elapsedTime += Time.deltaTime; // increment the elapsed time
            float t = _elapsedTime / _changeInterval; // calculate the normalized time
            _camera.backgroundColor = Color.Lerp(_currentColor, _targetColor, t); // interpolate

            // When we reach the target color, reset and choose a new target color
            if (t >= 1.0f)
            {
                _elapsedTime = 0.0f;
                _currentColor = _targetColor;
                _targetColor = GetRandomColor();
            }

            yield return null; // wait until next frame
        }
    }

    private Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value, 1.0f);
    }
}
