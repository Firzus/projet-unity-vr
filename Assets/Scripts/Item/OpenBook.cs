using System.Collections;
using UnityEngine;

public class OpenBook : MonoBehaviour
{
    [SerializeField] private GameObject _mCover;
    [SerializeField] private HingeJoint _mHingeJoint;
    [SerializeField] private AudioSource _mFlipsSound;

    void Start()
    {
        var myHinge = _mCover.GetComponent<HingeJoint>();

        myHinge.useMotor = false;
    }

    public void OpenSesame()
    {
        if (_mHingeJoint.useMotor == false)
        {
            StartCoroutine(PlayFlipSound());
        }
        _mHingeJoint.useMotor = true;
    }

    IEnumerator PlayFlipSound()
    {
        _mFlipsSound.Play();
        yield return new WaitForSeconds(0.5f);
        _mFlipsSound.Stop();
    }
}
