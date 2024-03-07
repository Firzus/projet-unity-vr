using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ButtonPushInteraction : MonoBehaviour
{
    [SerializeField] private bool _openDoor = false;
    [SerializeField] private GameObject _door;
    void Start()
    {
        GetComponent<XRSimpleInteractable>().selectEntered.AddListener(x => ActiveScript());
    }

    public void ActiveScript()
    {
        if(_openDoor)
        {

        }
    }
}
