using UnityEngine;

public class Digicode : MonoBehaviour
{
    [SerializeField] private GameObject _door;

    public void Granted()
    {
        _door.GetComponent<DoorLock>().UnlockDoor(); 
    }
}
