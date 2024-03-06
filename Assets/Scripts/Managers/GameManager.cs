using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _mTimeLeft;

    private float Timer;

    public static GameManager Instance; 

    void Start()
    {
        DontDestroyOnLoad(this);

        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    private void Update()
    {
        
    }

    public void Quit()
    {
        Quit();
    }

    public float GetTime()
    {
        return _mTimeLeft;
    }
}
