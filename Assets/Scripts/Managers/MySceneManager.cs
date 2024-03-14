using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MySceneManager : MonoBehaviour
{
    [SerializeField] private FadeScreen _fadeScreen;
    private AsyncOperation _sceneLoadOperation;
    private string _sceneName;

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
        _fadeScreen.FadeOut();
        // Précharge la scène en arrière-plan
        _sceneLoadOperation = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Single);
        // Empêche la scène de s'afficher immédiatement
        _sceneLoadOperation.allowSceneActivation = false;

        // Attendre que l'écran soit complètement fondu
        yield return new WaitForSeconds(_fadeScreen.FadeDuration());

        // Maintenant que l'écran est noir, on peut permettre à la scène de s'activer
        // (vous pourriez vouloir attendre plus longtemps ou vérifier d'autres conditions avant d'activer la scène)
        _sceneLoadOperation.allowSceneActivation = true;

        // Attendre un petit peu pour permettre à la scène de commencer le chargement
        yield return new WaitForSeconds(0.1f);

        // Faire le fondu en entrée une fois que la nouvelle scène commence à s'afficher
        _fadeScreen.FadeIn();
    }
}
