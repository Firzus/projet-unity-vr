using System.Collections;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _console;
    [SerializeField] private GameObject _title;

    private void Start()
    {
        AudioManager.Instance.StopMusic();

        _title.SetActive(false);
        _console.SetActive(false);

        if(!MainManager.Instance.IsBackToMenu)
        {
            StartCoroutine(MusicIntro(5));
            StartCoroutine(TitleIntro(7));
            StartCoroutine(ConsoleIntro(14));

            MainManager.Instance.IsBackToMenu = true;
        }
        else
        {
            StartCoroutine(MusicIntro(0));
            StartCoroutine(TitleIntro(2));
            StartCoroutine(ConsoleIntro(9));
        }
    }

    IEnumerator MusicIntro(int time)
    {
        yield return new WaitForSeconds(time);
        AudioManager.Instance.PlayMusic("MenuTheme");
    }

    IEnumerator TitleIntro(int time)
    {
        yield return new WaitForSeconds(time);
        _title.SetActive(true);
    }

    IEnumerator ConsoleIntro(int time)
    {
        yield return new WaitForSeconds(time);

        AudioManager.Instance.PlaySFX("Appear");

        _console.SetActive(true);
    }
}
