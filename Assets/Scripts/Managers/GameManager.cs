using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlayMusic("GameTheme");
    }
}
