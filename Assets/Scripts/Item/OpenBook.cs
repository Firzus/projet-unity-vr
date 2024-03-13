using UnityEngine;

public class OpenBook : MonoBehaviour
{
    [SerializeField] private GameObject _mCover;
    [SerializeField] private HingeJoint _mHingeJoint;

    void Start()
    {
        var myHinge = _mCover.GetComponent<HingeJoint>();

        myHinge.useMotor = false;
    }

    public void OpenSesame()
    {
        _mHingeJoint.useMotor = true;
    }
}
