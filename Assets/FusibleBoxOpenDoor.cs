using UnityEngine;

public class FusibleBoxOpenDoor : MonoBehaviour
{
    private bool _isActive = false;
    [SerializeField] DoorLock _doorToOpen;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Fusible") && !_isActive)
        {
            _isActive = true;
            _doorToOpen.UnlockDoor();
        }
    }
}
