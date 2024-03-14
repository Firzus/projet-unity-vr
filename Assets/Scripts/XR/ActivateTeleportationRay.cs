using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActivateTeleportationRay : MonoBehaviour
{
    [SerializeField] private InputActionProperty _leftActivate;
    [SerializeField] private  GameObject _teleportationRay;
    [SerializeField] private XRRayInteractor _leftRay;
    [SerializeField] private XRRayInteractor _rightRay;

    void Update()
    {
        bool isLeftRayHovering = _leftRay.TryGetHitInfo(out Vector3 leftPos, out Vector3 leftNormal, out int leftnumber, out bool leftValid);

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
