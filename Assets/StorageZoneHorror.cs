using System.Collections;
using UnityEngine;

public class StorageZoneHorror : MonoBehaviour
{
    [SerializeField] private GameObject _ToDisable;
    [SerializeField] private GameObject _ToEnable;
    private bool _isActive = false;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !_isActive)
        {
            _isActive = true;
            _ToDisable.SetActive(false);
            _ToEnable.SetActive(true);
            StartCoroutine(SoundTime());
        }
    }

    private IEnumerator SoundTime()
    {
        AudioManager.Instance.PlaySFX("MetalPipe");
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}