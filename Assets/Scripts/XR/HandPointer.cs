using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SphereCollider))]
public class HandPointer : MonoBehaviour
{
    [SerializeField] private InputActionReference _triggerActionReference;
    [SerializeField] private SphereCollider _sphereCollider;

    private void OnEnable()
    {
        _triggerActionReference.action.performed += OnActionPerformed;
        _triggerActionReference.action.canceled += OnActionCanceled;
    }

    private void OnActionPerformed(InputAction.CallbackContext context) => _sphereCollider.enabled = true;

    private void OnActionCanceled(InputAction.CallbackContext context) => _sphereCollider.enabled = false;

    private void OnDisable()
    {
        _triggerActionReference.action.performed -= OnActionPerformed;
        _triggerActionReference.action.canceled -= OnActionCanceled;
    }
}
