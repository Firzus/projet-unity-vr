using UnityEngine;

public class DoorLightSwitch : MonoBehaviour
{
    [SerializeField] private DoorLock _lock;
    [SerializeField] private GameObject _GreenLight;
    [SerializeField] private GameObject _RedLight;
    private bool _switch = false;

    public void Start()
    {
        _GreenLight.SetActive(false);
        _RedLight.SetActive(true);
    }

    private void Update()
    {
        if(!_lock.IsLock && !_switch)
        {
            _switch = true;
            _GreenLight.SetActive(true);
            _RedLight.SetActive(false);
        }
    }
}
