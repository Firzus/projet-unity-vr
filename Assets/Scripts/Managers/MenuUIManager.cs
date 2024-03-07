using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _mHomePage;
    [SerializeField] private GameObject _mSettings;
    public string SceneName;

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
        SceneName = name;
        MySceneManager.Instance.ChangeScene(SceneName);
    }
}
