using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorLock : MonoBehaviour
{
    [SerializeField] private bool _isLock = true;
    public bool IsLock {get => _isLock;}
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
        _isLock = false;
        _doorStatut.enabled = true;
    }
}
