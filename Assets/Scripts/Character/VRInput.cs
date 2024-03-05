using UnityEngine;
using UnityEngine.InputSystem;

public class VRInput : MonoBehaviour
{
    public InputActionProperty inputAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue  = inputAction.action.ReadValue<float>();

    }
}
