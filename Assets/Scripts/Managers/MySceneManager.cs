using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MySceneManager : MonoBehaviour
{
    private string _sceneName;
    private AsyncOperation _sceneLoadOperation;

    public static MySceneManager Instance;

    void Start()
    {
        DontDestroyOnLoad(this);

        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void ChangeScene(string sceneName)
    {
        _sceneName = sceneName;
        StartCoroutine(ChangeSceneRoutine());
    }

    IEnumerator ChangeSceneRoutine()
    {
        // Précharge la scène en arrière-plan
        _sceneLoadOperation = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Single);
        // Empêche la scène de s'afficher immédiatement
        _sceneLoadOperation.allowSceneActivation = false;

        // Attend que la scène soit presque chargée (chargée à 90%)
        while (!_sceneLoadOperation.isDone)
        {
            if (_sceneLoadOperation.progress >= 0.9f)
            {
                // La scène est prête à être affichée
                _sceneLoadOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
