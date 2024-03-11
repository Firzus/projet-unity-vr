using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorLock : MonoBehaviour
{
    [SerializeField] private bool _isLock = true;
    private XRGrabInteractable _doorStatut;
    void Start()
    {
        _doorStatut = this.GetComponent<XRGrabInteractable>();
        if (_isLock)
        {
            _doorStatut.enabled = false;
        }
    }


    public void UnlockDoor()
    {
        _doorStatut.enabled = true;
    }
}
