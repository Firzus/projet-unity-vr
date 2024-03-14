using UnityEngine;

public class StepHorror : MonoBehaviour
{
    private bool _isActive = false;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player") && !_isActive)
        {
            _isActive = true;
            AudioManager.Instance.PlaySFX("HorrorStep");
        }
    }
}
