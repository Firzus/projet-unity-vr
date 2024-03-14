using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    [SerializeField] private InputActionProperty _leftActivate;
    [SerializeField] private  GameObject _teleportationRay;

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
