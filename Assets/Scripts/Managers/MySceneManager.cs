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
        // Pr�charge la sc�ne en arri�re-plan
        _sceneLoadOperation = SceneManager.LoadSceneAsync(_sceneName, LoadSceneMode.Single);
        // Emp�che la sc�ne de s'afficher imm�diatement
        _sceneLoadOperation.allowSceneActivation = false;

        // Attendre que l'�cran soit compl�tement fondu
        yield return new WaitForSeconds(_fadeScreen.FadeDuration());

        // Maintenant que l'�cran est noir, on peut permettre � la sc�ne de s'activer
        // (vous pourriez vouloir attendre plus longtemps ou v�rifier d'autres conditions avant d'activer la sc�ne)
        _sceneLoadOperation.allowSceneActivation = true;

        // Attendre un petit peu pour permettre � la sc�ne de commencer le chargement
        yield return new WaitForSeconds(0.1f);

        // Faire le fondu en entr�e une fois que la nouvelle sc�ne commence � s'afficher
        _fadeScreen.FadeIn();
    }
}
