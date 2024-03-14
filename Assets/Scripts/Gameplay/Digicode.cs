using UnityEngine;

public class Digicode : MonoBehaviour
{
    [SerializeField] private GameObject _mDoor;

    public void Granted()
    {
        _mDoor.GetComponent<DoorLock>().UnlockDoor(); 
    }
}
