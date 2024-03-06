using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    [SerializeField] private string _mSceneName;

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
        SceneManager.LoadScene(_mSceneName, LoadSceneMode.Single);
    }
}
