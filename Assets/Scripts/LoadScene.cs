using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public SceneAsset sceneToLoad;

    public void LoadScene()
    {
        if (sceneToLoad != null)
        {
            SceneManager.LoadScene(sceneToLoad.name);
        }
        else
        {
            Debug.LogError("SceneAsset not set!");
        }
    }
}