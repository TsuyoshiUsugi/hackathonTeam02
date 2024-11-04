using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public static SceneTransition Instance
    {
        get; private set;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
           Destroy(gameObject);
        }
    }

    public enum SceneType
    {
        Title,
        InGame,
        Result,
    }

    public void LoadScene(SceneType type)
    {
        switch (type)
        {
            case SceneType.Title:
                SceneManager.LoadScene(0);
                break;
            case SceneType.InGame:
                SceneManager.LoadScene(1);
                break;
            case SceneType.Result:
                SceneManager.LoadScene(2);
                break;
        }
    }
}