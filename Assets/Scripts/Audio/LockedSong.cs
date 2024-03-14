using System.Collections;
using UnityEngine;

public class LockedSong : MonoBehaviour
{
    private bool _songOn = true;
    public bool Song {  get => _songOn; set => _songOn = value; }
    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand")) && _songOn)
        {
            StartCoroutine(SongCooldown());
        }
    }

    public IEnumerator SongCooldown()
    {
        AudioManager.Instance.PlaySFX("DoorLocked");
        yield return new WaitForSeconds(1f);
    }
}
