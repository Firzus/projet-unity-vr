using UnityEngine;

public class KeyUnlocking : MonoBehaviour
{
    [SerializeField] private GameObject _targetDoor;

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Key"))
        {
            this.gameObject.GetComponent<LockedSong>().Song = false;
            _targetDoor.GetComponent<DoorLock>().UnlockDoor();
            AudioManager.Instance.PlaySFX("DoorUnlocking");
            Destroy(collider.gameObject);
        }
    }
}
