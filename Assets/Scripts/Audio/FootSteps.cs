using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField] private float _walkingSpeed;
    [SerializeField] private Vector3 lastPosition;
    [SerializeField] private AudioSource _footsteps;

    private void Update()
    {
        Vector3 velocity = (gameObject.transform.position - lastPosition) / Time.deltaTime;

        if (velocity.magnitude > _walkingSpeed)
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
        _footsteps.enabled = true;
    }

    public void Stopfootsteps()
    {
        _footsteps.enabled = false;
    }
}
