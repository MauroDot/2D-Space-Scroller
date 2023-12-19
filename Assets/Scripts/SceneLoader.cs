using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneNameToLoad; // The name of the scene you want to load.

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
