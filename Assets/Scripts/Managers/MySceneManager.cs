using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    [SerializeField] private FadeScreen _mFadeScreen;
    private string _mSceneName;

    public static MySceneManager Instance;

    void Start()
    {
        DontDestroyOnLoad(this);

        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void ChangeScene(string SceneName)
    {
        _mSceneName = SceneName;
        StartCoroutine(GoToSceneRoutine());
        SceneManager.LoadScene(_mSceneName, LoadSceneMode.Single);
    }

    IEnumerator GoToSceneRoutine()
    {
        _mFadeScreen.FadeOut();
        yield return new WaitForSeconds(_mFadeScreen.FadeDuration());
    }
}