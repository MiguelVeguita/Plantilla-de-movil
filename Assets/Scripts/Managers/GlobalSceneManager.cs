
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GlobalSceneManager : PersistentSingleton<GlobalSceneManager>
{
    public event Action<string> OnSceneLoaded;
    public event Action<string> OnSceneUnloaded;

    public void LoadScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Additive)
    {
        var asyncLoad = SceneManager.LoadSceneAsync(sceneName, mode);
        asyncLoad.completed += op => OnSceneLoaded?.Invoke(sceneName);
    }

    public void UnloadScene(string sceneName)
    {
        var asyncUnload = SceneManager.UnloadSceneAsync(sceneName);
        asyncUnload.completed += op => OnSceneUnloaded?.Invoke(sceneName);
    }

    public void ReloadScene(string sceneName)
    {
        UnloadScene(sceneName);
        LoadScene(sceneName, LoadSceneMode.Additive);
    }

    public void SetActiveScene(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        if (scene.IsValid())
            SceneManager.SetActiveScene(scene);
        else
            Debug.LogWarning($"Scene {sceneName} is not loaded.");
    }
}