using UnityEngine;

public class HorrorVoice : MonoBehaviour
{
    private bool _isActive = false;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !_isActive)
        {
            _isActive = true;
            AudioManager.Instance.PlaySFX("CreepySound");
        }
    }
}
