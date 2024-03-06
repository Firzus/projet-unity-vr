using UnityEngine;

public class GameManager : MonoBehaviour
{
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
