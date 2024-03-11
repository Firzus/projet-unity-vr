using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float TimeLeft { get => _mTimeLeft; private set => _mTimeLeft = value; }
    [SerializeField] private float _mTimeLeft;

    public float Timer { get => _mTimer; private set => _mTimer = value; }
    private float _mTimer;

    public static GameManager Instance; 

    void Start()
    {
        DontDestroyOnLoad(this);

        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void Quit()
    {
        Quit();
    }
}
