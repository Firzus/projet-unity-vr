using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _homePage;
    [SerializeField] private GameObject _settings;

    private void Start()
    {
        _homePage.SetActive(true);
        _settings.SetActive(false);
    }

    public void UIActive(GameObject UI)
    {
        UI.SetActive(true);

        if (UI == _settings) 
        {
            _homePage.SetActive(false);
        }
        else if (UI == _homePage) 
        {
            _settings.SetActive(false);
        }
    }

    public void SetScene(string name)
    {
        MySceneManager.Instance.ChangeScene(name);
    }
}
