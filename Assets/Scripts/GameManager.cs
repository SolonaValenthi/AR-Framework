using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("No Game manager found");

            return _instance;
        }
    }

    public delegate void RemoveModels();
    public static event RemoveModels removeModels;

    void Awake()
    {
        _instance = this;
    }

    public void CloseApp()
    {
        Application.Quit();
    }

    // Refer to build settings for scene index numbers
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    // Remove placeable objects, leaving planes intact.
    public void ClearPlaceables()
    {
        removeModels?.Invoke();
    }
}
