using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHandScript : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public Animator handAnmiator;

    void Start()
    {
        
    }


    void Update()
    {
        float triggerValue = pinchAnimationAction.action.ReadValue<float>();
        handAnmiator.SetFloat("Trigger", triggerValue);

        float gripValue = gripAnimationAction.action.ReadValue<float>();
        handAnmiator.SetFloat("Grip", gripValue);
    }
}
