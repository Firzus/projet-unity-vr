using System.Collections;
using UnityEngine;

public class OpenBook : MonoBehaviour
{
    [SerializeField] private GameObject _cover;
    [SerializeField] private HingeJoint _hingeJoint;
    [SerializeField] private AudioSource _flipsSound;

    void Start()
    {
        var myHinge = _cover.GetComponent<HingeJoint>();

        myHinge.useMotor = false;
    }

    public void OpenSesame()
    {
        if (_hingeJoint.useMotor == false)
        {
            StartCoroutine(PlayFlipSound());
        }
        _hingeJoint.useMotor = true;
    }

    IEnumerator PlayFlipSound()
    {
        _flipsSound.Play();
        yield return new WaitForSeconds(0.5f);
        _flipsSound.Stop();
    }
}
