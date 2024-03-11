using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    [SerializeField] private  GameObject leftHand, teleportationRay;

    [SerializeField]private InputActionProperty leftActivate;


    void Start()
    {
        
    }

    void Update()
    {
        if (leftActivate.action.ReadValue<float>() > 0.1f)
        {
            teleportationRay.SetActive(true);
        }
        else
        {
            teleportationRay.SetActive(false);
        }
    }
}
