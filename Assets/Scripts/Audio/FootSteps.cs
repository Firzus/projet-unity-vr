using UnityEngine;
using UnityEngine.XR;

public class FootSteps : MonoBehaviour
{
    [SerializeField] private float _mWalkingSpeed;
    [SerializeField] private Vector3 lastPosition;
    [SerializeField] private AudioSource _mFootsteps;

    private void Update()
    {
        Vector3 velocity = (gameObject.transform.position - lastPosition) / Time.deltaTime;

        if (velocity.magnitude > _mWalkingSpeed)
        {
            Footsteps();
        }
        else
        {
            Stopfootsteps();
        }

        lastPosition = transform.position;
    }

    public void Footsteps()
    {
        _mFootsteps.enabled = true;
    }

    public void Stopfootsteps()
    {
        _mFootsteps.enabled = false;
    }
}
