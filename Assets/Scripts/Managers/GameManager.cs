using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 

    // Start is called before the first frame update
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
