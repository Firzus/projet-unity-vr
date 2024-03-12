using UnityEngine;

public class ConsoleIntro : MonoBehaviour
{
    [SerializeField] private Renderer _objectRenderer;
    [SerializeField] private GameObject _uiObject;
    [SerializeField] private float _revealSpeed = 1.0f;
    [SerializeField] private float _maxOffset = 5.0f;
    [SerializeField] private float _offset = -1.0f;

    private bool _animationFinished = false;

    void Update()
    {
        if (!_animationFinished)
        {
            if (_offset < _maxOffset)
            {
                _offset += Time.deltaTime * _revealSpeed;
                _objectRenderer.material.SetFloat("_Offset", _offset);
            }
            else
            {
                _animationFinished = true;
                _uiObject.SetActive(true);
            }
        }
    }
}
