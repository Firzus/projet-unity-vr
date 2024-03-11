using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _mTimeLeft;
    public static GameManager Instance { get; private set; }

    // UI
    [SerializeField] private GameObject _titlePrefab;
    [SerializeField] private GameObject _consolePrefab;

    private void Awake()
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

    IEnumerator MusicIntro()
    {
        yield return new WaitForSeconds(5);
        AudioManager.Instance.PlayMusic("MenuTheme");
    }

    IEnumerator TitleIntro()
    {
        yield return new WaitForSeconds(7);
        Instantiate(_titlePrefab, new Vector3(0, 6, 30), Quaternion.identity);
    }

    IEnumerator ConsoleIntro()
    {
        yield return new WaitForSeconds(7);
        Instantiate(_consolePrefab, new Vector3(0, 0, 1), Quaternion.identity);
    }

    private void Start()
    {
        StartCoroutine(MusicIntro());
        StartCoroutine(TitleIntro());
        StartCoroutine(ConsoleIntro());
    }

    public void Quit()
    {
        Application.Quit();
    }

    public float GetTime()
    {
        return _mTimeLeft;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadNextScene();
        }
    }

    private void LoadNextScene()
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
    }
}
