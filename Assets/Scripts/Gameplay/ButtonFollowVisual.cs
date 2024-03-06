using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonFollowVisual : MonoBehaviour
{
    public Transform visualTarget;
    public Vector3 localAxis;
    public float resetSpeed = 5f;
    public float followAngle = 45;

    private bool _freeze = false;

    private Vector3 _initialLocalPos;
    private Vector3 _offset;
    private Transform _pokeAttachTransform;

    private XRBaseInteractable _interactable;
    private bool _isFollowing = false;

    void Start()
    {
        _initialLocalPos = visualTarget.localPosition;

        _interactable = GetComponent<XRBaseInteractable>();
        _interactable.hoverEntered.AddListener(Follow);
        _interactable.hoverExited.AddListener(ResetFollow);
        _interactable.selectEntered.AddListener(Freeze);
    }

    public void Follow(BaseInteractionEventArgs hover)
    {
        if(hover.interactorObject is XRPokeInteractor)
        {
            XRPokeInteractor interactor = (XRPokeInteractor)hover.interactorObject;
            _isFollowing = true;

            _pokeAttachTransform = interactor.attachTransform;
            _offset = visualTarget.position - _pokeAttachTransform.position;
            _freeze = false;

            float pokeAngle = Vector3.Angle(_offset, visualTarget.TransformDirection(localAxis));

            if(pokeAngle < followAngle)
            {
                _isFollowing = true;
                _freeze = false;
            }
        }
    }
    public void ResetFollow(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            _isFollowing = false;
            _freeze = false;
        }
    }

    public void Freeze(BaseInteractionEventArgs hover)
    {
        if (hover.interactorObject is XRPokeInteractor)
        {
            _freeze = true;
            //
            //  mettre la fonctionnalité du bouton (script)
            //
        }
    }

    void Update()
    {
        if(_freeze)
        {
            return;
        }
        if(_isFollowing)
        {
            Vector3 localTargetPosition = visualTarget.InverseTransformPoint(_pokeAttachTransform.position + _offset);
            Vector3 constrainedLocalTargetPosition = Vector3.Project(localTargetPosition, localAxis);
            visualTarget.position = visualTarget.TransformPoint(constrainedLocalTargetPosition);
        }
        else
        {
            visualTarget.localPosition = Vector3.Lerp(visualTarget.localPosition, _initialLocalPos, Time.deltaTime * resetSpeed);
        }
    }
}
