using UnityEngine;

public class LockedSong : MonoBehaviour
{
    [SerializeField] private DoorLock _doorLock;
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("LeftHand") || collision.gameObject.CompareTag("RightHand"))
        {
            AudioManager.Instance.PlaySFX("DoorLocked");
        }
    }
}
