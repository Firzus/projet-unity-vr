using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _mTimeLeft;
    [SerializeField] private GameObject _console;
    [SerializeField] private GameObject _title;

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (Instance == null)
        {

            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        _title.SetActive(false);
        _console.SetActive(false);

        StartCoroutine(MusicIntro());
        StartCoroutine(TitleIntro());
        StartCoroutine(ConsoleIntro());
    }

    IEnumerator MusicIntro()
    {
        yield return new WaitForSeconds(5);
        AudioManager.Instance.PlayMusic("MenuTheme");
    }

    IEnumerator TitleIntro()
    {
        yield return new WaitForSeconds(7);
        _title.SetActive(true);
    }

    IEnumerator ConsoleIntro()
    {
        yield return new WaitForSeconds(13);

        AudioManager.Instance.PlaySFX("Appear");

        _console.SetActive(true);
    }

    void Quit()
    {
        Application.Quit();
    }

    float GetTime()
    {
        return _mTimeLeft;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }

        AudioManager.Instance.StopMusic();
    }
}
