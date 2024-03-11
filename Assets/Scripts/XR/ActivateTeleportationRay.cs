using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    [SerializeField] private  GameObject _teleportationRay;
    [SerializeField] private InputActionProperty _leftActivate;

    void Update()
    {
        if (_leftActivate.action.ReadValue<float>() > 0.1f)
        {
            _teleportationRay.SetActive(true);
        }
        else
        {
            _teleportationRay.SetActive(false);
        }
    }
}
