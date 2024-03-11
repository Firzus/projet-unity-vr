using UnityEngine;

public class ConsoleIntro : MonoBehaviour
{
    [SerializeField] private Renderer _objectRenderer;
    [SerializeField] private Material _appearMaterial;
    [SerializeField] private GameObject _uiObject;
    [SerializeField] private float _revealSpeed = 1.0f;
    [SerializeField] private float _maxOffset = 5.0f;
    [SerializeField] private float _offset = -1.0f;

    private Material _defaultMaterial;

    private void Awake()
    {
        _defaultMaterial = _objectRenderer.material;
        _objectRenderer.material = _appearMaterial;

        // Inactive UI
        _uiObject.SetActive(false);
    }

    private void Update()
    {
        if (_offset < _maxOffset)
        {
            _offset += Time.deltaTime * _revealSpeed;
            _appearMaterial.SetFloat("_Offset", _offset);
        }
        else if (_objectRenderer.material != _defaultMaterial)
        {
            _objectRenderer.material = _defaultMaterial;
            _uiObject.SetActive(true);
        }
    }
}
