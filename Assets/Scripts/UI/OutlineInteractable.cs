using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;

public class OutlineInteractable : MonoBehaviour
{
    [SerializeField] private Transform _mHighlight;
    private RaycastHit _mHit;
    private int _mTargetLayer = 6;
    private bool _valid = false, _outlined = false; //_onTriggered = false;

    void Update()
    {
        Outlining();
    }

    void Outlining()
    {
        if (_outlined)
        {
            CheckOutline();
            if (!_valid)
                return;
            _mHighlight.gameObject.GetComponent<Outline>().enabled = false;
            _outlined = false;
        }
        Ray ray = new Ray(transform.position, transform.forward);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out _mHit))
        {
            _mHighlight = _mHit.transform;

            CheckOutline();
            GetOrAddOutline();
        }
    }

    // private void OnTriggerEnter(Collider other)
    // {
    //     // if (other.CompareTag("LeftHand")  || other.CompareTag("RightHand") || other.CompareTag("Player"))
    //     //     return;
    //     // if (other.gameObject.GetComponent<Outline>() != null)
    //     // {
    //     //     other.gameObject.GetComponent<Outline>().enabled = true;
    //     // }
    //     // else
    //     // {
    //     //     Outline outline = other.gameObject.AddComponent<Outline>();
    //     //     outline.enabled = true;
    //     // }
    //     // _onTriggered = true;
    // }

    // private void OnTriggerExit(Collider other)
    // {
    //     // if (other.CompareTag("LeftHand") || other.CompareTag("RightHand") || other.CompareTag("Player"))
    //     //     return;
    //     // if (!_onTriggered)
    //     //     return;
    //     // if (other.gameObject.GetComponent<Outline>() != null)
    //     // {
    //     //     other.gameObject.GetComponent<Outline>().enabled = false;
    //     // }
    //     // _onTriggered = false;
    // }

    private void GetOrAddOutline()
    {
        if (!_valid)
            return;
        if (_mHighlight.gameObject.GetComponent<XRGrabInteractable>().interactionLayers == InteractionLayerMask.GetMask("ray interaction", "direct interaction") || _mHighlight.gameObject.GetComponent<XRGrabInteractable>().interactionLayers == InteractionLayerMask.GetMask("ray interaction"))
        {
            if (_mHighlight.gameObject.GetComponent<Outline>() != null)
            {
                _mHighlight.gameObject.GetComponent<Outline>().enabled = true;
            }
            else
            {

                Outline outline = _mHighlight.gameObject.AddComponent<Outline>();
                outline.enabled = true;
            }
            _outlined = true;
        }
    }

    private void CheckOutline()
    {
        if (_mHighlight == null)
        {
            _valid = default;
            return;
        }
        else if (_mHighlight.gameObject.layer != _mTargetLayer)
        {
            _valid = default;
            return;
        }
        else if (_mHighlight.gameObject.GetComponent<XRGrabInteractable>() == null)
        {
            _valid = default;
            return;
        }
        _valid = true;
    }
}
