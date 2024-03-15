using UnityEngine;

public class ObjectFallingSecurity : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    public void OnTriggerEnter(Collider other)
    {
        other.transform.position = _player.transform.position;
    }
}
