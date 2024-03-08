using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _mTimeLeft;
    public static GameManager Instance { get; private set; }
    private float _mTimer;

    // UI
    [SerializeField] private GameObject _titlePrefab;

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

    private void Start()
    {
        StartCoroutine(MusicIntro());
        StartCoroutine(TitleIntro());
    }

    public void Quit()
    {
        Application.Quit();
    }

    public float GetTime()
    {
        return _mTimeLeft;
    }
}
