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
        // Pr�charge la sc�ne en arri�re-plan
        _sceneLoadOperation = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Single);
        // Emp�che la sc�ne de s'afficher imm�diatement
        _sceneLoadOperation.allowSceneActivation = false;

        // Attend que la sc�ne soit presque charg�e (charg�e � 90%)
        while (!_sceneLoadOperation.isDone)
        {
            if (_sceneLoadOperation.progress >= 0.9f)
            {
                // La sc�ne est pr�te � �tre affich�e
                _sceneLoadOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
