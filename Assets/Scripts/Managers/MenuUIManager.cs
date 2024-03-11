using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _mHomePage;
    [SerializeField] private GameObject _mSettings;
    private string _sceneName;

    public void UIActive(GameObject UI)
    {
        UI.SetActive(true);

        if (UI == _mSettings) 
        {
            _mHomePage.SetActive(false);
        }
        
        if (UI == _mHomePage) 
        {
            _mSettings.SetActive(false);
        }
    }

    public void SetScene(string name)
    {
        _sceneName = name;
        MySceneManager.Instance.ChangeScene(_sceneName);
    }
}
