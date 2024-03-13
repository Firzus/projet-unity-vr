using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SnapHandAnimation : MonoBehaviour
{
    [SerializeField] private Animator _handAnimator;
    [SerializeField] private InputActionReference _triggerActionRef;
    [SerializeField] private InputActionReference _gripActionRef;

    private static readonly int TriggerAnimation = Animator.StringToHash("Trigger");
    private static readonly int GripAnimation = Animator.StringToHash("Grip");

    private void OnEnable()
    {
        _triggerActionRef.action.performed += TriggerAction_performed;
        _triggerActionRef.action.canceled += TriggerAction_canceled;

        _gripActionRef.action.performed += GripAction_performed;
        _gripActionRef.action.canceled += GripAction_canceled;
    }

    private void TriggerAction_performed(InputAction.CallbackContext context) => _handAnimator.SetFloat(TriggerAnimation, 1);
    private void TriggerAction_canceled(InputAction.CallbackContext context) => _handAnimator.SetFloat(TriggerAnimation, 0);
    private void GripAction_performed(InputAction.CallbackContext context) => _handAnimator.SetFloat(GripAnimation, 1);
    private void GripAction_canceled(InputAction.CallbackContext context) => _handAnimator.SetFloat(GripAnimation, 0);

    private void OnDisable()
    {
        _triggerActionRef.action.performed -= TriggerAction_performed;
        _triggerActionRef.action.canceled -= TriggerAction_canceled;

        _gripActionRef.action.performed -= GripAction_performed;
        _gripActionRef.action.canceled -= GripAction_canceled;
    }
}
