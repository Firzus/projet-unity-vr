using UnityEngine;

public class KeyUnlocking : MonoBehaviour
{
    [SerializeField] private GameObject _targetDoor;

    public void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Key"))
        {
            _targetDoor.GetComponent<DoorLock>().UnlockDoor();
            Destroy(collider.gameObject);
        }
    }
}
