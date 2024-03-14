using System.Collections;
using UnityEngine;

public class LockedSong : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.CompareTag("LeftHand") || other.gameObject.CompareTag("RightHand")))
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
